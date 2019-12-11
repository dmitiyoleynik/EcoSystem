using System;
using System.Collections.Generic;
using Xunit;
using System.Text;

namespace EcoSystem.Test
{
    public class SharkTest
    {
        [Fact]
        public void MoveTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            Direction[] dirs = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
            Point testingPoint = new Point();
            testingPoint.X = 5;
            testingPoint.Y = 5;

            foreach (Direction dir in dirs)
            {
                //Arrange
                ocean.CreateShark(testingPoint);

                //Act
                (ocean[testingPoint.X, testingPoint.Y] as Shark).Move(dir);

                //Assert
                Assert.True(ocean.isCell(testingPoint));
                Assert.True(ocean.isShark(testingPoint + dir));
            }


        }

        [Fact]
        public void ReproduceTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            Direction[] dirs = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
            Point testingPoint = new Point();
            testingPoint.X = 5;
            testingPoint.Y = 5;
            ocean.CreateShark(testingPoint);

            foreach (Direction dir in dirs)
            {
                //Act
                (ocean[testingPoint.X, testingPoint.Y] as Shark).Reproduce(dir);

                //Assert
                Assert.True(ocean.isShark(testingPoint));
                Assert.True(ocean.isShark(testingPoint + dir));
            }

        }
        [Fact]
        public void SharkDieTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            Point testingPoint = new Point();
            testingPoint.X = 5;
            testingPoint.Y = 5;
            ocean.CreateShark(testingPoint);

            //Act
            (ocean[testingPoint.X, testingPoint.Y] as Shark).Die();

            //Assert
            Assert.False(ocean.isShark(testingPoint));
        }
        [Fact]
        public void EatFishTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            Point testingPoint = new Point();
            Direction dir = Direction.Down;
            testingPoint.X = 5;
            testingPoint.Y = 5;
            ocean.CreateShark(testingPoint);
            ocean.CreateFish(testingPoint+dir);

            //Act
            (ocean[testingPoint.X, testingPoint.Y] as Shark).EatFish(dir);

            //Assert
            Assert.True(ocean.isCell(testingPoint));
            Assert.True(ocean.isShark(testingPoint+dir));

        }

    }
}
