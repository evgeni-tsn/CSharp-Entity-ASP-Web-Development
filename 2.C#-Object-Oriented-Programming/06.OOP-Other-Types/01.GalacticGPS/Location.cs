using System;

namespace _01.GalacticGPS
{
    public struct Location
    {
        private const int LatitudeMin = -90;
        private const int LatitudeMax = 90;
        private const int LongitudeMin = -180;
        private const int LongitudeMax = 180;
        private readonly Planet planet;
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet)
            :this()
        {
            this.planet = planet;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                if(value < LatitudeMin || value > LatitudeMax)
                {
                    throw new ArgumentException($"Latitude must be in range {LatitudeMin} - {LatitudeMax}");
                }
                this.latitude = value;
            }
        }
        public double Longitude {
            get { return this.longitude; }
            set
            {
                if (value < LongitudeMin || value > LongitudeMax)
                {
                    throw new ArgumentException($"Longitude must be in range {LongitudeMin} - {LongitudeMax}");
                }
                this.longitude = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"{this.Latitude}, {this.Longitude} - {this.planet}");
        }
    }
}