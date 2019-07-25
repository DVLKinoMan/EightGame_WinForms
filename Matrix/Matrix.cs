using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightGame
{
    public class Matrix
    {
        
        public int[] indexesofZero = new int[2];
        public int[,] matrixPosition =new int[3,3];

        public string previusMove;
        public bool leftMove = true;
        public bool rightMove = true;
        public bool upMove = true;
        public bool downMove = true;
        public List<string> path=new List<string>();

        public void moveRight()
        {
            findZero();
            int i = indexesofZero[0];
            int j = indexesofZero[1];
            int k = matrixPosition[i, j];
            matrixPosition[i, j] = matrixPosition[i, j - 1];
            matrixPosition[i, j - 1] = k;
            path.Add("right");
            previusMove = "left";
        }
        public void moveLeft()
        {
            findZero();
            int i = indexesofZero[0];
            int j = indexesofZero[1];
            int k = matrixPosition[i, j];
            matrixPosition[i, j] = matrixPosition[i, j + 1];
            matrixPosition[i, j + 1] = k;
            path.Add("left");
            previusMove = "right";
        }
        public void moveUp()
        {
            findZero();
            int i = indexesofZero[0];
            int j = indexesofZero[1];
            int k = matrixPosition[i, j];
            matrixPosition[i, j] = matrixPosition[i + 1, j];
            matrixPosition[i + 1, j] = k;
            path.Add("up");
            previusMove = "down";
        }
        public void moveDown()
        {
            findZero();
            int i = indexesofZero[0];
            int j = indexesofZero[1];
            int k = matrixPosition[i, j];
            matrixPosition[i, j] = matrixPosition[i -1, j];
            matrixPosition[i - 1 , j] = k;
            path.Add("down");
            previusMove = "up";
        }
        public void findZero()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (matrixPosition[i,j] == 0)
                    {
                        indexesofZero[0] = i;
                        indexesofZero[1] = j;                     
                        break;
                    }
        }
        public void availableMoves(){
            if (indexesofZero[1] == 0)
            {
                if (indexesofZero[0] == 0)
                {
                    rightMove = false;
                    leftMove = true;
                    upMove = true;
                    downMove = false;
                }
                if (indexesofZero[0] == 1)
                {
                    rightMove = false;
                    leftMove = true;
                    upMove = true;
                    downMove = true;
                }
                if(indexesofZero[0]==2)
                {
                    rightMove = false;
                    leftMove = true;
                    upMove = false;
                    downMove = true;
                }
            }
            if (indexesofZero[1] == 2)
            {
                if (indexesofZero[0] == 0)
                {
                    rightMove = true;
                    leftMove = false;
                    upMove = true;
                    downMove = false;
                }
                if (indexesofZero[0] == 1)
                {
                    rightMove = true;
                    leftMove = false;
                    upMove = true;
                    downMove = true;
                }
                if(indexesofZero[0]==2)
                {
                    rightMove = true;
                    leftMove = false;
                    upMove = false;
                    downMove = true;
                }
            }
            if(indexesofZero[1]==1)
            {
                if (indexesofZero[0] == 0)
                {
                    downMove = false;
                    leftMove = true;
                    upMove = true;
                    rightMove = true;
                }
                if (indexesofZero[0] == 2)
                {
                    upMove = false;
                    leftMove = true;
                    rightMove = true;
                    downMove = true;
                }
                if(indexesofZero[0]==1)
                {
                    rightMove = true;
                    leftMove = true;
                    upMove = true;
                    downMove = true;
                }
            }
            if (previusMove == "left") leftMove = false;
            if (previusMove == "right") rightMove = false;
            if (previusMove == "up") upMove = false;
            if (previusMove == "down") downMove = false;
        }
        public void clone(Matrix obj)
        {
            obj.previusMove = previusMove;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    obj.matrixPosition[i, j] = this.matrixPosition[i, j];
            foreach (string g in path)
                obj.path.Add(g);
            obj.leftMove = leftMove;
            obj.rightMove = rightMove;
            obj.upMove = upMove;
            obj.downMove = downMove;
        }
    }
}

