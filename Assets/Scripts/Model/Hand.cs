// @Author: Nathaniel Baulch-Jones

using System;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    //Fields
    private List<Card> hand = new List<Card>(); // uncomment when working with method

    // Use this for initialization
    void Start()
    {
        // if we ever need a constructor then put it here
        hand = new List<Card>();
    }

    // add a card to the user's hand
    public void add(Card card)
    {
        hand.Add(card);
    }
    public void addAtIndex(int i, Card c)
    {
        hand[i] = c;
    }

    // remove a card from the user's hand
    public void remove(Card card)
    {
        hand.Remove(card);
    }
    public void removeAtIndex(int i) {
        hand.RemoveAt(i);
    }

    // check if the player's hand contains a certain card
    public Boolean hasCard(Card card)
    {
        Boolean x = hand.Contains(card);
        return x;
    }

    public Card getCardAtIndex(int i) {
        return hand[i];
    }

    // returns an arraylist of all the cards in the user's hand
    //public ArrayList<Card> getCards()
    //{
    //uncomment when wqorking on method
    //}

    //get the hand size of the player's hand
    public int getHandSize()
    {
        return hand.Count;
    }

    //dump the player's hand and get a new one from the deck
    // TODO: This shouldn't be in Hand, right? Hand should not know about the deck
    //public ArrayList<card> getNewHand()
    //{
    //uncomment when wqorking on method
    //}

    // Update is called once per frame, should not be needed for Hand
    void Update()
    {

    }


    //!! We need a method to keep track of what the last card picked was !!

}