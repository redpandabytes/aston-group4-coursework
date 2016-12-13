using UnityEngine;
using System.Collections;

public class GameAction
{
    private string desired; // TODO: What does this mean?
    private Card selectedCard;
    private Card secondCard; //If Professor or Messenger is chosen
    private int targetedPlayer; //If a special with a target is chosen
    private int guildToChangeTo; //When thug is chosen
    private int verySpecialAction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool WasPickupCard()
    {
        return verySpecialAction == 0;
    }

    //Polymorphic initialisation (don't check for valid actions here)
    public void Initialise(string choice, Card selected)
    {
        desired = choice;
        selectedCard = selected;
    }

    public void Initialise(int guildValue, int cardValue)
    {

    }

    public void Initialise(int specialAction)
    {
        verySpecialAction = specialAction;
    }

    public string getChoice()
    {
        return desired;
    }

    public Card getSelectedCard()
    {
        return selectedCard;
    }

    public int getGuildChosen()
    {
        return guildToChangeTo;
    }

    public int getTarget() {
        return targetedPlayer;
    }

    public Card getSecondCard() {
        return secondCard;
    }
}