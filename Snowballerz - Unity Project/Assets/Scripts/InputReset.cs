using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReset : MonoBehaviour
{
    void Awake()
    {
        var ia = GlobalInputActions.Reset();

        if ( ia != null ) 
        {
            ia.Disable();
            ia.Dispose();
        }
    }
}
