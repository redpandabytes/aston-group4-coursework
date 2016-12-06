//@Author: Dehul Shingadia

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;


public class GameGuiController : MonoBehaviour
{
    //all the players
    public Hand player0;
    public Hand player1;
    public Hand player2;
    public Hand player3;

    public Deck deck; //stack of unplayed cards


    public Button pickCard;

    //used to keep track of current player
    private int currentPlayer;


    void popCard()
    {
        if (currentPlayer == 1)
        {// check for user input 

        }
        if (currentPlayer == 2)
        {//autoplay for ai, pick of play card

        }
        if (currentPlayer == 3)
        {//autoplay for ai, pick or play card

        }
        if (currentPlayer == 4)
        {//autoplay for ai, pick or play card

        }
    }

}
