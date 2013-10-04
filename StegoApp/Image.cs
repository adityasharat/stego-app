using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace StegoApp
{
    class Image{
        
        /// <summary>
        /// Returns the integer array of the pixels of the image file.
        /// </summary>
        /// <param name="filePath">The absolute path to the file</param>
        /// <returns name="inputPixels">Integer array of the pixels</returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public static int[,] returnPixels(String filePath){

            Bitmap inputImageFile;

            try {
                inputImageFile = new Bitmap(filePath);
            } catch (Exception ex) {
                throw new FileNotFoundException("Error: The selected file was not found.\n" + ex.Message);
            }

            int width = inputImageFile.Width;
            int height = inputImageFile.Height;
            
            int[,] pixels = new int[height,width];
            
            for (int j = 0; j < height; j++) {
                for (int i = 0; i < width; i++) {
                    try {
                        pixels[j, i] = inputImageFile.GetPixel(i, j).ToArgb();
                    }
                    catch (Exception ex) {
                        throw new Exception("Error: " + ex.Message);
                    }
                }
            }
            
            return pixels;
        }

        /// <summary>
        /// Returns the scaled size of the image to fit into the given frame size
        /// </summary>
        /// <param name="currW">Width of image</param>
        /// <param name="currH">Height of image</param>
        /// <param name="destW">Frame width</param>
        /// <param name="destH">Frame height</param>
        /// <returns>Size of scaled image</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static Size getScalingDimensions(int currW, int currH, int destW, int destH) {
           
            if (currW <= 0 || currH <= 0 || destW <= 0 || destH <= 0) {
                throw new ArgumentOutOfRangeException("Illegal Argument: The argument must be a positive itegral value.");
            }

            //double to hold the final multiplier to use when scaling the image
            double multiplier = 0;
            //string for holding layout

            double i = (double)currW / currH;
            double f = (double)destW / destH;
            if (f >= i)
            {
                multiplier = (double)destH / currH;
            }
            else
            {
                multiplier = (double)destW / currW;
            }
            //return the new image dimensions
            return new Size((int)(currW * multiplier), (int)(currH * multiplier));
        }

        /// <summary>
        /// Scales an image to fit into given frame size.
        /// </summary>
        /// <param name="w">width</param>
        /// <param name="h">height</param>
        /// <param name="image">Input Image</param>
        /// <returns name="scaledImage">Scaled Image</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static Bitmap getScaledImage(int w, int h, Bitmap image) {

            Size imgSize;
            try{
                // get scaled dimensions
                imgSize = getScalingDimensions(image.Width, image.Height, w, h);                
            } catch (ArgumentOutOfRangeException ex) {
                throw ex;
            }

            Bitmap scaledImage;
            // create a new scaled image
            try {
                scaledImage = new Bitmap(image, imgSize.Width, imgSize.Height);
            }
            catch (Exception ex) {
                throw new Exception("Error: " + ex.Message + ".\n Scaling failed. Please try again.");
            }

            Graphics gfx;
            try {
                //create a new Graphics object from the image
                gfx = Graphics.FromImage(scaledImage);
            } catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Error: " + ex.Message); 
            } catch (Exception ex) {
                throw new Exception("Error: " + ex.Message);
            }
            
            //clean up the image (take care of any image loss from resizing)
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            return scaledImage;
        }
    }
}
