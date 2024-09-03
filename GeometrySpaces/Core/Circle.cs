using GeometrySpaces.Core.Abstractions;

namespace GeometrySpaces.Core
{
    /// <summary>
    /// Circle class
    /// </summary>
    public class Circle : IGeometryFigure
    {
        public double Radius {get; set;}

        /// <summary>
        /// Create a circle with given radius. Argument exception if raduis < 0
        /// </summary>
        /// <param name="radius"></param>
        /// <exception cref="ArgumentException"></exception>
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius should have positive number");

            Radius = radius;
        }

        public double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
