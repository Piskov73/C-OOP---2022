using System;
using System.Text;

namespace _01ClassBoxData
{
    public class Box
    {

        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.CANNOT_ZERO_NEGATIVE_NUMBER, nameof(Height)));
                }
                height = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.CANNOT_ZERO_NEGATIVE_NUMBER, nameof(this.Width)));
                }
                width = value;
            }
        }


        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.CANNOT_ZERO_NEGATIVE_NUMBER, nameof(this.Length)));
                }
                length = value;
            }
        }
        public double LateralSurfaceArea()
        {
            return 2 * (this.Length + this.Width) * this.Height;
        }
        public double SurfaceArea()
        {
            return this.LateralSurfaceArea() + 2 * this.Length * this.Width;
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
        public override string ToString()
        {
        
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.Volume():f2}");
            return sb.ToString().TrimEnd();
        }



    }
}
