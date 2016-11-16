using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour
{
    //Fields
    //private List<card> hand;// uncomment when working wiht method

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
        return false ; // change  false is jts a place holder
    }

    // returns an arraylist of all the cards in the user's hand
    //public ArrayList<Card> getCards()
    //{
        //uncomment when wqorking on method
    //}

    //get the hand size of the player's hand
    public int getHandSize()
    {
        //return hand.Count;// uncomment when wokring on this method
        return 0;//<- deleted when working on this method
    }

    //dump the player's hand and get a new one from the deck
    // TODO: This shouldn't be in Hand, right? Hand should not know about the deck
    //public ArrayList<card> getNewHand()
    //{
        //uncomment when wqorking on method
    //}

	// Update is called once per frame, should not be needed for Hand
	void Update () {

	}
}
