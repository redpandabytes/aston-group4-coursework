using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GuildsOfTriumphGameController : MonoBehaviour
    {
        int dealersFirstCard = -1;
        //Players


        public CardStack player0;
        public CardStack player1;
        public CardStack player2;
        public CardStack player3;

        public CardStack dealer;
        public CardStack deck;

        public Button hitButton;
        public Button stickButton;
        public Button playAgainButton;

        public Text winnerText;

        CardStack[] playerArray = new CardStack[4];


        /*
     * Cards dealt to each player
     * First player hits/sticks/bust
     * Dealer's turn; must have minimum of 17 score hand
     * Dealers cards; first card is hidden, subsequent cards are facing
     */

        #region Public methods

        public void Hit()
        {
            player1.Push(deck.Pop());
            if (player1.HandValue() > 21)
            {
                hitButton.interactable = false;
                stickButton.interactable = false;
                StartCoroutine(DealersTurn());
            }
        }

        public void Stick()
        {
            hitButton.interactable = false;
            stickButton.interactable = false;
            StartCoroutine(DealersTurn());
        }

        public void PlayAgain()
        {
            playAgainButton.interactable = false;

            player1.GetComponent<CardStackView>().Clear();
            dealer.GetComponent<CardStackView>().Clear();
            deck.GetComponent<CardStackView>().Clear();
            deck.CreateDeck();

            winnerText.text = "";

            hitButton.interactable = true;
            stickButton.interactable = true;

            dealersFirstCard = -1;

            StartGame();
        }

        #endregion

        #region Unity messages

        void Start()
        {
            StartGame();
        }

        #endregion

        void StartGame()
        {
            playerArray[0] = player0;
            playerArray[1] = player1;
            playerArray[2] = player2;
            playerArray[3] = player3;


            for (int i = 0; i <= playerArray.Length; i++)
            {
                if (i == 3)
                {
                    player3.Push(deck.Pop());
                    //Add wait for 1sec
                    System.Threading.Thread.Sleep(2000);

                    }
                    if (i == 2)
                    {
                        player2.Push(deck.Pop());
                        //Add wait for 2sec
                        System.Threading.Thread.Sleep(2000);
                        if (i == 1)
                        {
                            player1.Push(deck.Pop());
                            //Add wait for 2sec
                            System.Threading.Thread.Sleep(2000);
                            }


                        i = 0;
                    }
                }

                //Cheack for button press

                // for ( i < 2; i++)
                // {
                //     player1.Push(deck.Pop());
                //     HitDealer();
                // }

            }            


            


        

        /// <summary>
        /// curent player
        /// 
        /// 
        /// 
        /// 
        /// while( int i= 1; i <= 4;i++){
        ///     if(
        /// }
        /// 
        /// 
        /// </summary>

           
       // void currentPlayer() {
            



        //}

        void HitDealer()
        {
            int card = deck.Pop();

            if (dealersFirstCard < 0)
            {
                dealersFirstCard = card;
            }

            dealer.Push(card);
            if (dealer.CardCount >= 2)
            {
                CardStackView view = dealer.GetComponent<CardStackView>();
                view.Toggle(card, true);
            }
        }

        IEnumerator DealersTurn()
        {
            hitButton.interactable = false;
            stickButton.interactable = false;

            CardStackView view = dealer.GetComponent<CardStackView>();
            view.Toggle(dealersFirstCard, true);
            view.ShowCards();
            yield return new WaitForSeconds(1f);

            while (dealer.HandValue() < 17)
            {
                HitDealer();
                yield return new WaitForSeconds(1f);
            }

            if (player1.HandValue() > 21 || (dealer.HandValue() >= player1.HandValue() && dealer.HandValue() <= 21))
            {
                winnerText.text = "Sorry-- you lose";
            }
            else if (dealer.HandValue() > 21 || (player1.HandValue() <= 21 && player1.HandValue() > dealer.HandValue()))
            {
                winnerText.text = "Winner, winner! Chicken dinner";
            }
            else
            {
                winnerText.text = "The house wins!";
            }

            yield return new WaitForSeconds(1f);
            playAgainButton.interactable = true;
        }
    }
}
