using System.Collections.Generic;
using System.Linq;

namespace MoreObjectOrientedCSharp.Sequences
{
    internal class Program
    {
        private static IPainter FindCheapestPainter(double squareMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateCompensation(squareMeters));
        }

        public static void Main(string[] args)
        {
        }
    }
}