using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour
{
    private string desired;
    private Card selectedCard;

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