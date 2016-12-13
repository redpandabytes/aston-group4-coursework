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
            case GameNotification.AiTookTurn:
                cardAction.Initialise(0); // initialise it with real values tho
                app.model.HandleAction(cardAction);
                app.viewer.HandleAction();
                break;
            case GameNotification.CardPicked:
                cardAction.Initialise(0); // 0 = pickup? Or does it? I just made it up. TODO: Decide special action ints
                app.model.HandleAction(cardAction);
                app.viewer.HandleAction();

                break;
            case GameNotification.CardPlayed:
                var cardGuild = (int)pData[0];
                var cardValue = (int)pData[1];
                if (app.model.IsCardPlayable(cardGuild, cardValue))
                {
                    cardAction.Initialise(cardGuild, cardValue);
                    app.Notify(GameNotification.ActionTaken, this, cardAction);
                }
                else
                {
                    // should never get to here unless player is hacking, view should verify cards
                    throw new Exception("Cannot play this card");
                }
                break;
            case GameNotification.TimeRanOut:
                GameAction action = new GameAction();
                action.Initialise(0); // 0 means that time ran out
                app.model.HandleAction(action);
                app.viewer.HandleAction();
//                app.viewer.HandleAction(action);
                break;
            case GameNotification.ActionTaken:
                app.model.HandleAction((GameAction)pData[0]);
                app.viewer.HandleAction();
                break;
            default:
                Debug.Log("Unknown Command");
                break;
        }
    }

    //    public void StartTurn() // Update the user's UI when it's their turn
//    {
//        app.model.StartTurn();
//        app.viewer.StartTurn();
//
//    }
//
//    public void TakeAction() // The user has supplied a card, action, or no action to be taken
//    {
//
//
//    }
//
//    public void EndTurn() // Update the Model/UI when it becomes someone elses turn
//    {
//
//    }
//
//    public void CheckForWinner() // TODO: Maybe take out
//    {
//
//    }
//
//    public void Update() // Keep counting down on every frame
//    {
//
//    }

}