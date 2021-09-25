
// every obj in the game that the player can interact with will be tagged with this interface
interface IInteractable
{
    /// <summary>
    /// Called when a player interacts with an IInteractable. The player interacting with it is passed as a parameter.
    /// </summary>
    /// <param name="player"></param>
    void Interact( Player player );
}