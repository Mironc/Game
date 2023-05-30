using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SelfDestroing : InteractableObject
{
    public override void OnInteract()
    {
        Debug.Log("!Interact");
        Destroy(this);
    }
}
