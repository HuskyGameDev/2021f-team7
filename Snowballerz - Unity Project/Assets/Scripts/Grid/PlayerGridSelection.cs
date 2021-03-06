using UnityEngine;
using UnityEngine.Assertions;

public class PlayerGridSelection : MonoBehaviour
{

    public class Selection
    {
        public GridSelector gridSelector;
        public GridSquare selectedSquare;
    }

    // Public / Exposed fields. //

    [ SerializeField ]
    private MapGrid.Players player;

    [ SerializeField ]
    private GridSelector gridSelectorPrefab;

    // Note: This field is likely temporary.
    [ SerializeField ]
    private MapGrid mapGrid;

    [ Tooltip("The minimum distance the player has to be to an interactable object, (like a GridSquare), in order to select & interact with it.") ]
    [ SerializeField ]
    private float minimumActionDistance = 1f;

    [ Tooltip (
        "A transform for a gameobject that represents the 'center' of the player, " +
        "or, what position is going to be used when comparing the distance to grid square." ) 
    ]
    [ SerializeField ]
    private Transform playerCenter;

    // Private / Unexposed fields. //

    // Active gridSelector instance.
    private Selection selection = null;

    public Selection GetSelected ()
    {
        return selection;
    }

    private void Update()
    {
        SelectionCheck();
    }

    private void SelectionCheck()
    {
        GridSquare nearestSquare = null;
        float nearestSquareDistance = float.MaxValue;

        // Iterate through each grid and find the nearest.
        foreach ( var line in this.mapGrid.Lines )
        {
            foreach ( var sq in MapGrid.GetForPlayer( line, this.player ) )
            {
                // Exclude squares that are not current placeable.
                if ( sq.State == GridSquare.GSState.Unplaceable )
                    continue;
                
                var sqDist = Vector2.Distance( playerCenter.position, sq.transform.position );

                if (sqDist < nearestSquareDistance)
                {
                    nearestSquare = sq;
                    nearestSquareDistance = sqDist;
                }
            }
        }

        if ( nearestSquare == null )
        {
            // Select nothing.
            return;
        }

        if (nearestSquareDistance <= this.minimumActionDistance)
        {
            // Select square if not already selected.
            if (this.selection == null || this.selection.selectedSquare != nearestSquare)
            {
                // If this.selection isn't null, destroy the selector.
                if (this.selection != null)
                    Destroy(this.selection.gridSelector.gameObject);

                this.selection = new Selection
                {
                    gridSelector = GameObject.Instantiate(this.gridSelectorPrefab),
                    selectedSquare = nearestSquare
                };

                this.selection.gridSelector.Select(nearestSquare);
            }
        }
        // Not close enough to any square to be selectable.
        else
        {
            // Destroy selector if something was just selected.
            if (this.selection != null)
            {
                Destroy(this.selection.gridSelector.gameObject);
                this.selection = null;
            }
        }
    }
}
