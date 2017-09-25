using System;
using NUnit.Framework;
using ConsoleDisplayExperiment.inputTransformer;

namespace Tests
{
    [TestFixture]
    public class BoxDrawingTransformerTests
    {
        [Test]
        public void Transform_GivenInput_ReturnsNotNull()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = {"  ",
                             "  "};

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void Transform_GivenHorizontalSection_ReturnsBar()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = {"##"};
            string[] expected = { "══" };

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected[0], result[0]);
        }

        [Test]
        public void Transform_GivenVerticalSection_ReturnsBar()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = { "#", "#" };
            string expected = "║" ;

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected, result[0]);
        }

        [Test]
        public void Transform_GivenTopLeftCornerSection_ReturnsCorner()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = { "##",
                              "# "};
            char expected = '╔';

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected, result[0][0]);
        }

        [Test]
        public void Transform_GivenTopRightCornerSection_ReturnsCorner()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = { "##",
                              " #"};
            char expected = '╗';

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected, result[0][1]);
        }

        [Test]
        public void Transform_GivenBottomRightCornerSection_ReturnsCorner()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = { " #",
                              "##"};
            char expected = '╝';

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected, result[1][1]);
        }

        [Test]
        public void Transform_GivenBottomLeftCornerSection_ReturnsCorner()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = { "# ",
                              "##"};
            char expected = '╚';

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected, result[1][0]);
        }

        [Test]
        public void Transform_GivenVerticalRightTeeSection_ReturnsTee()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = { "# ",
                              "##",
                              "# "};
            char expected = '╠';

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected, result[1][0]);
        }

        [Test]
        public void Transform_GivenVerticalLeftTeeSection_ReturnsTee()
        {
            //Arrange
            var sut = new BoxDrawingTransformer();
            string[] test = { " # ",
                              "## ",
                              " # "};
            char expected = '╣';

            //Act
            var result = sut.Transform(test);

            //Assert
            Assert.AreEqual(expected, result[1][1]);
        }


    }
}
