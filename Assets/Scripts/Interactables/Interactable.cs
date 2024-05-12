using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected virtual void OnInteraction()
    {
        // play vfx
        // play sfx
    }

    public virtual void OnHover()
    {
        // show ui
        // highlight
    }
    public virtual void OnUnHover()
    {
        // hide ui
        // clear highlight
    }

    public virtual void Interact()
    {
        // the interaction itself (open door, collect,..)
    }

}
