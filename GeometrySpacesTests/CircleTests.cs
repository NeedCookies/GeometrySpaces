using GeometrySpaces.Core;

namespace GeometrySpacesTests
{
    public class CircleTests
    {
        [Fact]
        public void GetSquare_ValidRadius_ReturnsCorrectAnswer()
        {
            // Arrange
            var radius = 5.0;
            var circle = new Circle(radius);
            var expectedSquare = Math.PI * radius * radius;

            // Act
            var actualResult = circle.GetSquare();

            // Assert
            Assert.Equal(expectedSquare, actualResult);
        }

        [Fact]
        public void GetSquare_NegativeRadius_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-5.0));
        }

        [Fact]
        public void Circle_ZeroRadius_ReturnsZeroSquare()
        {
            // Arrange
            var circle = new Circle(0);

            // Act
            var square = circle.GetSquare();

            // Assert
            Assert.Equal(0, square);
        }
    }
}