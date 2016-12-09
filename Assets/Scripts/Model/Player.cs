// @Author: Enter Authors Here

using UnityEngine;
using System.Collections;

public class Player
{
    //Fields
    private Hand hand;
    private string userName;
    private bool hasPlayedCleanSlate;
    private bool isAI;
    private bool hasFinishedTurn;
    private Card desiredCard;
    private int desiredAction;


    // Use this for initialization
    void Start()
    {

    }

    public void Initialise(string userName, bool isAI)
    {
        this.userName = userName;
        this.isAI = isAI;
        this.hasPlayedCleanSlate = false;
        this.hand = new Hand();
        this.hasFinishedTurn = false;
    }

    //Gets the state of hasPlayedCleanSlate
    public bool getCleanSlate()
    {
        return hasPlayedCleanSlate;
    }

    //Sets the state of hasPlayedCleanSlate
    //should probably only be able to set it to true?
    //to stop players abusing this method?
    public void setCleanSlate(bool state)
    {
        hasPlayedCleanSlate = state;
    }

    // returns the card or action that the user has performed once their turn is complete
    public Card getDesiredAction()
    {
        // TODO: Implement method that can return a generic, so we can return an action rather than a card/int (we can't do both).
        return new Card();
    }

    public void setDesiredAction()
    {
        // TODO: Implement
    }


    // Update is called once per frame
    void Update()
    {

    }

    public Hand getHand()
    {
        return hand;
    }
}