using UnityEngine;
using System.Collections;

public class Action
{
    private string desired;
    private Card selectedCard;
    private Player targetedPlayer; //If a special with a target is chosen
    private int guildToChangeTo; //When thug is chosen 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Initialises chosen action
    public void Initialise(string choice, Card selected)
    {
        desired = choice;
        selectedCard = selected;
    }

    public string getChoice()
    {
        return desired;
    }

    public Card getSelectedCard()
    {
        return selectedCard;
    }

}