using System;
using System.Collections.Generic;
using UnityEngine;

namespace New_Scripts {
public class GameController : MonoBehaviour {

    //Fields
    private List<Player> _players; // TODO: Check there's no conflict with Unity "Player" Class
    private Deck _drawDeck;
    private Deck _discardDeck;
    private int _currentPlayer;
    private AiController _ai;
    private UnityEngine.GameObject[] _faces;
    private const int GameMode = 1;

    // Use this for initialization
    void Start () {
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
                c.Initialise(v, g, null);
                _drawDeck.push(c);
            }
        }
        Card triumph = new Card();
        triumph.Initialise(0, 0, null);
        _drawDeck.push(triumph);
        _drawDeck.shuffle();

        Debug.Log(_drawDeck.getAmountOfCards());

        //SET UP PLAYERS
        // TODO: Only hardcoded for a single player right now
        _players = new List<Player>();

        //For singleplayer:
        int difficulty = 1;
        int noOfPlayers = 4;
        String userName = "Player 1";
        _ai = new AiController();
        _ai.Initialise(difficulty, noOfPlayers);
        if (GameMode == 1)
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

            foreach (Player player in _players)
            {
                Debug.Log(_players.Count);
                Debug.Log(player.getCleanSlate());
                player.setCleanSlate(true);
                Debug.Log(player.getCleanSlate());
            }
        }

        else
        {
            //Multiplayer Set Up
        }
    }

    public void setupGame()
    {

    }

    public void startGame()
    {
        // TODO: Implement
    }

    public void startTurn()
    {
        // TODO: Implement
    }

    public void endTurn()
    {
        // TODO: Implement
    }

    public void checkForWinner()
    {
        // TODO: Implement
    }

    public void playCard()
    {
        // TODO: Implement
    }

	// Update is called once per frame
	void Update () {
	    // GAME LOGIC WILL BE RAN HERE!
	}
}
}