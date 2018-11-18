using System;

namespace Lab2
{
    internal class Position
    {
        //Props
        private double x;

        public double X
        {
            get => x;

            set
            {
                if (value <= 0)
                {
                    x = 0;
                }
                else
                {
                    x = value;
                }
            }
        }

        private double y;

        public double Y {
            get => y;

            set {
                if (value <= 0) {
                    y = 0;
                }
                else {
                    y = value;
                }
            }
        }


        // Contructor
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }


        // Methods
        public double Length() 
        {
            return Math.Sqrt((X * X) + (Y * Y));
        }

        public bool Equals(Position p) 
        {
            if (p.X == X && p.Y == Y)
            {
                return true;
            }
            return false;
        }

        public Position Clone() 
        {
            return new Position(X, Y);
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

        public static bool operator > (Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            return false;
        }

        public static bool operator < (Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }
            return false;
        }

        public static Position operator + (Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Position operator - (Position p1, Position p2)
        {
            return new Position(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Position operator * (Position p1, Position p2)
        {
            return new Position(p1.X * p2.X, p1.Y * p2.Y);
        }

        public static Position operator / (Position p1, Position p2)
        {
            return new Position(p1.X / p2.X, p1.Y / p2.Y);
        }

        public static double operator % (Position p1, Position p2)
        {
            double tempX = Convert.ToDouble(Math.Pow((float)(p1.X - p2.X), 2));
            double tempY = Convert.ToDouble(Math.Pow((float)(p1.X - p2.X), 2));
            return Math.Sqrt(tempX + tempY);
        }
    }
}