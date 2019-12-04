using System;
using System.Collections.Generic;
using Xunit;
using System.Text;

namespace EcoSystem.Test
{
    public class OceanTest
    {
        [Fact]
        public void CreateFishTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            //Act
            ocean.CreateFish(new Point { X = 5, Y = 5 });
            //Assert
            Assert.Equal<char>('F', ocean.Cells[5, 5].Icon);
        }
        [Fact]
        public void CreateSharkTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            //Act
            ocean.CreateShark(new Point { X = 5, Y = 5 });
            //Assert
            Assert.Equal<char>('S', ocean.Cells[5, 5].Icon);
        }
        [Fact]
        public void CreateBlockTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            //Act
            ocean.CreateBlock(new Point { X = 5, Y = 5 });
            //Assert
            Assert.Equal<char>('#', ocean.Cells[5, 5].Icon);
        }
        [Fact]
        public void isCellTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            //Act
            ocean.CreateFish(new Point { X = 5, Y = 5 });
            ocean.CreateBlock(new Point { X = 6, Y = 6 });
            ocean.CreateShark(new Point { X = 7, Y = 7 });
            //Assert
            Assert.False(ocean.isCell(new Point { X = 5, Y = 5 }));
            Assert.False(ocean.isCell(new Point { X = 6, Y = 6 }));
            Assert.False(ocean.isCell(new Point { X = 7, Y = 7 }));
            Assert.True(ocean.isCell(new Point { X = 10, Y = 10 }));
        }

        [Fact]
        public void isFishTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            //Act
            ocean.CreateFish(new Point { X = 5, Y = 5 });
            ocean.CreateBlock(new Point { X = 6, Y = 6 });
            ocean.CreateShark(new Point { X = 7, Y = 7 });
            //Assert
            Assert.True(ocean.isFish(new Point { X = 5, Y = 5 }));
            Assert.False(ocean.isFish(new Point { X = 6, Y = 6 }));
            Assert.False(ocean.isFish(new Point { X = 7, Y = 7 }));
            Assert.False(ocean.isFish(new Point { X = 10, Y = 10 }));
        }

        [Fact]
        public void isSharkTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            //Act
            ocean.CreateFish(new Point { X = 5, Y = 5 });
            ocean.CreateBlock(new Point { X = 6, Y = 6 });
            ocean.CreateShark(new Point { X = 7, Y = 7 });
            //Assert
            Assert.False(ocean.isShark(new Point { X = 5, Y = 5 }));
            Assert.False(ocean.isShark(new Point { X = 6, Y = 6 }));
            Assert.True(ocean.isShark(new Point { X = 7, Y = 7 }));
            Assert.False(ocean.isShark(new Point { X = 10, Y = 10 }));
        }

        [Fact]
        public void isBlockTest()
        {
            //Arrange
            Ocean ocean = new Ocean();
            //Act
            ocean.CreateFish(new Point { X = 5, Y = 5 });
            ocean.CreateBlock(new Point { X = 6, Y = 6 });
            ocean.CreateShark(new Point { X = 7, Y = 7 });
            //Assert
            Assert.False(ocean.isBlock(new Point { X = 5, Y = 5 }));
            Assert.True(ocean.isBlock(new Point { X = 6, Y = 6 }));
            Assert.False(ocean.isBlock(new Point { X = 7, Y = 7 }));
            Assert.False(ocean.isBlock(new Point { X = 10, Y = 10 }));
        }

        [Fact]
        public void KillCellTest()
        {
            //Arrange
            Ocean ocean = new Ocean();

            //Act
            ocean.CreateFish(new Point { X = 5, Y = 5 });
            ocean.CreateBlock(new Point { X = 6, Y = 6 });
            ocean.CreateShark(new Point { X = 7, Y = 7 });
            ocean.KillCell(new Point { X = 5, Y = 5 });
            ocean.KillCell(new Point { X = 6, Y = 6 });
            ocean.KillCell(new Point { X = 7, Y = 7 });

            //Assert
            Assert.True(ocean.isCell(new Point { X = 5, Y = 5 }));
            Assert.True(ocean.isCell(new Point { X = 6, Y = 6 }));
            Assert.True(ocean.isCell(new Point { X = 7, Y = 7 }));

        }

        [Fact]
        public void SwopCellTest()
        {
            //Arrange
            Ocean ocean = new Ocean();

            //Act
            ocean.CreateFish(new Point { X = 5, Y = 10 });
            ocean.CreateShark(new Point { X = 6, Y = 10 });

            //Assert
            Assert.Equal<char>('F',ocean.Cells[5,10].Icon);
            Assert.Equal<char>('S',ocean.Cells[6,10].Icon);

            for (int i = 0; i < ocean.Width - 1; i++)
            {
                for (int j = 0; j < ocean.Hight - 1; j++)
                {
                    Assert.Equal<Point>(new Point {X = i,Y = j },ocean.Cells[i, j].Position);
                }
            }

            //Act2
            ocean.SwopCell(new Point { X = 5, Y = 10 }, new Point { X = 6, Y = 10 });

            //Assert2
            Assert.Equal<char>('S', ocean.Cells[5, 10].Icon);
            Assert.Equal<char>('F', ocean.Cells[6, 10].Icon);

            for (int i = 0; i < ocean.Width - 1; i++)
            {
                for (int j = 0; j < ocean.Hight - 1; j++)
                {
                    Assert.Equal<Point>(new Point { X = i, Y = j }, ocean.Cells[i, j].Position);
                }
            }

        }
    }
}
