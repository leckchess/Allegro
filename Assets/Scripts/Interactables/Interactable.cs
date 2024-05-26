using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [SerializeField]
    private Material HighlightMaterial = null;

    private void Start()
    {
        if ((HighlightMaterial == null))
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
        if (HighlightMaterial == null)
        {
            return;
        }

        HighlightMaterial.SetFloat("_Scale", 1.03f);
        // show ui
        // highlight
    }
    public virtual void OnUnHover()
    {
        if (HighlightMaterial == null)
        {
            return;
        }

        HighlightMaterial.SetFloat("_Scale", 0);
        // hide ui
        // clear highlight
    }

    public virtual void Interact()
    {
        // the interaction itself (open door, collect,..)
    }

}
