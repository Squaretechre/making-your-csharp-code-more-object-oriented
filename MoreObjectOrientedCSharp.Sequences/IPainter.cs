using System;

namespace MoreObjectOrientedCSharp.Sequences
{
    internal interface IPainter
    {
        bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double squareMeters);
        double EstimateCompensation(double squareMeters);
    }
}