using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour, IInteractable
{
    public abstract void Interact ( Player player );
}
