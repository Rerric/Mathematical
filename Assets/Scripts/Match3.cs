using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Match3: MonoBehaviour
{
    public ArrayLayout boardLayout;
    
    [Header("UI Elements")]
    public Sprite[] pieces;
    public RectTransform gameBoard;

    [Header("Prefabs")]
    public GameObject nodePiece;

    int width = 6;
    int height = 6;
    Node[,] board;

    List<NodePiece> update;
    List<FlippedPieces> flipped;

    System.Random random;

    void Start()
    {
        StartGame();
    }

    void Update()
    {

        List<NodePiece> finishedUpdating = new List<NodePiece>();
        for (int i = 0; i < update.Count; i++)
        {
            NodePiece piece = update[i];
            bool updating = piece.UpdatePiece();
            if (!updating)
            {
                finishedUpdating.Add(piece);
            }
        }
        for (int i = 0; i < finishedUpdating.Count; i++)
        {
            NodePiece piece = finishedUpdating[i];
            FlippedPieces flip = getFlipped(piece);
            NodePiece flippedPiece = null;

            List<Point> connected = isConnected(piece.index, true);
            bool wasFlipped = (flip != null);

            if (wasFlipped)
            {
                flippedPiece = flip.getOtherPiece(piece);
                AddPoints(ref connected, isConnected(flippedPiece.index, true));
            }

            if (connected.Count == 0)
            {
                if (wasFlipped)
                {
                    flipPieces(piece.index, flippedPiece.index, false);

                }
            }
            else
            {
                foreach(Point pnt in connected) //remove pieces at this point when connected
                {
                    Node node = getNodeAtPoint(pnt);
                    NodePiece nodePiece = node.getPiece();
                    if (nodePiece != null)
                    {
                        nodePiece.gameObject.SetActive(false);
                    }
                    node.SetPiece(null);
                }
            }

            flipped.Remove(flip);
            update.Remove(piece);
        }
    }

    FlippedPieces getFlipped(NodePiece p)
    {
        FlippedPieces flip = null;
        for (int i = 0; i < flipped.Count; i++)
        {
            if (flipped[i].getOtherPiece(p) != null)
            {
                flip = flipped[i];
                break;
            }
            
        }
        return flip;
    }

    void StartGame()
    {
        string seed = GetRandomSeed();
        random = new System.Random(seed.GetHashCode());
        update = new List<NodePiece>();
        flipped = new List<FlippedPieces>();

        InitializeBoard();
        VerifyBoard();
        InstantiateBoard();
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
        List<int> remove;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Point p = new Point(x, y);
                int val = getValueAtPoint(p);
                if (val <= 0) continue;

                remove = new List<int>();
                while(isConnected(p, true).Count > 0)
                {
                    val = getValueAtPoint(p);
                    if (!remove.Contains(val))
                    {
                        remove.Add(val);
                    }
                    setValueAtPoint(p, newValue(ref remove));
                }
            }
        }
    }

    void InstantiateBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Node node = getNodeAtPoint(new Point(x, y));

                int val = board[x, y].value;
                if (val <= 0) continue;
                GameObject p = Instantiate(nodePiece, gameBoard);
                NodePiece piece = p.GetComponent<NodePiece>();
                RectTransform rect = p.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(0.3f + (0.6f * x), -0.3f - (0.6f * y));
                piece.Initialize(val, new Point(x, y), pieces[val - 1]);
                node.SetPiece(piece);
            }
        }
    }

    public void ResetPiece(NodePiece piece)
    {
        piece.ResetPosition();
        piece.flipped = null;
        update.Add(piece);
    }

    public void flipPieces(Point one, Point two, bool main)
    {
        if (getValueAtPoint(one) < 0) return;

        Node nodeOne = getNodeAtPoint(one);
        NodePiece pieceOne = nodeOne.getPiece();

        if (getValueAtPoint(two) > 0)
        {
            Node nodeTwo = getNodeAtPoint(two);
            NodePiece pieceTwo = nodeTwo.getPiece();
            nodeOne.SetPiece(pieceTwo);
            nodeTwo.SetPiece(pieceOne);

            if (main)
            {
                flipped.Add(new FlippedPieces(pieceOne, pieceTwo));
            }

            update.Add(pieceOne);
            update.Add(pieceTwo);
        }
        else ResetPiece(pieceOne);
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

        foreach (Point dir in directions) //Checking if there is 2 or more of the same tile in directions
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
                    line.Add(next);
                    same++;
                }
            }

            if (same > 1)
            {
                AddPoints(ref connected, line);
            }
        }

        for (int i = 0; i < 4; i++) //check for 2 by 2
        {
            List<Point> square = new List<Point>();

            int same = 0;
            int next = i + 1;
            if (next >= 4) next -= 4;

            Point[] check = { Point.add(p, directions[i]), Point.add(p, directions[next]), Point.add(p, Point.add(directions[i], directions[next])) };
            foreach (Point after in check) //check all sides of the piece, if they are the same value, add them to the list
            {
                if (getValueAtPoint(after) == val)
                {
                    square.Add(after);
                    same++;
                }
            }

            if (same > 2) AddPoints(ref connected, square);
        }

        if (main) //checks for other matches along current match
        {
            for (int i = 0; i < connected.Count; i++)
            {
                AddPoints(ref connected, isConnected(connected[i], false));
            }
        }

        if (connected.Count > 0)
        {
            connected.Add(p);
        }

        return connected;
    }

    void AddPoints(ref List<Point> points, List<Point> add)
    {
        foreach(Point p in add)
        {
            bool doAdd = true;
            for(int i = 0; i < points.Count; i++)
            {
                if(points[i].Equals(p))
                {
                    doAdd = false;
                    break;
                }
            }

            if (doAdd) points.Add(p);
        }
    }

    int fillPiece()
    {
        int val = 1;
        val = (random.Next(0, 100) / (100 / pieces.Length)) + 1;
        return val;
    }

    int getValueAtPoint(Point p)
    {
        if (p.x < 0 || p.x >= width || p.y < 0 || p.y >= height) return -1;
        return board[p.x, p.y].value;
    }

    void setValueAtPoint(Point p, int v)
    {
        board[p.x, p.y].value = v;
    }

    Node getNodeAtPoint(Point p)
    {
        return board[p.x, p.y];
    }

    int newValue(ref List<int> remove)
    {
        List<int> available = new List<int>();
        for (int i = 0; i < pieces.Length; i++)
        {
            available.Add(i + 1);
        }

        foreach (int i in remove)
        {
            available.Remove(i);
        }

        if (available.Count <= 0) return 0;
        return available[random.Next(0, available.Count)];
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

    public Vector2 getPositionFromPoint(Point p)
    {
        return new Vector2(0.3f + (0.6f * p.x), -0.3f - (0.6f * p.y));
    }
}

[System.Serializable]
public class Node
{
    public int value; //0 = nothing; 1 = 1; 2 = 2; 3 = 3; 4 = 4; -1 = hole;
    public Point index;
    public NodePiece piece;

    public Node(int v, Point i)
    {
        value = v;
        index = i;
    }

    public void SetPiece(NodePiece p)
    {
        piece = p;
        value = (piece == null) ? 0 : piece.value;
        if (piece == null) return;
        piece.SetIndex(index);
    }

    public NodePiece getPiece()
    {
        return piece;
    }

}

[System.Serializable]
public class FlippedPieces
{
    public NodePiece one;
    public NodePiece two;

    public FlippedPieces(NodePiece o, NodePiece t)
    {
        one = o; two = t;
    }

    public NodePiece getOtherPiece(NodePiece p)
    {
        if (p == one)
        {
            return two;
        }
        else if (p == two)
        {
            return one;
        }
        else return null;
    }
}
