using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    //Fields
    private List<Player> players; // TODO: Check there's no conflict with Unity "Player" Class
    private Deck drawDeck;
    private Deck discardDeck;
    private int currentPlayer;
    private AIController AI;

    // Use this for initialization
    void Start () {
	    // TODO: Constructor here
	}

    public void setupGame(int noOfPlayers, int difficulty, String userName, int gameMode)
    {
        //SET UP DECKS
        discardDeck = new Deck();
        drawDeck = new Deck();

        // For guilds 1-4, create cards 1-20 and add to the draw deck
        for (int g = 1; g < 5; g++)
        {
            for (int v = 1; v < 20; v++)
            {
                Card c = new Card(v, g);
                drawDeck.push(c);
            }
        }
        Card triumph = new Card(0, 0);
        drawDeck.push(triumph);
       // drawDeck.shuffle();

        //SET UP PLAYERS
        players = new List<Player>();

        //For singleplayer: 
        AI = new AIController(difficulty, noOfPlayers);
        if (gameMode == 1)
        {
            players.Add(new Player(userName, false));
            for (int p = 1; p < noOfPlayers; p++)
            {
                Player AI = new Player("AI Joe", true);
                players.Add(AI);
            }
        }
        else
        {
            //Multiplayer Set Up 
        }

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
