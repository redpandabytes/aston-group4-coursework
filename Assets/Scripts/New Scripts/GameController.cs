using Debug = UnityEngine.Debug;

namespace New_Scripts {
    public class GameController : GuildsElement
    {
        public GameViewer viewer;
        public GameModel model;

        public void Start() // setup objects
        {

        }

        public void Update() // Keep counting down on every frame
        {

        }

        public void StartTurn() // Update the user's UI when it's their turn
        {
            model.StartTurn();
            viewer.StartTurn();
        }

        public void TakeAction() // The user has supplied a card, action, or no action to be taken
        {

        }

        public void EndTurn() // Update the Model/UI when it becomes someone elses turn
        {

        }

        public void CheckForWinner() // TODO: Maybe take out
        {

        }

        public void EndGame() // The game has finished
        {
            Debug.Log("Victory!");
        }
    }
}