using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [SerializeField] private Material _HighlightMaterial = null;

    private void Start()
    {
        if ((_HighlightMaterial == null))
        {
            //HighlightMaterial = gameObject.transform.GetChild(0).GetComponent<Renderer>().materials[1];
        }
    }

    protected virtual void OnInteraction()
    {
        // play vfx
        // play sfx
    }

    public virtual void OnHover()
    {
        if (_HighlightMaterial == null)
        {
            return;
        }

        _HighlightMaterial.SetFloat("_Scale", 1.03f);
        // show ui
        // highlight
    }
    public virtual void OnUnHover()
    {
        if (_HighlightMaterial == null)
        {
            return;
        }

        _HighlightMaterial.SetFloat("_Scale", 0);
        // hide ui
        // clear highlight
    }

    public virtual void Interact()
    {
        // the interaction itself (open door, collect,..)
    }

}
