using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

// Quelle: https://github.com/shimat/opencvsharp
using OpenCvSharp;

namespace csharpOpenCV_TemplateMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double minWert, maxWert;
            Point minPosition, maxPosition;
            
            var Leinwand = new Mat(@"C:\Users\patri\source\repos\csharpOpenCV_TemplateMatching\csharpOpenCV_TemplateMatching\waldo-grossesbild.jpg", ImreadModes.Color);
            var Gesicht = new Mat(@"C:\Users\patri\source\repos\csharpOpenCV_TemplateMatching\csharpOpenCV_TemplateMatching\waldo-gesicht.jpg", ImreadModes.Color);

            var result = Leinwand.MatchTemplate(Gesicht, TemplateMatchModes.CCoeffNormed);

            result.MinMaxLoc(out minWert, out maxWert, out minPosition, out maxPosition);

            var obenlinks = maxPosition;
            Point untenrechts = new Point(obenlinks.X + Gesicht.Width, obenlinks.Y + Gesicht.Height);

            Cv2.Rectangle(Leinwand, obenlinks, untenrechts, Scalar.Red, 2);
            Cv2.ImWrite("result.png", Leinwand);

            Console.WriteLine("Oben-Links: {0}, Unten-Rechts: {1}", obenlinks, untenrechts);
            Console.ReadKey();
        }
    }
}
