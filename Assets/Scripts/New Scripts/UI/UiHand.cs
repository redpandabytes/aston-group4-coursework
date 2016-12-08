using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UiHand : MonoBehaviour {


    public List<Card> Hand;// list holding all the cards

    void Start()
    {
        Hand = new List<Card>();
    }

    public void add(Card card)//pas through uiCard not card
    {
        Hand.Add(card);
    }

    void remove(Card card)
    {
        Hand.Remove(card);
    }

    
}
