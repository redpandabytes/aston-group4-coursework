// @Author: Nathaniel Baulch-Jones
// Please follow the naming conventions: http://answers.unity3d.com/questions/10571/where-are-the-rules-of-capitalization-documented.html

using System;
using UnityEngine;
using System.Collections;

public class Deck : MonoBehaviour
{
    //Fields
    //private Stack<card> cards;//uncomment when working on class

    // initialise our stack of cards here if needed
    void Start () {

	}

    //Tests if this stack is empty.
    public Boolean isEmpty()
    {
        //return cards.Count == 0; // uncomment
        return false;//<- delete when working on thie method
    }


    // Removes the object at the top of this stack and returns that object as the value of this function.
    public Card pop()
    {
        return null;
    }

	// Looks at the object at the top of this stack without removing it from the stack.
    public Card peek ()
    {
        return null;
    }

    //Pushes an item onto the top of this stack.
    public Card push()
    {
        return null;
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

}
