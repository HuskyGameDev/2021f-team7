using UnityEngine;

public abstract class GridObject : MonoBehaviour
{

    //Originally had an entire dev rant here, but even I need to remain professional.
    bool placed;

    public bool Placed
    {
        get { return placed; }

        set
        {
            value = placed;
        }
    }

    // This function gets called by the GridSquare class when the player presses the R key on a non-empty grid square
    public abstract void Interact ( Player player );
}
