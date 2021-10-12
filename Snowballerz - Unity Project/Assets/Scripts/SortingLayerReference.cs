using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class in order to give a static reference to sorting layer string names, as
/// they can't be checked at compile-time, and I'd like them to.
/// (This should help minimize magic strings anywhere we're tampering with sorting layers
/// in our scripts.)
/// </summary>
public class SortingLayerReference
{
    public const string SW_Shadow     = "SW_Shadow";
    public const string SW_Background = "SW_Background";
    public const string SW_Selector   = "SW_Selector";
    public const string SW_Top        = "SW_Top";
    public const string SW_Bottom     = "SW_Bottom";
}
