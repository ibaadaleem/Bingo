


namespace Bingo
{
    public class BingoNode
    {
        public int X {get;set;}
        public int Y {get;set;}
        public int Number {get;set;}
        public bool Called {get;set;}
        public BingoNode BingoNodeRight {get;set;}
        private BingoNode BingoNodeLeft {get;set;}
        public BingoNode BingoNodeDown {get;set;}
        private BingoNode BingoNodeUp {get;set;}


        private BingoNode CreateBingoNode(int Number)
        {
            BingoNode bingoNode = new BingoNode();
            bingoNode.Number = Number;
            bingoNode.Called = Number == -1 ? true : false;

            return bingoNode;
        }
        public void SetBingoNodeRight(BingoNode bingoNode)
        {
            this.BingoNodeRight = bingoNode;
            this.BingoNodeRight.X = this.X + 1;
            this.BingoNodeRight.Y = this.Y;
            this.BingoNodeRight.BingoNodeLeft = this;
        }

        public void SetBingoNodeDown(BingoNode bingoNode)
        {
            this.BingoNodeDown = bingoNode;
            this.BingoNodeDown.X = this.X;
            this.BingoNodeDown.Y = this.Y + 1;
            this.BingoNodeDown.BingoNodeUp = this;
        }

        public void CreateBingoNodeRight(int number)
        {
            BingoNode bingoNode = CreateBingoNode(number);
            this.SetBingoNodeRight(bingoNode);
        }

        public void CreateBingoNodeDown(int number)
        {
            BingoNode bingoNode = CreateBingoNode(number);
            this.SetBingoNodeDown(bingoNode);
        }


      public BingoNode FindBingoNode (int numberToFind)
        {
            //method only goes right to down, it won't check left or up so not fully comprehensive
            BingoNode startingBingoNode = this;
            BingoNode currentBingoNode = startingBingoNode;

            do {
                //Check if starting number is the desired number
                if (currentBingoNode.Number == numberToFind)
                {
                    return currentBingoNode;
                }
                //If not found, move right if we can
                else if (currentBingoNode.BingoNodeRight != null)
                {
                    currentBingoNode = currentBingoNode.BingoNodeRight;
                }
                //Otherwise move to the next row down, and reset back to the left
                else
                {
                    currentBingoNode = startingBingoNode.BingoNodeDown;
                    startingBingoNode = currentBingoNode;
                }
            } while (currentBingoNode != null); 

            return null;
        }

       //Largely the same as the above except seraching for coordinates instead
       public BingoNode FindBingoNode (int x, int y)
        {
            BingoNode startingBingoNode = this;
            BingoNode currentBingoNode = startingBingoNode;

            do {
                if (currentBingoNode.X == x && currentBingoNode.Y == y)
                {
                    return currentBingoNode;
                }
                else if (currentBingoNode.BingoNodeRight != null)
                {
                    currentBingoNode = currentBingoNode.BingoNodeRight;
                }
                else
                {
                    currentBingoNode = startingBingoNode.BingoNodeDown;
                    startingBingoNode = currentBingoNode;
                }
            } while (currentBingoNode.Number != 0);

            return null;
        }



    }

    public class BingoBoard
    {
        private BingoNode FirstBingoNode {get;set;}

        public BingoBoard (BingoNode firstBingoNode)
        {
            FirstBingoNode = firstBingoNode;
        }

        public BingoNode GetFirstBingoNode()
        {
            return this.FirstBingoNode;
        }

       public BingoNode FindBingoNode (int numberToFind)
        {
            BingoNode startingBingoNode = this.FirstBingoNode;
            BingoNode currentBingoNode = startingBingoNode;

            do {
                if (currentBingoNode.Number == numberToFind)
                {
                    return currentBingoNode;
                }
                else if (currentBingoNode.BingoNodeRight != null)
                {
                    currentBingoNode = currentBingoNode.BingoNodeRight;
                }
                else
                {
                    currentBingoNode = startingBingoNode.BingoNodeDown;
                    startingBingoNode = currentBingoNode;
                }
            } while (currentBingoNode.Number != 0);

            return null;
        }

    }

}

