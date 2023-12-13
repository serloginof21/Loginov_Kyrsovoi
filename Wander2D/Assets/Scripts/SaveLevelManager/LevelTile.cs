using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="New Level Tile", menuName ="2D/Tiles/Level Tile")]
public class LevelTile : Tile
{
    public TileType Type;
}

public enum TileType{
    Ground = 0,
    SmallTree = 1,
    Bushes = 2,
    Stairs = 3,
    Walls = 4
}