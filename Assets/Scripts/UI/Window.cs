using UnityEngine;
using UnityEngine.Events;

public class Window : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    protected UnityAction<int> callback;

    protected virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public virtual void Open(UnityAction<int> callback)
    {
        Open();
        this.callback = callback;
    }

    public virtual void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
