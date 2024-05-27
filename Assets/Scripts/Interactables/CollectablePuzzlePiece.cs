using System;
using UnityEngine;
using FMODUnity;

public class CollectablePuzzlePiece : COllectables
{
    [SerializeField] private int _puzzleId;
    [SerializeField] private int _musicNodeIndex;
    private StudioEventEmitter _musicEmitter;



    public static event Action<int> OnPuzzlePieceCollected;
    public override void Interact()
    {
        OnPuzzlePieceCollected?.Invoke(_puzzleId);
        //_musicEmitter.EventInstance.setParameterByName("Parameter 1", _musicNodeIndex);
        _musicEmitter.Play();
        base.Interact();
    }

    private void Awake()
    {
        _musicEmitter = GetComponent<StudioEventEmitter>();
    }


}
