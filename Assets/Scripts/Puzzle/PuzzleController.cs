using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleController : MonoBehaviour
    {
        [SerializeField] private Puzzle _puzzle;
        [SerializeField] private PuzzlesData _data;
        [SerializeField] private UnityEvent<int> _onPuzzlePiecesCollected;

        private Dictionary<int, int> _collectedPieces = new Dictionary<int, int>();

        void Start()
        {
            CollectablePuzzlePiece.OnPuzzlePieceCollected += OnPieceCollected;
        }

        private void OnPieceCollected(int puzzleId)
        {
            if (_collectedPieces.ContainsKey(puzzleId))
            {
                _collectedPieces[puzzleId]++;
                if (_collectedPieces[puzzleId] >= _data.Data[puzzleId].PiecesCount)
                {
                    Cursor.lockState = CursorLockMode.None;
                    _onPuzzlePiecesCollected.Invoke(puzzleId);
                }
            }
            else
            {
                _collectedPieces.Add(puzzleId, 1);
            }
        }

        private void OnDestroy()
        {
            CollectablePuzzlePiece.OnPuzzlePieceCollected -= OnPieceCollected;
        }
    }