//using System;
//using System.Collections.Generic;
//using Xunit;
//using System.Text;

//namespace EcoSystem.Test
//{
//    public class OceanTest
//    {
//        [Fact]
//        public void CreateFishTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point testPoint = new Point { X = 5, Y = 5 };
//            //Act
//            ocean.CreateFish(testPoint);
//            //Assert
//            Assert.Equal<char>('F', ocean[5, 5].Icon);
//        }
//        [Fact]
//        public void CreateSharkTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point testPoint = new Point { X = 5, Y = 5 };
//            //Act
//            ocean.CreateShark(testPoint);
//            //Assert
//            Assert.Equal<char>('S', ocean[5, 5].Icon);
//        }
//        [Fact]
//        public void CreateBlockTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point testPoint = new Point { X = 5, Y = 5 };
//            //Act
//            ocean.CreateBlock(testPoint);
//            //Assert
//            Assert.Equal<char>('#', ocean[5, 5].Icon);
//        }
//        [Fact]
//        public void isCellTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point fishPoint = new Point { X = 5, Y = 5 };
//            Point sharkPoint = new Point { X = 7, Y = 7 };
//            Point blockPoint = new Point { X = 6, Y = 6 };
//            Point cellPoint = new Point { X = 10, Y = 10 };
//            //Act
//            ocean.CreateFish(fishPoint);
//            ocean.CreateBlock(blockPoint);
//            ocean.CreateShark(sharkPoint);
//            //Assert
//            Assert.False(ocean.isCell(fishPoint));
//            Assert.False(ocean.isCell(blockPoint));
//            Assert.False(ocean.isCell(sharkPoint));
//            Assert.True(ocean.isCell(cellPoint));
//        }

//        [Fact]
//        public void isFishTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point fishPoint = new Point { X = 5, Y = 5 };
//            Point sharkPoint = new Point { X = 7, Y = 7 };
//            Point blockPoint = new Point { X = 6, Y = 6 };
//            Point cellPoint = new Point { X = 10, Y = 10 };
//            //Act
//            ocean.CreateFish(fishPoint);
//            ocean.CreateBlock(blockPoint);
//            ocean.CreateShark(sharkPoint);
//            //Assert
//            Assert.True(ocean.isFish(fishPoint));
//            Assert.False(ocean.isFish(blockPoint));
//            Assert.False(ocean.isFish(sharkPoint));
//            Assert.False(ocean.isFish(cellPoint));
//        }

//        [Fact]
//        public void isSharkTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point fishPoint = new Point { X = 5, Y = 5 };
//            Point sharkPoint = new Point { X = 7, Y = 7 };
//            Point blockPoint = new Point { X = 6, Y = 6 };
//            Point cellPoint = new Point { X = 10, Y = 10 };
//            //Act
//            ocean.CreateFish(fishPoint);
//            ocean.CreateShark(sharkPoint);
//            ocean.CreateBlock(blockPoint);
//            //Assert
//            Assert.False(ocean.isShark(fishPoint));
//            Assert.False(ocean.isShark(blockPoint));
//            Assert.True(ocean.isShark(sharkPoint));
//            Assert.False(ocean.isShark(cellPoint));
//        }

//        [Fact]
//        public void isBlockTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point fishPoint = new Point { X = 5, Y = 5 };
//            Point sharkPoint = new Point { X = 7, Y = 7 };
//            Point blockPoint = new Point { X = 6, Y = 6 };
//            Point cellPoint = new Point { X = 10, Y = 10 };
//            //Act
//            ocean.CreateFish(fishPoint);
//            ocean.CreateShark(sharkPoint);
//            ocean.CreateBlock(blockPoint);
//            //Assert
//            Assert.False(ocean.isBlock(fishPoint));
//            Assert.True(ocean.isBlock(blockPoint));
//            Assert.False(ocean.isBlock(sharkPoint));
//            Assert.False(ocean.isBlock(cellPoint));
//        }

//        [Fact]
//        public void KillCellTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();
//            Point fishPoint = new Point { X = 5, Y = 5 };
//            Point sharkPoint = new Point { X = 7, Y = 7 };
//            Point blockPoint = new Point { X = 6, Y = 6 };

//            //Act
//            ocean.CreateFish(fishPoint);
//            ocean.CreateBlock(blockPoint);
//            ocean.CreateShark(sharkPoint);
//            ocean.KillCell(fishPoint);
//            ocean.KillCell(blockPoint);
//            ocean.KillCell(sharkPoint);

//            //Assert
//            Assert.True(ocean.isCell(fishPoint));
//            Assert.True(ocean.isCell(blockPoint));
//            Assert.True(ocean.isCell(sharkPoint));

//        }

//        [Fact]
//        public void SwopCellTest()
//        {
//            //Arrange
//            Ocean ocean = new Ocean();

//            //Act
//            ocean.CreateFish(new Point { X = 5, Y = 10 });
//            ocean.CreateShark(new Point { X = 6, Y = 10 });

//            //Assert
//            Assert.Equal<char>('F', ocean[5, 10].Icon);
//            Assert.Equal<char>('S', ocean[6, 10].Icon);

//            for (int i = 0; i < ocean.Width - 1; i++)
//            {
//                for (int j = 0; j < ocean.Hight - 1; j++)
//                {
//                    if(ocean[i, j] != null)
//                    {
//                        Assert.Equal<Point>(new Point { X = i, Y = j }, ocean[i, j].Position);
//                    }
//                }
//            }

//            //Act2
//            ocean.SwopCell(new Point { X = 5, Y = 10 }, new Point { X = 6, Y = 10 });

//            //Assert2
//            Assert.Equal<char>('S', ocean[5, 10].Icon);
//            Assert.Equal<char>('F', ocean[6, 10].Icon);

//            for (int i = 0; i < ocean.Width - 1; i++)
//            {
//                for (int j = 0; j < ocean.Hight - 1; j++)
//                {
//                    if (ocean[i, j] != null)
//                    {
//                        Assert.Equal<Point>(new Point { X = i, Y = j }, ocean[i, j].Position);
//                    }
//                }
//            }

//        }
//    }
//}
