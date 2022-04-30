using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match3: MonoBehaviour
{
   /* public ArrayLayout boardLayout;
    public Sprite[] pieces;

    int width = 6;
    int height = 6;
    Node[,] board;

    System.Random random;

    void StartGame()
    {
        string seed = GetRandomSeed();
        random = new System.Random(seed.GetHashCode());

        InitializeBoard();
    }

    void InitializeBoard()
    {
        board = new Node[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                board[x, y] = new Node((boardLayout.rows[y].row[x]) ? - 1: fillPiece(), new Point(x, y));
            }
        }
    }

    void VerifyBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Point p = new Point(x, y);
                int val = getValueAtPoint(p);
                if (val <= 0) continue;


            }
        }
    }

    List<Point> isConnected(Point p, bool main)
    {
        List<Point> connected = new List<Point>();
        int val = getValueAtPoint(p);
        Point[] directions =
        {
            Point.up,
            Point.right,
            Point.down,
            Point.left
        };

        foreach(Point dir in directions) //Checking if there is 2 or more of the same tile in directions
        {
            List<Point> line = new List<Point>();

            int same = 0;
            for (int i = 1; i < 3; i++)
            {
                Point check = Point.add(p, Point.mult(dir, i));
                if (getValueAtPoint(check) == val)
                {
                    line.Add(check);
                    same++;
                }
            }

            if (same > 1) //if there are more than 1 of the same tile in the direction then we know it's a match
            {
                AddPoints(ref connected, line); //Add these points to the overarching connected list
            }
        }

        for (int i = 0; i < 2; i++) //Checking if we are in the middle of two other pieces that match with this one
        {
            List<Point> line = new List<Point>();

            int same = 0;
            Point[] check = { Point.add(p, directions[i]), Point.add(p, directions[i + 2]) };
            foreach (Point next in check) //check both sides of the piece, if they are the same value, add them to the list
            {
                if (getValueAtPoint(next) == val)
                {
                    line.Add(p);
                    same++;
                }
            }

            if (same > 1)
            {
                AddPoints(ref connected, line);
            }
        }
    }

    void AddPoints(ref List<Point> points, List<Point> add)
    {

    }

    int fillPiece()
    {
        int val = 1;
        val = (random.Next(0, 100) / (100 / pieces.Length)) + 1;
        return val;
    }

    int getValueAtPoint(Point p)
    {
        return board[p.x, p.y].value;
    }

    string GetRandomSeed()
    {
        string seed = "";
        string acceptableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        for (int i = 0; i < 20; i++)
        {
            seed += acceptableChars[Random.Range(0, acceptableChars.Length)];
        }
        return seed;
    }

}

[System.Serializable]
public class Node
{
    public int value; //0 = nothing; 1 = 1; 2 = 2; 3 = 3; 4 = 4; -1 = hole;
    public Point index;

    public Node(int v, Point i)
    {
        value = v;
        index = i;
    }

*/
}
