using UnityEngine;

public class SnowGridObject : GridObject
{
    [Tooltip("The amount of snow that this tile is worth, when collected by a player.")]
    [SerializeField]
    int snowAmount;

    // this function gets called by the GridSquare class when the player presses the R key on a non-empty grid square
    public override void Interact (Player player)
    {
        snowAmount = Random.Range(3, 7);

        player.SnowCount += snowAmount;

        Destroy(gameObject);
    }
}
