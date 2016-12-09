// @Author: Nathaniel Baulch-Jones

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameModel : GuildsElement
{

    //Fields
    private List<Player> _players; // TODO: Check there's no conflict with Unity "Player" Class
    private Deck _drawDeck;
    private Deck _discardDeck;
    private int _currentPlayer;
    private StaticAi _ai;
    private GameObject[] _faces;
    private const int GameMode = 1;

    private const int StartingHandSize = 7;

    public void Initialise()
    {
        // Use this for initialization
        // setup game objects we need
        _discardDeck = new Deck();
        _drawDeck = new Deck();

        // For guilds 1-4, create cards 1-20 and add to the draw deck
        for (int g = 1; g < 5; g++)
        {
            for (int v = 1; v < 20; v++)
            {
                Card c = new Card();
                //TODO: Pass a face
                c.Initialise(g, v, null);
                _drawDeck.push(c);
            }
        }
        // add special cards
        Card triumph = new Card();
        triumph.Initialise(0, 0, null);
        _drawDeck.push(triumph);

        _drawDeck.shuffle();

        //SET UP PLAYERS
        // TODO: Only hardcoded for a single player right now
        _players = new List<Player>();

        //For singleplayer:
        int difficulty = 1; // TODO: All this is hard coded
        int noOfPlayers = 4;
        String userName = "Player 1";
        _ai = new StaticAi();
        _ai.Initialise(difficulty, noOfPlayers);

        if (GameMode == 1) // TODO: Implement multiplayer mode
        {
            Player newPlayer = new Player();
            newPlayer.Initialise(userName, false);
            _players.Add(newPlayer);
            for (int p = 1; p < noOfPlayers; p++)
            {
                Player ai = new Player();
                ai.Initialise("AI " + p, true);
                _players.Add(ai);
            }

            // Give players cards
            foreach (var curPlayer in _players)
            {
                var curHand = curPlayer.getHand();
                for (var i = 1; i <= StartingHandSize; i++)
                {
                    Card cardToAdd = _drawDeck.pop();
                    Debug.Log("(Adding to starting hand): Guild " + cardToAdd.getGuild() + ", Value " + cardToAdd.getValue());
                    curHand.add(cardToAdd);
                }
            }

            // decide which player goes first, in single player the player is always at Index 0 in _players
            _currentPlayer = Random.Range(0,4);
        }
    }

    public void StartTurn()
    {
        // TODO: Implement
    }

    public void TakeAction()
    {
        throw new NotImplementedException();
    }

    public void EndTurn()
    {
        // TODO: Implement
    }

    public void CheckForWinner()
    {
        // TODO: Implement
    }

    public void EndGame()
    {
        throw new NotImplementedException();
    }

    public void PlayCard()
    {
        // TODO: Implement
    }

    // Update is called once per frame
    public void Update()
    {
        // GAME LOGIC WILL BE RAN HERE!
    }
    public void pickCard()
    {
        //Do this plz
    }
}