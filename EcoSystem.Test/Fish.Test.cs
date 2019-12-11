using System;
using System.Collections.Generic;
using Xunit;
using System.Text;

namespace EcoSystem.Test
{
    public class FishTest
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
            ocean.CreateFish(testingPoint);

            foreach (Direction dir in dirs)
            {
                //Arrange
                ocean.CreateFish(testingPoint);

                //Act
                (ocean[testingPoint.X, testingPoint.Y] as Fish).Move(dir);

                //Assert
                Assert.True(ocean.isCell(testingPoint));
                Assert.True(ocean.isFish(testingPoint + dir));
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
            ocean.CreateFish(testingPoint);

            foreach (Direction dir in dirs)
            {
                //Act
                (ocean[testingPoint.X, testingPoint.Y] as Fish).Reproduce(dir);

                //Assert
                Assert.True(ocean.isFish(testingPoint));
                Assert.True(ocean.isFish(testingPoint + dir));
            }

        }

        [Fact]
        public void FishDieTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            Point testingPoint = new Point();
            testingPoint.X = 5;
            testingPoint.Y = 5;
            ocean.CreateFish(testingPoint);

            //Act
            (ocean[testingPoint.X, testingPoint.Y] as Fish).Die();

            //Assert
            Assert.False(ocean.isFish(testingPoint));
        }


    }
}
