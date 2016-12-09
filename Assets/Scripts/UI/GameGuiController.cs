//@Author: Dehul Shingadia

using Assets.Scripts.New_Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace New_Scripts.UI
{
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

            if (currentPlayer == 0)
            {
// check for user input
                player0.add(deck.pop()); // player 0 picks a card
                Debug.Log("Player 0 picked a card");
            }
            if (currentPlayer == 1)
            {
//autoplay for ai, pick of play card
                player1.add(deck.pop()); // player 1 picks a card
                Debug.Log("Player 1 picked a card");
            }
            if (currentPlayer == 2)
            {
//autoplay for ai, pick or play card
                player2.add(deck.pop()); // player 2 picks a card
                Debug.Log("Player 2 picked a card");
            }
            if (currentPlayer == 3)
            {
//autoplay for ai, pick or play card
                player3.add(deck.pop()); // player 3 picks a card
                Debug.Log("Player 3 picked a card");
            }

            if (currentPlayer == 3)
            {
                currentPlayer = 0;
            }
            else
            {
                currentPlayer = currentPlayer + 1;
            }
        }



    }
}