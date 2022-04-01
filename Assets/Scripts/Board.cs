using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    private void Awake() => Instance = this;

    public Row[] rows;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(dimension: 0);

    public int Height => Tiles.GetLength(dimension: 1);

    private readonly List<Tile> _selection = new List<Tile>();

    // Start is called before the first frame update
    void Start()
    {
        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = rows[y].tiles[x];

                tile.x = x;
                tile.y = y;

                Tiles[x, y] = tile;

                tile.Item = ItemData.Items[Random.Range(0, ItemData.Items.Length)];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(Tile tile)
    {

    }
}
