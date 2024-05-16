using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzlesData", menuName = "Puzzles Data", order = 0)]
public class PuzzlesData : ScriptableObject
{
    public PuzzleData[] Data;
}

[Serializable]
public class PuzzleData
{
    public Texture Image;
    public Vector2 Size;

    public float PiecesCount => Size.x * Size.y;
}