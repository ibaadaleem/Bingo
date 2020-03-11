using System;
using System.Linq;
using System.Collections.Generic;
/*

namespace Bingo
{

    public class BingoNumber
    {
        public int X_Coordinate {get;}
        public int Y_Coordinate {get;}
        public int Value {get;}
        public Boolean Called {get;set;}

        public BingoNumber(int x_coordinate, int y_coordinate, int value)
        {
            this.X_Coordinate = x_coordinate;
            this.Y_Coordinate = y_coordinate;
            this.Value = value;
            this.Called = false;
        }

        public void CallNumber()
        {
            this.Called = true;
        }

        public Boolean CheckIfNumberCalled()
        {
            return this.Called;
        }
    }

    public class BingoSheet
    {
        public List<BingoNumber> BingoNumbers {get;set;}
        public int Width {get;}
        public int Height {get;}
        
        private BingoSheet()
        {
            this.BingoNumbers = new List<BingoNumber>();
        }
        public BingoSheet(int width, int height) : this()
        {
            this.Width = width;
            this.Height = height;
        }

        public void AddBingoNumber(BingoNumber bingoNumber)
        {
            //todo check number not already in list
            this.BingoNumbers.Add(bingoNumber);
            Console.WriteLine(string.Format("{0} has been added to bingo sheet", bingoNumber.Value));
        }

        public void AddBingoNumberRightLeftTopDown(string numbers)
        {
            List<string> numbersList = numbers.Split(',').ToList();

            int i = 0;
            int j = 0;
            foreach (string numberString in numbersList)
            {
                if (i >= this.Width)
                {
                    i = 1;
                }
                else
                {
                    i++;
                }
                if (j >= this.Width)
                {
                    j = 1;
                }
                else
                {
                    j++;
                }

                int number = int.Parse(numberString);
                BingoNumber bingoNumber = new BingoNumber(i, j, number);
                AddBingoNumber(bingoNumber);
            }
        }

        public void CallBingoNumber(int newBingoNumber)
        {
            foreach(BingoNumber bingoNumber in BingoNumbers)
            {
                if (bingoNumber.Value == newBingoNumber)
                {
                    bingoNumber.CallNumber();
                    Console.WriteLine(string.Format("{0} called, has been updated", newBingoNumber));
                    return;
                }
            }

            //If not found on bingo sheet
            Console.WriteLine(string.Format("{0} called, not on bingo sheet", newBingoNumber));
        }

        public void CallBingoNumber(BingoNumber bingoNumber)
        {
            this.CallBingoNumber(bingoNumber.Value);
        }

        public void PrintBingoSheet()
        {
            foreach(BingoNumber bingoNumber in BingoNumbers)
            {
                string called = bingoNumber.CheckIfNumberCalled() ? "Called" : "NotCalled";
                Console.WriteLine(string.Format("{0} {1}",bingoNumber.Value, called));
            }
        }

        public Boolean CheckBingoSheet()
        {
            //Check if any full row or column has been completed
            Dictionary<int, int> RowDict = new Dictionary<int, int>();
            Dictionary<int, int> ColDict = new Dictionary<int, int>();
            for(int i=1; i<= this.Width; i++)
            {
                RowDict.Add(i, 0);
            }
            for(int i=1; i<= this.Height; i++)
            {
                ColDict.Add(i, 0);
            }            

            foreach(BingoNumber bingoNumber in BingoNumbers)
            {
                if (bingoNumber.CheckIfNumberCalled())
                {
                    RowDict[bingoNumber.X_Coordinate]++;
                    ColDict[bingoNumber.Y_Coordinate]++;

                    if (RowDict[bingoNumber.X_Coordinate] == this.Width || ColDict[bingoNumber.Y_Coordinate] == this.Height)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }    
}




*/