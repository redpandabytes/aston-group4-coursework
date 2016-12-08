using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.New_Scripts {
    public class GameController : MonoBehaviour, IGameController {

        //Fields
        private List<Player> _players; // TODO: Check there's no conflict with Unity "Player" Class
        private Deck _drawDeck;
        private Deck _discardDeck;
        private int _currentPlayer;
        private AiController _ai;
        private GameObject[] _faces;
        private const int GameMode = 1;

        private const int StartingHandSize = 7;

        // Use this for initialization
        public void Start () {
            // setup game objects we need
            _discardDeck = new Deck();
            _drawDeck = new Deck();

            // For guilds 1-4, create cards 1-20 and add to the draw deck
            for (int g = 1; g < 5; g++)
            {
                for (int v = 1; v < 20; v++)
                {
                    Card c = new Card();
                    //TODO: Pass a face
                    c.Initialise(g, v, null);
                    _drawDeck.push(c);
                }
            }
            Card triumph = new Card();
            triumph.Initialise(0, 0, null);
            _drawDeck.push(triumph);
            _drawDeck.shuffle();

            Debug.Log(_drawDeck.getAmountOfCards());

            //SET UP PLAYERS
            // TODO: Only hardcoded for a single player right now
            _players = new List<Player>();

            //For singleplayer:
            int difficulty = 1;
            int noOfPlayers = 4;
            String userName = "Player 1";
            _ai = new AiController();
            _ai.Initialise(difficulty, noOfPlayers);
            if (GameMode == 1)
            {
                Player newPlayer = new Player();
                newPlayer.Initialise(userName, false);
                _players.Add(newPlayer);
                for (int p = 1; p < noOfPlayers; p++)
                {
                    Player ai = new Player();
                    ai.Initialise("AI " + p, true);
                    _players.Add(ai);
                }

                foreach (Player player in _players)
                {
                    Debug.Log(_players.Count);
                    Debug.Log(player.getCleanSlate());
                    player.setCleanSlate(true);
                    Debug.Log(player.getCleanSlate());
                }
                _drawDeck.shuffle();

                var lol = _drawDeck.pop();
                Debug.Log(lol.getGuild());

                // give players cards
                foreach (var curPlayer in _players)
                {
                    Hand curHand = curPlayer.getHand();
                    for (var i = 0; i <= StartingHandSize; i++)
                    {
                        curHand.add(_drawDeck.pop());
                    }
                }

                Debug.Log(_players[0].getHand().getHandSize());

                // decide which player goes first

                // Finished :D
            }
            //
            //else{
                //Multiplayer Set Up
            //}
        }

        public void StartTurn()
        {
            // TODO: Implement
        }

        public void TakeAction()
        {
            throw new NotImplementedException();
        }

        public void EndTurn()
        {
            // TODO: Implement
        }

        public void CheckForWinner()
        {
            // TODO: Implement
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void PlayCard()
        {
            // TODO: Implement
        }

        // Update is called once per frame
        public void Update () {
            // GAME LOGIC WILL BE RAN HERE!
        }
    }
}