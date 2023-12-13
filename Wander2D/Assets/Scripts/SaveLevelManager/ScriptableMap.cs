using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableMap : ScriptableObject
{
    public int LevelIndex;
    public List<SavedTile> GroundTiles;
    public List<SavedTile> SmallTree;
    public List<SavedTile> Bushes;
    public List<SavedTile> Stairs;
    public List<SavedTile> Walls;
}

[Serializable]
public class SavedTile{
    public Vector3Int Position;
    public LevelTile Tile;
}
