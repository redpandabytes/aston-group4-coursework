using UnityEngine;
using System.Collections;

public class GameAction
{
    private string desired; // TODO: What does this mean?
    private Card selectedCard;
    private Card secondCard; //If Professor or Messenger is chosen
    private int targetedPlayer; //If a special with a target is chosen
    private int guildToChangeTo; //When thug is chosen
    private int verySpecialAction = 999;

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
        Debug.Log("(GameAction.cs) Initialsed using the choice/selected constructor");
    }

    public void Initialise(string choice)
    {
        if (choice == GameNotification.CardPickedUp)
        {
            verySpecialAction = 0;
        }
    }

    public void Initialise(int guildValue, int cardValue)
    {
        // TODO: Fix this shit implementation caused by DropZone.cs
        // If DropZone.cs can return a card reference my life will be so much easier

        desired = GameNotification.CardPlayed;
        selectedCard = new Card();
        selectedCard.Initialise(guildValue, cardValue, null);
    }

    public void Initialise(int specialAction)
    {
        verySpecialAction = specialAction;
        if (verySpecialAction == 0)
        {
            desired = GameNotification.CardPickedUp;
        }
    }

    public string getChoice()
    {
        if ((desired == null) && (selectedCard != null))
        {
            return GameNotification.CardPlayed;
        }
        else
        {
            return desired;
        }
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