namespace ClassBoxData
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0) throw new ArgumentException(string.Format(MessageException
                    .THE_NUMBER_CANNOT_BE_ZERO_AND_NEGATIVE, nameof(this.Length)));

                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0) throw new ArgumentException(string.Format(MessageException
                    .THE_NUMBER_CANNOT_BE_ZERO_AND_NEGATIVE, nameof(this.Width)));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0) throw new ArgumentException(string.Format(MessageException
                    .THE_NUMBER_CANNOT_BE_ZERO_AND_NEGATIVE, nameof(this.Height)));
                this.height = value;
            }

        }
        public double SurfaceArea() => LateralSurfaceArea() + 2 * this.Length * this.Width;

        public double LateralSurfaceArea() => 2 * this.Height * (this.Length + this.Width);

        public double Volume() => this.Length * this.Width * this.Height;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().TrimEnd();
        }

    }
}
