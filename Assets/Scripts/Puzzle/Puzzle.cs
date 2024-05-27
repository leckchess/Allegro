using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private PuzzlePiece _puzzlePiecePrefab;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private RawImage _image;
    [SerializeField] private PuzzlesData _data;

    private int _placedPiecesCount;
    private int _piecesCount;

    private List<GameObject> _peices = new List<GameObject>();

    public event Action OnPuzzleSolved;

    public void StartPuzzle(int puzzleId)
    {
        StartPuzzle(_data.Data[puzzleId].Size, _data.Data[puzzleId].Image);
    }

    public void StartPuzzle(Vector2 boardSizeInCells, Texture texture)
    {
        Reset();
        
        int i = 0;
        var pieceSize = new Vector2(_parent.sizeDelta.x / boardSizeInCells.x,
            _parent.sizeDelta.y / boardSizeInCells.y);

        _piecesCount = (int)(boardSizeInCells.x * boardSizeInCells.y);

        for (int j = 0; j < boardSizeInCells.x; j++) //col
        {
            for (int k = 0; k < boardSizeInCells.y; k++) //row
            {
                var piece = Instantiate(_puzzlePiecePrefab, _parent);
                var pieceTransform = (RectTransform)piece.transform;
                var randomPosition = GetRandomPosition();
                randomPosition.x -= pieceSize.x / 2;
                randomPosition.y += pieceSize.y / 2;
                pieceTransform.anchoredPosition = randomPosition;
                pieceTransform.sizeDelta = pieceSize;
                var cell = new Vector2(k, j);
                var targetPosition = cell * pieceSize;
                targetPosition.y = -targetPosition.y;
                piece.Init(texture, cell, boardSizeInCells, targetPosition);
                piece.OnPiecePlaced += OnPiecePlaced;
                _peices.Add(piece.gameObject);
            }
        }

        _image.texture = texture;
        
        gameObject.SetActive(true);
    }

    private void Reset()
    {
        _placedPiecesCount = 0;

        foreach (var piece in _peices)
        {
            Destroy(piece);
        }

        _peices.Clear();
    }

    private void OnPiecePlaced()
    {
        if (++_placedPiecesCount >= _piecesCount)
        {
            OnPuzzleSolved?.Invoke();
            FMODAudioManager.Instance.PlayHappyMusic(); 
        }
    }

    Vector2 GetRandomPosition()
    {
        var centerPosition = new Vector2(_parent.sizeDelta.x / 2, -_parent.sizeDelta.y / 2);
        return centerPosition + 500 * Random.insideUnitCircle;
    }
}