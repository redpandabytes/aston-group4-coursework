using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CardStack : MonoBehaviour
    {
        private List<int> _cards;

        public bool isGameDeck;

        public bool HasCards
        {
            get { return _cards != null && _cards.Count > 0; }
        }

        public event CardEventHandler CardRemoved;
        public event CardEventHandler CardAdded;

        public int CardCount
        {
            get
            {
                if (_cards == null)
                {
                    return 0;
                }
                else
                {
                    return _cards.Count;
                }
            }
        }

        public IEnumerable<int> GetCards()
        {
            foreach (int i in _cards)
            {
                yield return i;
            }
        }

        public int Pop()
        {

            //GuildsOfTriumphGameController.setPlayer();

            var temp = _cards[0];
            _cards.RemoveAt(0);

            if (CardRemoved != null)
            {
                CardRemoved(this, new CardEventArgs(temp));
            }

            Debug.Log("The value of this card is " + temp);
            return temp;
        }

        public void Push(int card)
        {
            _cards.Add(card);

            if (CardAdded != null)
            {
                CardAdded(this, new CardEventArgs(card));
            }
        }

        public int HandValue()
        {
            var total = 0;
            var aces = 0;

            foreach (var card in GetCards())
            {
                var cardRank = card % 13;

                if (cardRank <= 8)
                {
                    cardRank += 2;
                    total = total + cardRank;
                }
                else if (cardRank > 8 && cardRank < 12)
                {
                    cardRank = 10;
                    total = total + cardRank;
                }
                else
                {
                    aces++;
                }
            }

            for (var i = 0; i < aces; i++)
            {
                if (total + 11 <= 21)
                {
                    total = total + 11;
                }
                else
                {
                    total = total + 1;
                }
            }

            return total;
        }

        public void CreateDeck()
        {
            _cards.Clear();
            for (var i = 0; i <= 96; i++) // fix this magic number pls!!!
            {
                _cards.Add(i);
            }

            var n = _cards.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Range(0, n + 1);
                var temp = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = temp;
            }
        }

        public void Reset()
        {
            _cards.Clear();
        }

        private void Awake()
        {
            _cards = new List<int>();
            if (isGameDeck)
            {
                CreateDeck();
            }
        }
    }
}
