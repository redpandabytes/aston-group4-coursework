/*
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */

using System;
using UnityEngine;
using UnityEngine.UI;
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
            case GameNotification.CardPlayed:
                var cardGuild = (int)pData[0];
                var cardValue = (int)pData[1];
                if (app.model.IsCardPlayable(cardGuild, cardValue))
                {
                    // can play
                    Debug.Log("Logic to play a card");
                }
                else
                {
                    throw new Exception("Cannot play this card");
                }
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