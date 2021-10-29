
// every obj in the game that the player can interact with will be tagged with this interface
interface IInteractable
{
    //Called when a player interacts with an IInteractable. The player interacting with it is passed as a parameter.
    bool Interact(Player player);
}

// every obj in the game that is able to be hit by a snowball will be tagged with this interface
interface IDamageable
{
    void TakeDamage(int amount);
}

interface IPlaceableByPlayer
{
    void Place(Player player);
}