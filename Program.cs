using System;
using System.Collections.Generic;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // Bingo Numbers!
            List<int> line1 = new List<int>() { 2, 15, 32, 46, 61};
            List<int> line2 = new List<int>() { 3, 17, 35, 48, 70};
            List<int> line3 = new List<int>() { 4, 20, -1, 50, 71};
            List<int> line4 = new List<int>() { 7, 21, 40, 51, 72};
            List<int> line5 = new List<int>() { 9, 30, 42, 55, 75};

            // Create list of list
            List<List<int>> lines = new List<List<int>>();
            lines.Add(line1);
            lines.Add(line2);
            lines.Add(line3);
            lines.Add(line4);
            lines.Add(line5);

            // Initialise a few variables
            BingoNode currentBingoNode = new BingoNode();
            BingoNode firstBingoNode = new BingoNode();


            for (int i = 0; i < lines.Count; i++)
            {
                List<int> line = lines[i];
                currentBingoNode = firstBingoNode;
                   
                foreach (int j in line)
                {
                    //If it's the first number the start the list
                    if (currentBingoNode.Number == 0)
                    {
                        currentBingoNode.Number = j;
                        currentBingoNode.X = 1;
                        currentBingoNode.Y = 1;
                        firstBingoNode = currentBingoNode;
                    }
                    //Else check if we need to move down a row
                    else if (currentBingoNode.Y != i+1)
                    {
                        currentBingoNode = firstBingoNode;
                        while (currentBingoNode.Y < i) 
                        {
                            currentBingoNode = currentBingoNode.BingoNodeDown;
                        } 
                        currentBingoNode.CreateBingoNodeDown(j);
                        currentBingoNode = currentBingoNode.BingoNodeDown;
                    }
                    else
                    {
                        currentBingoNode.CreateBingoNodeRight(j);
                        currentBingoNode = currentBingoNode.BingoNodeRight;
                    }
                }
            }

            //Transpose the list of bingo numbers to create the rest of the links (all the down/up ones)
            List<List<int>> transposeLines = new List<List<int>>();
            for (int i = 0; i < lines.Count; i++)
            {
                List<int> transposeLine = new List<int>();
                transposeLine.Add(line1[i]);
                transposeLine.Add(line2[i]);
                transposeLine.Add(line3[i]);
                transposeLine.Add(line4[i]);
                transposeLine.Add(line5[i]);

                transposeLines.Add(transposeLine);
            }

            for (int i = 0; i < transposeLines.Count; i++)
            {
                List<int> line = transposeLines[i];
                currentBingoNode = firstBingoNode.FindBingoNode(line[0]);
                   
                for (int j = 0; j < line.Count-1; j++)    
                {
                    int number = line[j];
                    if (number != currentBingoNode.Number)
                    {
                        currentBingoNode.SetBingoNodeDown(firstBingoNode.FindBingoNode(number));
                        currentBingoNode = currentBingoNode.BingoNodeDown;
                    }
                }            
            }

            Console.WriteLine("Input numbers!");
            //NOW THE BOARD IS CREATED
            while (true)
            {
                string input = Console.ReadLine();
                int inputInt;

                //If integer, call the number on our bingo sheet
                if (int.TryParse(input, out inputInt))
                {
                    BingoNode checkBingoNode = firstBingoNode.FindBingoNode(inputInt);
                    if (checkBingoNode != null)
                    {
                        checkBingoNode.Called = true;
                        Console.WriteLine(string.Format("Number {0} successfully called"), inputInt);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Number {0} not found"), inputInt);
                    }
                }
                else if (input == "esc")
                {
                    Console.WriteLine("Ending loop");
                    break;
                }
                else
                {
                    Console.WriteLine(string.Format("Input '{0}' not recognised", input));
                }
            }

            
            currentBingoNode = firstBingoNode;
            do {
                string output = String.Format("{0} ({1},{2}), {3}", currentBingoNode.Number,
                    currentBingoNode.X, currentBingoNode.Y, currentBingoNode.Called ? "Called" : "Not Called");
                Console.WriteLine(output);

                if (currentBingoNode.BingoNodeRight != null)
                {
                    currentBingoNode = currentBingoNode.BingoNodeRight;      
                }
                else
                {
                    currentBingoNode = firstBingoNode.BingoNodeDown;
                    firstBingoNode = currentBingoNode;
                }          
            } while (currentBingoNode != null);


            /*
            BingoSheet bingoSheet = new BingoSheet(5, 5);

            //Free space
            BingoNumber freeSpace = new BingoNumber(3, 3, -1);
            bingoSheet.AddBingoNumber(freeSpace);
            bingoSheet.CallBingoNumber(freeSpace);


            BingoNumber test1 = new BingoNumber(1, 1, 15);
            BingoNumber test2 = new BingoNumber(1, 2, 13);
            BingoNumber test3 = new BingoNumber(1, 3, 10);
            BingoNumber test4 = new BingoNumber(1, 4, 22);
            BingoNumber test5 = new BingoNumber(1, 5, 26);

            bingoSheet.AddBingoNumber(test1);
            bingoSheet.AddBingoNumber(test2);
            bingoSheet.AddBingoNumber(test3);
            bingoSheet.AddBingoNumber(test4);
            bingoSheet.AddBingoNumber(test5);

            bingoSheet.CallBingoNumber(15);
            bingoSheet.CallBingoNumber(12);
            bingoSheet.CallBingoNumber(13);
            bingoSheet.CallBingoNumber(10);
            bingoSheet.CallBingoNumber(22);
            bingoSheet.CallBingoNumber(26);

            bingoSheet.PrintBingoSheet();
            string bingoWon = bingoSheet.CheckBingoSheet() ? "Won!" : "Not Yet";
            Console.WriteLine(bingoWon);
            */

        }
    }
}
