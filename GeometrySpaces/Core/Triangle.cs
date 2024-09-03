using GeometrySpaces.Core.Abstractions;

namespace GeometrySpaces.Core
{
    /// <summary>
    /// Triangle class
    /// </summary>
    public class Triangle : IGeometryFigure, ITriangle
    {
        /// <summary>
        /// To do calculations only when we need it
        /// </summary>
        private bool needsRecalculation = true;

        /// <summary>
        /// On of the triangle side, ArgumentException if it less than 0
        /// </summary>
        public double SideA 
        { 
            get { return SideA; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Triangle side should be more >= 0");
                SideA = value;
                UpdateTriangleProps();
            }
        }
        /// <summary>
        /// On of the triangle side, ArgumentException if it less than 0
        /// </summary>
        public double SideB
        {
            get { return SideB; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Triangle side should be more >= 0");
                SideB = value;
                UpdateTriangleProps();
            }
        }
        /// <summary>
        /// On of the triangle side, ArgumentException if it less than 0
        /// </summary>
        public double SideC
        {
            get { return SideC; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Triangle side should be more >= 0");
                SideC = value;
                UpdateTriangleProps();
            }
        }

        /// <summary>
        /// Represents perimeter of the current triangle
        /// </summary>
        public double Perimeter { get; private set; }
        public double Square { get; private set; }

        /// <summary>
        /// Creates new triangle, all sides should be >=0
        /// and it should be possible to build triangle from these sides
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA < 0 || sideB < 0 || sideC < 0)
                throw new ArgumentException("All triangle sides should >= 0");
            if (!IsValidTriangle(sideA, sideB, sideC))
                throw new ArgumentException("The provided sides do not form a valid triangle");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            Perimeter = sideA + sideB + sideC;
            double p = Perimeter / 2;
            Square = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public double GetSquare()
        {
            if (needsRecalculation)
            {
                double p = Perimeter / 2;
                Square = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
                needsRecalculation = false;
            }
            return Square;
        }

        public bool IsRightTriangle()
        {
            var sides = new[] { SideA, SideB, SideC };
            Array.Sort(sides);
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 0.0;
        }

        private void UpdateTriangleProps()
        {
            Perimeter = SideA + SideB + SideC;
            needsRecalculation = true;
        }

        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
