using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    [SerializeField] private Tilemap _groundMap, _smallTree, _bushes, _staris, _walls;
    [SerializeField] private int _levelIndex;

    public void SaveMap(){
        var newLevel = ScriptableObject.CreateInstance<ScriptableMap>();
        newLevel.LevelIndex = _levelIndex;
        newLevel.name = $"Level {_levelIndex}";

        newLevel.GroundTiles = GetTilesFromMap(_groundMap).ToList();
        newLevel.SmallTree = GetTilesFromMap(_smallTree).ToList();
        newLevel.Bushes = GetTilesFromMap(_bushes).ToList();
        newLevel.Stairs = GetTilesFromMap(_staris).ToList();
        newLevel.Walls = GetTilesFromMap(_walls).ToList();

        //////
        var json = JsonUtility.ToJson(newLevel);
        Debug.Log(json);
        //////


        ScriptableObjectUtility.SaveLevelFile(newLevel);

        IEnumerable<SavedTile> GetTilesFromMap(Tilemap map){
            foreach(var pos in map.cellBounds.allPositionsWithin){
                if(map.HasTile(pos)){
                    var levelTile = map.GetTile<LevelTile>(pos);
                    yield return new SavedTile(){
                        Position = pos,
                        Tile = levelTile
                    };
                }
            }
        }
    }

    public void ClearMap() {
        var maps = FindObjectsOfType<Tilemap>();

        foreach (var tilemap in maps) {
            tilemap.ClearAllTiles();
        }
    }

public void LoadMap() {
        var level = Resources.Load<ScriptableMap>($"Levels/Level {_levelIndex}");
        if (level == null) {
            Debug.LogError($"Level {_levelIndex} does not exist.");
            return;
        }

        ClearMap();

        foreach (var savedTile in level.GroundTiles) {
            switch (savedTile.Tile.Type) {
                case TileType.Ground:
                    SetTile(_groundMap, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.SmallTree)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.SmallTree:
                    SetTile(_smallTree, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.Bushes)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.Bushes:
                    SetTile(_bushes, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.Stairs)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.Stairs:
                    SetTile(_staris, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.Walls)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.Walls:
                    SetTile(_walls, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void SetTile(Tilemap map, SavedTile tile) {
            map.SetTile(tile.Position, tile.Tile);
        }
    }

}

#if UNITY_EDITOR

public static class ScriptableObjectUtility{
    public static void SaveLevelFile(ScriptableMap level){
        AssetDatabase.CreateAsset(level, $"Assets/Resources/Levels/{level.name}.asset");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

#endif

public struct Level {
    public int LevelIndex;
    public List<SavedTile> GroundTiles;
    public List<SavedTile> SmallTree;
    public List<SavedTile> Bushes;
    public List<SavedTile> Stairs;
    public List<SavedTile> Walls;

    public string Serialize() {
        var builder = new StringBuilder();

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        builder.Append("g[");
        foreach (var groundTile in GroundTiles) {
            builder.Append($"{(int) groundTile.Tile.Type}({groundTile.Position.x},{groundTile.Position.y})");
        }
        builder.Append("]");

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        builder.Append("st[");
        foreach (var smallTreeTile in SmallTree) {
            builder.Append($"{(int) smallTreeTile.Tile.Type}({smallTreeTile.Position.x},{smallTreeTile.Position.y})");
        }
        builder.Append("]");

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        builder.Append("b[");
        foreach (var bushesTile in Bushes) {
            builder.Append($"{(int) bushesTile.Tile.Type}({bushesTile.Position.x},{bushesTile.Position.y})");
        }
        builder.Append("]");

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        builder.Append("b[");
        foreach (var stairsTile in Stairs) {
            builder.Append($"{(int) stairsTile.Tile.Type}({stairsTile.Position.x},{stairsTile.Position.y})");
        }
        builder.Append("]");

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        builder.Append("w[");
        foreach (var wallsTile in Walls) {
            builder.Append($"{(int) wallsTile.Tile.Type}({wallsTile.Position.x},{wallsTile.Position.y})");
        }
        builder.Append("]");

        return builder.ToString();
    }
}