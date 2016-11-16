using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour
{
    //Fields
    private List<card> hand;

	// Use this for initialization
	void Start () {
	    // if we ever need a constructor then put it here
	}

    // add a card to the user's hand
    public void add(Card card)
    {

    }

    // remove a card from the user's hand
    public void remove(Card card)
    {

    }

    // check if the player's hand contains a certain card
    public Boolean hasCard(Card card)
    {

    }

    // returns an arraylist of all the cards in the user's hand
    public ArrayList<Card> getCards()
    {

    }

    //get the hand size of the player's hand
    public int getHandSize()
    {
        return hand.Count;
    }

    //dump the player's hand and get a new one from the deck
    // TODO: This shouldn't be in Hand, right? Hand should not know about the deck
    public ArrayList<card> getNewHand()
    {

    }

	// Update is called once per frame, should not be needed for Hand
	void Update () {

	}
}
