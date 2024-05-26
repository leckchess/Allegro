using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabTable : Interactable
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] bool _isPlaying = true;

    void Start()
    {
        Apply();
    }
    public override void Interact()
    {
        base.Interact();
        _isPlaying = !_isPlaying;
        Apply();
    }

    void Apply()
    {
        if(_isPlaying) _particleSystem.Play();
        else _particleSystem.Stop();
    }
}
