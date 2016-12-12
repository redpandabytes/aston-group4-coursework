/*
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */

using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GameController : GuildsElement
{
    public int player;
    public GameViewer viewer;

    public Hand player0;
    public Hand player1;
    public Hand player2;
    public Hand player3;

	public Transform turnP1;
	public Transform turnP2;
	public Transform turnP3;
	public Transform turnP4;

    public Deck deck; //stack of unplayed cards

    public Button pickCardBttn;

    public Transform dropzone;

    public GameObject card;

    public void Start() // setup objects
    {
        app.model.Initialise();
        app.viewer.Initialise();
        
        //all players pick 7 cards
//        for (int i = 0; i < 7; i++){//players pick 7 cards
//            for (player = 0; player < 4; player++) {//4 players
//                //player picks card
//                //app.model.PickCard();
//
//                if (player == 0)
//                {
//					//turnP1.gameObject.SetActive(true);
//                    // player picks 7 cards
//                    //player0.add(deck.pop()); // player 0 picks a card
//                    Debug.Log("player: " + player + " picked their: " + i + "card.");
//                }
//                if (player == 1)
//                {
//					//turnP2.gameObject.SetActive(true);
//                    //AI picks 7 cards
//                    //player1.add(deck.pop()); // player 1 picks a card
//                    Debug.Log("player: " + player + " picked their: " + i + "card.");
//                }
//                if (player == 2)
//                {
//                    //AI picks 7 cards
//                    //player2.add(deck.pop()); // player 2 picks a card
//                    Debug.Log("player: " + player + " picked their: " + i + "card.");
//                }
//                if (player == 3)
//                {
//                    //AI picks 7 cards
//                    //player3.add(deck.pop()); // player 3 picks a card
//                    Debug.Log("player: " + player + " picked their: " + i + "th card.");
//
//                }
//            }
//        }
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