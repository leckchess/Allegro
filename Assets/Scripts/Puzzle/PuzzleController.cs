using System;
using System.Collections.Generic;
using UnityEngine;

    public class PuzzleController : MonoBehaviour
    {
        [SerializeField] private Puzzle _puzzle;
        [SerializeField] private PuzzlesData _data;

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
                    _puzzle.StartPuzzle(_data.Data[puzzleId].Size, _data.Data[puzzleId].Image);
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