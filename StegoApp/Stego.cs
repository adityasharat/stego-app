using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StegoApp {

    class Stego {
        
        static string alpha, red, green, blue;
        private static string header = "Embedded=true;";

        static char Char;

        public static Bitmap applyStego(int[,] pixels, int w, int h, string text) {
            
            System.Drawing.Color[,] output = new System.Drawing.Color[h,w];
            Bitmap outputImage = new Bitmap(w, h);
            int index=0;
            Boolean endFlag=false;
            int i, j;

            for (j = 0; j < h; j++){
                for (i = 0; i < w; i++){
                    if (index < text.Length){

                        alpha = Convert.ToString( ( (pixels[j, i] >> 24) & 0xff), 2);
                        red = Convert.ToString( ( (pixels[j, i] >> 16) & 0xff), 2);
                        green = Convert.ToString( ( (pixels[j, i] >> 8) & 0xff), 2);
                        blue = Convert.ToString( (pixels[j, i] & 0xff), 2);

                        Char = text[index];

                        outputImage.SetPixel(i,j,embed());

                        index++;
                    }
                    else {
                        if (!endFlag) {
                            outputImage.SetPixel(i, j , Color.FromArgb(255,255,255,255));
                            endFlag = true;
                        }
                        else {
                            outputImage.SetPixel(i, j, Color.FromArgb((pixels[j, i] >> 24) & 0xff, (pixels[j, i] >> 16) & 0xff, (pixels[j, i] >> 8) & 0xff, pixels[j, i] & 0xff));
                        }
                    }
                }
            }

            return outputImage;
        }

        private static System.Drawing.Color embed() {

            string str = Convert.ToString((int)Char, 2);

            str = fix(str);
            alpha = fix(alpha);
            red = fix(red);
            green = fix(green);
            blue = fix(blue);

            alpha = alpha.Substring(0, alpha.Length - 2) + str.Substring(0,2);
            red = red.Substring(0, red.Length - 2) + str.Substring(2, 2);
            green = green.Substring(0, green.Length - 2) + str.Substring(4, 2);
            blue = blue.Substring(0, blue.Length - 2) + str.Substring(6, 2);

            return System.Drawing.Color.FromArgb(Convert.ToInt32(alpha,2), Convert.ToInt32(red,2), Convert.ToInt32(green,2), Convert.ToInt32(blue,2));
        }

        private static string fix(string s) {
            string str = "00000000";
            str = str.Substring(0, str.Length - s.Length) + s;
            return str;
        }

        public static string getHeader() {
            return header;
        }
    }
}
