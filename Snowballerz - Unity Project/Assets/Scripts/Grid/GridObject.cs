using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    // This function gets called by the GridSquare class when the player presses the R key on a non-empty grid square
    public abstract void Interact ( Player player );
}
