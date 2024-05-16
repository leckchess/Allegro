using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private const float SNAP_THRESHOLD_DISTANCE_SQUARE = 10000;
    private const float SNAP_TIME = 0.2f;

    private Vector2 _targetPosition;
    private Vector3 _startPosition;
    private Coroutine _snapCoroutine;
    [SerializeField] private RawImage _image;

    private bool _isDragging;

    public event Action OnPiecePlaced;

    private Vector2 _startDeltaPosition;

    public void Init(Texture texture, Vector2 cell, Vector2 boardSize, Vector2 targetPosition)
    {
        _image.texture = texture;
        Vector2 size;
        size.x = 1f / boardSize.x;
        size.y = 1f / boardSize.y;

        Vector2 position;
        position.x = cell.x * size.x;
        position.y = (boardSize.y - cell.y - 1) * size.y;

        _image.uvRect = new Rect(position, size);
        _targetPosition = targetPosition;
        _startPosition = ((RectTransform)transform).anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_snapCoroutine != null) return;
        transform.SetSiblingIndex(transform.childCount - 1);
        _isDragging = true;
        _startDeltaPosition = eventData.position - (Vector2)transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDragging) return;
        transform.position = eventData.position - _startDeltaPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDragging) return;

        _isDragging = false;

        if (_snapCoroutine != null)
        {
            StopCoroutine(_snapCoroutine);
        }

        if ((((RectTransform)transform).anchoredPosition - _targetPosition).sqrMagnitude <=
            SNAP_THRESHOLD_DISTANCE_SQUARE)
        {
            _snapCoroutine = StartCoroutine(SnapCoroutine(_targetPosition, PlacePiece));
        }
    }

    private IEnumerator SnapCoroutine(Vector3 targetPosition, Action onFinished)
    {
        float deltaTime = 0.03f;
        var wait = new WaitForSeconds(deltaTime);

        int steps = (int)(SNAP_TIME / deltaTime);
        Vector3 startPosition = ((RectTransform)transform).anchoredPosition;
        for (int i = 0; i < steps; i++)
        {
            ((RectTransform)transform).anchoredPosition =
                Vector3.Lerp(startPosition, targetPosition, (float)i / (steps - 1));
            yield return wait;
        }

        _snapCoroutine = null;
        onFinished?.Invoke();
    }

    void PlacePiece()
    {
        Destroy(this);
        OnPiecePlaced?.Invoke();
    }
}