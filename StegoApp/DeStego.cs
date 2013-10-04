using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StegoApp
{
    class DeStego
    {
        public static Boolean isEmbedded(int[,] pixels, int w, int h) {

            string header = StegoApp.Stego.getHeader();

            if (w * h <= header.Length)
                return false;

            if (w >= header.Length)
            {
                for (int i = 0; i < header.Length; i++)
                {
                    if (header[i] != extractChar(pixels[0, i]))
                        return false;
                    else
                        continue;
                }
            }
            else
            {
                for (int i = 0; i < header.Length; i++)
                {
                    if (header[i] != extractChar(pixels[i / w, i % w]))
                        return false;
                    else
                        continue;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string extractData(int[,] pixels, int w, int h, string key) {
            
            string text="";
            Boolean endFlag = false;
            
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    if (j * w + i < StegoApp.Stego.getHeader().Length)
                    {
                        continue;
                    }
                    else {

                        if (pixels[j, i] == -1)
                        {
                            endFlag = true;
                            break;
                        }
                        else {
                            text += extractChar(pixels[j, i]);
                        }
                    
                    }
                }

                if (endFlag) break;
            }

            try
            {
                text = StegoApp.Text.Decrypt(text, key);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return text;
        }

        private static char extractChar(int p){

            string alpha;
            string red;
            string green;
            string blue;

            alpha = Convert.ToString(((p >> 24) & 0xff), 2);
            red = Convert.ToString(((p >> 16) & 0xff), 2);
            green = Convert.ToString(((p >> 8) & 0xff), 2);
            blue = Convert.ToString((p & 0xff), 2);

            string s = fix(alpha).Substring(6, 2) + fix(red).Substring(6, 2) + fix(green).Substring(6, 2) + fix(blue).Substring(6, 2);

            return (char)Convert.ToInt32(s, 2);

        }

        private static string fix(string s)
        {
            string str = "00000000";
            str = str.Substring(0, str.Length - s.Length) + s;
            return str;
        }
    }
}
