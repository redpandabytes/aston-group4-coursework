// @Author: Nathaniel Baulch-Jones
// Please follow the naming conventions: http://answers.unity3d.com/questions/10571/where-are-the-rules-of-capitalization-documented.html

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    //Fields
    private Stack<Card> deck = new Stack<Card>();

    // initialise our stack of cards here if needed
    void Awake () {

	}

    //Tests if this stack is empty.
    public Boolean isEmpty()
    {
        if (deck.Count == 0)
        {
            return true;
        }
        else {
            return false;
        }
    }


    // Removes the object at the top of this stack and returns that object as the value of this function.
    public Card pop()
    {
        Card c = deck.Pop();
        return c; 
    }

	// Looks at the object at the top of this stack without removing it from the stack.
    public Card peek()
    {
       Card x = deck.Peek();
       return x; 
    }

    //Pushes an item onto the top of this stack.
    public void push(Card c)
    {
        deck.Push(c);
    }

    public int getAmountOfCards()
    {
        return deck.Count;
    }

    //Returns the 1-based position where an card is on this stack.
    public Card searchDeck(Card card)
    {
        // card may not exist in the stack
        try
        {
            // TODO : Search for the card
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Exception:" + e.ToString());
        }
        return null;
    }

    //Shuffles deck. 
    public void shuffle() {

    }

}
