using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Vector2 _boardSizeInCells;
    [SerializeField] private PuzzlePiece _puzzlePiecePrefab;
    [SerializeField] private Texture _texture;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private RawImage _image;

    private int _placedPiecesCount;
    private int _piecesCount;

    private List<GameObject> _peices = new List<GameObject>();

    public event Action OnPuzzleSolved;

    void Start()
    {
        Reset();

        int i = 0;
        var pieceSize = new Vector2(_parent.sizeDelta.x / _boardSizeInCells.x,
            _parent.sizeDelta.y / _boardSizeInCells.y);

        _piecesCount = (int)(_boardSizeInCells.x * _boardSizeInCells.y);

        for (int j = 0; j < _boardSizeInCells.x; j++) //col
        {
            for (int k = 0; k < _boardSizeInCells.y; k++) //row
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
                piece.Init(_texture, cell, _boardSizeInCells, targetPosition);
                piece.OnPiecePlaced += OnPiecePlaced;
                _peices.Add(piece.gameObject);
            }
        }

        _image.texture = _texture;
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
            OnPuzzleSolved?.Invoke();
    }

    Vector2 GetRandomPosition()
    {
        var centerPosition = new Vector2(_parent.sizeDelta.x / 2, -_parent.sizeDelta.y / 2);
        return centerPosition + 500 * Random.insideUnitCircle;
    }
}