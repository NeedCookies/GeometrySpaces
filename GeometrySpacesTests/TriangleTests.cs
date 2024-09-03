using GeometrySpaces.Core;

namespace GeometrySpacesTests
{
    public class TriangleTests
    {
        [Fact]
        public void GetSquare_ValidSides_ReturnsCorrectSquare()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);
            var expectedSquare = 6.0;

            // Act
            var actualSquare = triangle.GetSquare();

            // Assert
            Assert.Equal(expectedSquare, actualSquare, 5);
        }

        [Fact]
        public void Triangle_NegativeSide_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Triangle(-3, 4, 5));
        }

        [Fact]
        public void Triangle_InvalidSides_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 10));
        }

        [Fact]
        public void GetSquare_ZeroSide_ReturnsZeroSquare()
        {
            // Arrange
            var triangle = new Triangle(0, 4, 5);

            // Act
            var square = triangle.GetSquare();

            // Assert
            Assert.Equal(0, square);
        }

        [Theory]
        [InlineData(3, 4, 5, true)]  // Прямоугольный треугольник
        [InlineData(6, 8, 10, true)] // Прямоугольный треугольник
        [InlineData(5, 5, 5, false)] // Не прямоугольный треугольник
        public void IsRightTriangle_ValidSides_ReturnsCorrectResult(double sideA, double sideB, double sideC, bool expected)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var isRight = triangle.IsRightTriangle();

            // Assert
            Assert.Equal(expected, isRight);
        }

        [Theory]
        [InlineData(3, 4, 5, 6.0)]   // Прямоугольный треугольник
        [InlineData(5, 12, 13, 30.0)] // Прямоугольный треугольник
        [InlineData(6, 8, 10, 24.0)]  // Прямоугольный треугольник
        public void GetSquare_RightTriangle_ReturnsCorrectSquare(double sideA, double sideB, double sideC, double expectedSquare)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var actualSquare = triangle.GetSquare();

            // Assert
            Assert.Equal(expectedSquare, actualSquare, 5);
        }
    }
}
