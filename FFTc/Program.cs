﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                foreach (var picture in args)
                {
                    var processInfo = new ProcessStartInfo
                    {
                        UseShellExecute = false, // change value to false
                        FileName = "FFTc.exe",
                        Arguments = picture 
                    };


                    Console.WriteLine("Starting process for " + "\\img\\" + picture + ".bmp");
                    Process.Start(processInfo);                   
                }
            }
            else if(args.Length == 1)
            {
                Bitmap image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() +"\\img\\" + args[0] + ".bmp");

                ComplexImage complexImage = ComplexImage.FromBitmap(image);

                Stopwatch stopwatch = Stopwatch.StartNew();
                complexImage.ForwardFourierTransform(7);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);

                


                Bitmap fourierImage = complexImage.ToBitmap();
              //  Console.WriteLine(System.IO.Directory.GetCurrentDirectory() + "\\img\\"+ args[0] + "fourier.bmp");
                fourierImage.Save(System.IO.Directory.GetCurrentDirectory() + "\\img\\"+ args[0] + "fourier.bmp");


                Stopwatch stopwatch2 = Stopwatch.StartNew();
                // ComplexImage backward = ComplexImage.FromBitmap(fourierImage);
                complexImage.BackwardFourierTransform(7);
                stopwatch2.Stop();
                Console.WriteLine(stopwatch2.ElapsedMilliseconds);

                Bitmap backwardFourier = complexImage.ToBitmap();

                backwardFourier.Save(System.IO.Directory.GetCurrentDirectory() + "\\img\\"+ args[0] +"backwardFourier.bmp");

            }

            Console.ReadLine();






        }
    }
}
