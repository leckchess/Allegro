using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSphere : Interactable
{

    [SerializeField] private Puzzle _puzzle;

    public override void Interact()
    {
        base.Interact();

        _puzzle.StartPuzzle(0);
    }
}
