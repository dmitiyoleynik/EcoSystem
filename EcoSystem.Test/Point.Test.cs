using System;
using System.Collections.Generic;
using System.Text;
using EcoSystem;
using Xunit;

namespace EcoSystem.Test
{
    public class PointTest
    {
        [Fact]
        public void TestAdditionDirectionToPointUP()
        {
            //Arrange
            Point p = new Point { X = 5, Y = 5 };
            Point newP;
            Direction d = Direction.Up;

            //Act
            newP = p + d;

            //Assert
            Assert.Equal<Point>(p, new Point { X = 5, Y = 5 });
            Assert.Equal<Point>(newP, new Point { X = 5, Y = 5 - 1 });
        }
        [Fact]
        public void TestAdditionDirectionToPointDOWN()
        {
            //Arrange
            Point p = new Point { X = 5, Y = 5 };
            Point newP;
            Direction d = Direction.Down;

            //Act
            newP = p + d;
            //Assert
            Assert.Equal<Point>(p, new Point { X = 5, Y = 5 });
            Assert.Equal<Point>(newP, new Point { X = 5, Y = 5 + 1 });
        }
        [Fact]
        public void TestAdditionDirectionToPointLEFT()
        {
            //Arrange
            Point p = new Point { X = 5, Y = 5 };
            Point newP;
            Direction d = Direction.Left;

            //Act
            newP = p + d;
            //Assert
            Assert.Equal<Point>(p, new Point { X = 5, Y = 5 });
            Assert.Equal<Point>(newP, new Point { X = 5 - 1, Y = 5 });
        }
        [Fact]
        public void TestAdditionDirectionToPointRIGHT()
        {
            //Arrange
            Point p = new Point { X = 5, Y = 5 };
            Point newP;
            Direction d = Direction.Right;

            //Act
            newP = p + d;
            //Assert
            Assert.Equal<Point>(p, new Point { X = 5, Y = 5 });
            Assert.Equal<Point>(newP, new Point { X = 5 + 1, Y = 5 });
        }
    }
}
