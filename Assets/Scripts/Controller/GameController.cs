// @Author: Nathaniel Baulch-Jones

using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameController : GuildsElement
{
    public GameViewer viewer;

    public void Start() // setup objects
    {

    }

    public void Update() // Keep counting down on every frame
    {

    }

    public void StartTurn() // Update the user's UI when it's their turn
    {
//        model.StartTurn();
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
        app.Notify(GameNotification.GameVictory, this);
    }

    public void PauseGame()
    {
        Debug.Log("got called");
    }

    public void OnNotification(string pEventPath, Object pTarget, object[] pData)
    {
        // Handle GameController notifications
        switch (pEventPath)
        {
            case GameNotification.GameVictory:
                Debug.Log("Victory!");
                break;
            case GameNotification.GameDefeat:
                Debug.Log("Defeat :(");
                break;
            case GameNotification.PauseGame:
                var pauseCanvas = (RectTransform)pData[1];
                if (pData[0].Equals(false))
                {
                    // logic to pause the game
                    pauseCanvas.gameObject.SetActive(true);
                }
                else
                {
                    // logic to unpause the game
                    pauseCanvas.gameObject.SetActive(false);

                }
                break;
            case GameNotification.CardPicked:
                Debug.Log("A card was picked");
                //app.model.PickCard();
                //app.viewer.pickCard(app.model.getLastCard);
                //app.model

                break;
            //case GameNotification.CardPicked:
                //app.model.getHandSize// data about the game
                //app.viewer. //code to update what the game should look like
                //brake;
            default:
                Debug.Log("Unknown Command");
                break;
        }
    }
}