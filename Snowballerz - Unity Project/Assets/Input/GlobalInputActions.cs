using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalInputActions : MonoBehaviour
{
    public static InputActions Instance
    {
        get
        {
            if ( instance == null )
            {
                instance = new InputActions();

                #if ARCADE_BUILD
                    instance.bindingMask = InputBinding.MaskByGroup(instance.ArcadeControlsScheme.bindingGroup);
                #else 
                    instance.bindingMask = InputBinding.MaskByGroup(instance.DesktopScheme.bindingGroup);
                #endif
            }

            return instance;
        }
    }

    public static void Reset( )
    {
        instance = null;
    }

    private static InputActions instance = null;
}
