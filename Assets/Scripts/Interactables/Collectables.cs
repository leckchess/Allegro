using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COllectables : Interactable
{
    public override void Interact()
    {
        // add it to player's inventory
        Destroy(gameObject);
    }
}
