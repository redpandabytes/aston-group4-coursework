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
