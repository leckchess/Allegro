using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [SerializeField] private Material _highlightMaterial = null;
    [SerializeField] private MeshRenderer[] _renderers;
    private Material[][] _materials;

    protected virtual void Start()
    {
        if (_highlightMaterial == null)
        {
            _highlightMaterial = Resources.Load<Material>("highlight");
        }
        _materials = new Material[_renderers.Length][];
        for (int i = 0; i < _renderers.Length; i++)
        {
            _materials[i] = new Material[_renderers[i].materials.Length];
            for (int j = 0; j < _materials[i].Length; j++)
            {
                _materials[i][j] = _renderers[i].sharedMaterials[j];
            }
        }
    }

    protected virtual void OnInteraction()
    {
        // play vfx
        // play sfx
    }

    public virtual void OnHover()
    {
        if (_highlightMaterial == null)
        {
            return;
        }
        
        Debug.Log("hover");

        foreach (var rend in _renderers)
        {
            var materials = new Material[rend.sharedMaterials.Length];
            for (int i = 0; i < rend.sharedMaterials.Length; i++)
            {
                materials[i] = _highlightMaterial;
            }

            rend.sharedMaterials = materials;
        }
        // show ui
        // highlight
    }
    public virtual void OnUnHover()
    {
        if (_highlightMaterial == null)
        {
            return;
        }

        for (int i = 0; i < _renderers.Length; i++)
        {
            _renderers[i].sharedMaterials = _materials[i];
            // for (int j = 0; j < _renderers[i].sharedMaterials.Length; j++)
            // {
            //     _renderers[i].sharedMaterials[j] = _materials[i][j];
            // }
        }
        // hide ui
        // clear highlight
    }

    public virtual void Interact()
    {
        // the interaction itself (open door, collect,..)
    }

    [ContextMenu("Get Renderers")]
    private void GetRenderers()
    {
        _renderers = GetComponentsInChildren<MeshRenderer>();
    }

}
