using System;
using UnityEngine;

public class CollectablePuzzlePiece : COllectables
{
    [SerializeField] private int _puzzleId;

    public static event Action<int> OnPuzzlePieceCollected;
    public override void Interact()
    {
        OnPuzzlePieceCollected?.Invoke(_puzzleId);
        base.Interact();
    }
}
