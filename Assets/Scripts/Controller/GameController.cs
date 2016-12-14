/*
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */

using System;
using UnityEngine;
using UnityEngine.UI;
using Action = System.Action;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

public class GameController : GuildsElement
{
    public void Start() // setup objects
    {
        app.model.Initialise();
        app.viewer.Initialise();
    }

    public void OnNotification(string pEventPath, Object pTarget, object[] pData)
    {
        var cardAction = new GameAction();
        // Handle GameController notifications
        switch (pEventPath)
        {
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

            case GameNotification.AiTookTurn:
                cardAction = (GameAction)pData[0];
                Debug.Log("(GameController.cs) Processing the AI's action");
                if (cardAction.WasPickupCard())
                {
                    Debug.Log("(GameController.cs) AI attempting to pick up a card");
                    app.Notify(GameNotification.CardPickedUp, this);
                }
                else
                {
//                    Debug.Log("(GameController.cs) AI attempting to play card");
                    app.Notify(GameNotification.CardPlayed, this, cardAction.getSelectedCard().getGuild(),
                    cardAction.getSelectedCard().getValue());
                }

                break;

            case GameNotification.CardPlayed:
                var cardGuild = (int)pData[0];
                var cardValue = (int)pData[1];
//                Debug.Log("(GameController.cs) The player played a card");
                if (app.model.IsCardPlayable(cardGuild, cardValue))
                {
                    cardAction.Initialise(cardGuild, cardValue);
                    app.Notify(GameNotification.ActionTaken, this, cardAction);
                }
                else
                {
                    // should never get to here unless player is hacking, as view should verify cards
                    Debug.Log("(GameController.cs) WARNING!: Illegal Move Detected! Potential Hacking?");
                    app.Notify(GameNotification.CardPickedUp, this); // pickup a card if they're hacking
                }
                break;

            case GameNotification.CardPickedUp:
                GameAction pickUpAction = new GameAction();
                pickUpAction.Initialise(0); // 0 = pickup? Or does it? I just made it up. TODO: Decide special action ints
                app.model.HandleAction(pickUpAction);
                app.viewer.HandleAction();
                break;

            case GameNotification.TimeRanOut:
                GameAction ranOutAction = new GameAction();
                ranOutAction.Initialise(0); // 0 means that time ran out
                app.model.HandleAction(ranOutAction);
                app.viewer.HandleAction();
//                app.viewer.HandleAction(action);
                break;

            case GameNotification.ActionTaken:
                app.model.HandleAction((GameAction)pData[0]);
                app.viewer.HandleAction();
                break;
            default:
                Debug.Log("(GameController.cs) Unknown Command");
                break;
            case GameNotification.GameVictory:
                Debug.Log("(GameController.cs) Victory!");
                break;

            case GameNotification.GameDefeat:
                Debug.Log("(GameController.cs) Defeat :(");
                break;
        }
    }

//    public void Update() // Keep counting down on every frame
//    {
//
//    }

}