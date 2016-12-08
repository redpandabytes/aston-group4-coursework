namespace Assets.Scripts.New_Scripts {
    public interface IGameController {

        // Use this for initialization
        void Start(); // setup objects
        void Update(); // Keep counting down on every frame

        void StartTurn(); // Update the user's UI when it's their turn
        void TakeAction(); // The user has supplied a card, action, or no action to be taken
        void EndTurn(); // Update the Model/UI when it becomes someone elses turn

        void CheckForWinner(); // TODO: Maybe take out
        void EndGame(); // The game has finished
    }
}