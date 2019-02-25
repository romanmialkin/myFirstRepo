using System;
namespace VectorRotation
{
    public class Orientation
    {

        public double Roll { get; set; }
        public double Pitch { get; set; }
        public double Yaw { get; set; }

        public Orientation(double roll, double pitch, double yaw)
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }

        public override string ToString()
        {
            return $"({Roll}, {Pitch}, {Yaw}";
        }
    }
}
