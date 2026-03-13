using System;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int width = 8;
    private int height = 8;
    private Tile[,] tiles;

    void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        tiles = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile(x, y);
            }
        }
        // Optionally, randomize tiles here
    }

    public void SwapTiles(int x1, int y1, int x2, int y2)
    {
        Tile temp = tiles[x1, y1];
        tiles[x1, y1] = tiles[x2, y2];
        tiles[x2, y2] = temp;
        CheckForMatches();
    }

    private void CheckForMatches()
    {
        List<Tile> matchedTiles = new List<Tile>();
        // Check horizontal matches
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width - 2; x++)
            {
                if (tiles[x, y].Type == tiles[x + 1, y].Type && tiles[x, y].Type == tiles[x + 2, y].Type)
                {
                    matchedTiles.Add(tiles[x, y]);
                    matchedTiles.Add(tiles[x + 1, y]);
                    matchedTiles.Add(tiles[x + 2, y]);
                }
            }
        }
        // Check vertical matches
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height - 2; y++)
            {
                if (tiles[x, y].Type == tiles[x, y + 1].Type && tiles[x, y].Type == tiles[x, y + 2].Type)
                {
                    matchedTiles.Add(tiles[x, y]);
                    matchedTiles.Add(tiles[x, y + 1]);
                    matchedTiles.Add(tiles[x, y + 2]);
                }
            }
        }
        // Handle matched tiles (e.g., destroy them, update score)
    }
}

[System.Serializable]
public class Tile
{
    public int X; 
    public int Y;
    public string Type;

    public Tile(int x, int y)
    {
        X = x;
        Y = y;
        Type = GetRandomType();
    }

    private string GetRandomType()
    {
        string[] types = { "Red", "Green", "Blue", "Yellow", "Purple" };
        return types[UnityEngine.Random.Range(0, types.Length)];
    }
}