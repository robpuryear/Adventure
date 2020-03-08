using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;


public class Tile {

    public enum Sides{
        Bottom,
        Right,
        Left,
        Top
    }

    public int autotileID; 
    public int id = 0;
    public Tile[] neighbors = new Tile[4];
    public bool visited;
    public int fowAutotileID;

    public void AddNeighbor(Sides side, Tile tile)
    {
        // add the tile to the correct spot
        neighbors[(int)side] = tile;

        CalculateAutotileID();
    }

    public void RemoveNeighbor(Tile tile)
    {
        var total = neighbors.Length;

        for(var i = 0; i< total; i++)
        {
            if(neighbors[i] != null)
            {
                if(neighbors[i].id == tile.id)
                {
                    neighbors[i] = null;
                }
            }
        }
        CalculateAutotileID();
    }

    public void ClearNeighbors()
    {
        var total = neighbors.Length;

        for (var i = 0; i < total; i++)
        {
            var tile = neighbors[i];
            if(tile != null)
            {
                tile.RemoveNeighbor(this);
                neighbors[i] = null;
            }
        }

        CalculateAutotileID();
    }

    private void CalculateAutotileID()
    {
        var sideValues = new StringBuilder();

        foreach(Tile tile in neighbors)
        {
            sideValues.Append(tile == null ? "0" : "1");
        }

        autotileID = Convert.ToInt32(sideValues.ToString(), 2);
    }

    public void CalculateFOWAutotileID()
    {
        var sideValues = new StringBuilder();

        foreach (Tile tile in neighbors)
        {
            if(tile == null)
            {
                sideValues.Append("1");
            }
            else
            {
                sideValues.Append(tile.visited ? "0": "1");
            }
        }

        fowAutotileID = Convert.ToInt32(sideValues.ToString(), 2);
    }
}
