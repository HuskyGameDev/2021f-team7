using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SW_SelectorAnimationEvents : MonoBehaviour
{
    /// <summary>
    /// Called when the vertical-selector animation is finished moving either up or down.
    /// </summary>
    public event Action OnFinishedVertMoving;
    
    public void CallFinishedVertMoving()
    {
        if ( OnFinishedVertMoving != null )
            this.OnFinishedVertMoving.Invoke();
    }

}
