using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SW_AnimationEvents : MonoBehaviour
{
    /// <summary>
    /// Called when the main selection wheel wheelAnimator requests for 
    /// all visible elements to be hidden.
    /// </summary>
    public event Action OnHideVisibleRequested;

    /// <summary>
    /// Called when the main selection wheel wheelAnimator requests for 
    /// all visible elements to be shown.
    /// </summary>
    public event Action OnShowVisibleRequested;

    public void CallShowVisibleRequested()
    {
        if (OnShowVisibleRequested != null)
            this.OnShowVisibleRequested.Invoke();
    }

    public void CallHideVisibleRequested()
    {
        if ( OnHideVisibleRequested != null )
            this.OnHideVisibleRequested.Invoke();
    }   
}
