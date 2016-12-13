// @Author: Nathaniel Baulch-Jones

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameModel : GuildsElement
{

    //Fields
    private List<Player> _players; // TODO: Check there's no conflict with Unity "Player" Class
    private Deck _drawDeck;
    private Deck _discardDeck;
    private int _currentPlayer;
    private StaticAi _ai;
    private GameObject[] _faces;
    private const int GameMode = 1;
    private Card _currentCard;
    private int _difficulty;
    private int _noOfPlayers;

    private const int StartingHandSize = 7;
    private const int NumStandardCardsPerDeck = 10;

    private const int DefaultTurnLength = 4;
    private float _expiryCountDown = DefaultTurnLength;

    private bool reversedPlay = false; //(Crazy Proffessor)

    public void Initialise()
    {
        //Initialise a new game:
        _discardDeck = new Deck();
        _drawDeck = new Deck();
        _difficulty = 1; // TODO: this is hard coded for now
        _noOfPlayers = 4; // TODO: Different game modes may have <4 || >4 players?

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

        // add unique cards (only Triumph card thus far)
        Card triumph = new Card();
        triumph.Initialise(0, 0, null);
        _drawDeck.push(triumph);

        _drawDeck.shuffle();

        //SET UP PLAYERS
        // TODO: Only hardcoded for a single player right now
        _players = new List<Player>();

        String userName = "Player 1";
        _ai = new StaticAi();
        _ai.Initialise(_difficulty, _noOfPlayers);

        if (GameMode == 1) // TODO: Implement multiplayer mode
        {
            Player newPlayer = new Player();
            newPlayer.Initialise(userName, false);
            _players.Add(newPlayer);
            for (int p = 1; p < _noOfPlayers; p++)
            {
                Player ai = new Player();
                ai.Initialise("AI " + p, true);
                _players.Add(ai);
            }

            // Give players cards
            foreach (var curPlayer in _players)
            {
                var curHand = curPlayer.getHand();
                for (var i = 1; i <= StartingHandSize; i++)
                {
                    Card cardToAdd = _drawDeck.pop();
//                    Debug.Log("(Adding to starting hand): Guild " + cardToAdd.getGuild() + ", Value " + cardToAdd.getValue());
                    curHand.add(cardToAdd);
                }
            }

            // decide which player goes first, in single player the player is always at Index 0 in _players
            _currentPlayer = Random.Range(0, 4);

        }
    }

    public bool IsCardPlayable(int guildValue, int cardValue)
    {
        if (_discardDeck.getAmountOfCards() > 0)
        {
            // cards in the deck means we have to check if the supplied card is valid
            if (cardValue <= NumStandardCardsPerDeck)
            {
                return true; // standard cards can be played at any time
            }
            else
            {
                // special card attempting to be played
                return _discardDeck.peek().getGuild() == guildValue;
            }
        }
        else
        {
            // cards are always playable if there is nothing in the discard deck yet
            return true;
        }
    }

    public void ResetCountdownTimer()
    {
        _expiryCountDown = DefaultTurnLength;
    }


    public void UpdateCountDown()
    {
        _expiryCountDown -= Time.deltaTime;
        var curPlayer = app.model.GetCurrentPlayer();
        if (curPlayer == 0)
        {
            app.viewer.UpdateCountDown("     Player, it is your turn! (" + Mathf.Floor(_expiryCountDown + 1) + ")");
        }
        else
        {
            app.viewer.UpdateCountDown("CPU " + curPlayer + " is taking their turn! (" +
                                       Mathf.Floor(_expiryCountDown + 1) + ")");
        }

        if(_expiryCountDown <= 0)
        {
            Debug.Log("No action was taken by the player.");
            app.Notify(GameNotification.TimeRanOut, this, false, null);
            ResetCountdownTimer();
        }
    }



    public int GetStartingHandSize()
    {
        return StartingHandSize;
    }

    public int GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    public Card PeekInPlayCard()
    {
        if (!_discardDeck.isEmpty())
        {
            return _discardDeck.peek();
        }
        else
        {
            return null;
        }
    }

    public Hand GetPlayerHand(int playerId)
    {
        return _players[playerId].getHand();
    }

    public void StartTurn()
    {
        // TODO: Implement
//        _players[_currentPlayer].setDesiredAction();
//        GameAction choice = _players[_currentPlayer].getDesiredAction();
//        TakeAction(choice);
//
//        if (_players[_currentPlayer].isAi() == false)
//        {
//            _players[_currentPlayer].setDesiredAction();
//            choice = _players[_currentPlayer].getDesiredAction();
//            HandleAction(choice);
//        }
//        else
//        {
//            choice = _ai.AiTurn(_players[_currentPlayer]);
//            HandleAction(choice);
//        }
    }

    public void TakeAction(GameAction a)
    {
        //TODO: Implement

    }

    public void DrawToPlayer(int playerID, int amount)
    {
        // TODO: Code to handle the draw deck being empty
        for (var i = 0; i == amount; i++)
        {
            _players[playerID].getHand().add(_drawDeck.pop());
        }
        Debug.Log("Added " + amount + " card(s) to player " + playerID + "'s hand.");
    }

    public void EndTurn()
    {
        // TODO: Implement
        if (reversedPlay == false)
        {

            if (_currentPlayer == (_players.Count - 1))
            {
                _currentPlayer = 0;
            }
            else
            {
                _currentPlayer++;
            }
        }
        else
        {
            if (_currentPlayer == 0)
            {
                _currentPlayer = (_players.Count - 1);
            }
            else
            {
                _currentPlayer--;
            }
        }
            // IF PLAYER IS MISSING TURN INCREMENT AND SET THEIR BOOLEAN TO FALSE
        _ai.UpdateAiKnowledge(_currentPlayer, 1, PeekInPlayCard());
        StartTurn();
    }

    public void CheckForWinner()
    {
        for (int i = 0; i < _players.Count; i++) {
            if (_players[i].getHand().getHandSize() == 0) {
                EndGame();
                //Needs to pass on who won
            }
        }
    }

    public void EndGame()
    {
        throw new NotImplementedException();
    }

    // deal with a card or special action being taken
    public void HandleAction(GameAction gameAction)
    {
        // TODO: Handle The GameAction way more than I've done here
        // TODO: For example, handle them playing a card that was in their hand, remove from the hand, etc, etc...
        Debug.Log("The gameaction choice was: " + gameAction.getChoice());
        switch (gameAction.getChoice())
        {
            case null:
                DrawToPlayer(_currentPlayer, 1);
                Debug.Log("Warning: NULL ACTION");
                break;
            case GameNotification.TimeRanOut:
                DrawToPlayer(_currentPlayer, 1);
                break;
            case "cleanSlate":
                //discard hand and get new cards
                _players[_currentPlayer].setCleanSlate();
                for (int i = 0; i < _players[_currentPlayer].getHand().getHandSize(); i++)
                {
                    _discardDeck.push(_players[_currentPlayer].getHand().getCardAtIndex(i));
                    _players[_currentPlayer].getHand().addAtIndex(i, _drawDeck.pop());
                }
                break;
            case "pickUp":
                // not done
            break;
            case "playCard":
                //check if card equals value or guild
                Card c = gameAction.getSelectedCard();
                if ((c.getGuild() == _discardDeck.peek().getGuild())
                    || (c.getValue() == _discardDeck.peek().getGuild())
                    || c.getGuild() == 0)
                {
                    //TRIUMPH CARD
                    if (c.getValue() == 0)
                    {
                        //add 5 cards to each player excl. current
                        for (int i = 0; i < _players.Count; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (i != _currentPlayer)
                                {
                                    _players[i].getHand().add(_drawDeck.pop());
                                }
                            }
                        }
                        //then remove card from player
                    }
                    //WEAPON CARD
                    else if (c.getValue() < 11)
                    {
                        _discardDeck.push(c);
                        // _players[_currentPlayer].getHand().hasCard(c); remove card
                    }
                    //SPECIAL CARD
                    else
                    {
                        _discardDeck.push(c);
                        //remove card from player
                        switch (c.getValue())
                        {
                            case 11:
                                //Professor
                                //Takes selectedCard and secondCard in GameAction
                                //Swaps the cards with two random from targetedPlayer in GameAction
                                //Makes sure the same card slot in the targets hand is not chosen twice
                                Hand targetsHand = _players[gameAction.getTarget()].getHand();
                                var ran = Random.Range(0, (targetsHand.getHandSize() - 1));
                                _players[gameAction.getTarget()].getHand().addAtIndex(ran, gameAction.getSelectedCard());
                                var newRan = Random.Range(0, (targetsHand.getHandSize() - 1));
                                while (newRan == ran) {
                                    newRan = Random.Range(0, (targetsHand.getHandSize() - 1));
                                }
                                _players[gameAction.getTarget()].getHand().addAtIndex(newRan, gameAction.getSelectedCard());
                                break;
                            case 12:
                                //Crazy Prof
                                reversedPlay = !reversedPlay;
                                break;
                            case 13:
                                //ShieldBearer
                                //targetedPlayer in GameAction cannot equal currentPlayer
                                //One turn only
                                break;
                            case 14:
                                //Apprentice
                                for (var i = 0; i < _players.Count; i++)
                                {
                                    if (i != _currentPlayer)
                                    {
                                        _players[i].getHand().add(_drawDeck.pop());
                                    }
                                }
                                break;
                            case 15:
                                //Messenger
                                //Rolls back current player before the end increment?
                                break;
                            case 16:
                                //Spy
                                //Returns hand of another player
                                //?: Where to put this view method so players can't access it normally
                                break;
                            case 17:
                                //Thug
                                //Change suit of card in middle
                                //?: Or add a new card to middle?
                                break;
                            case 18:
                                //Jester
                                //Player has boolean missingTurn
                                //If true, skips player and sets missingTurn to false
                                _players[gameAction.getTarget()].setMissingTurn();
                                break;
                            case 19:
                                //Smith (only for non triumph cards)
                                if (_discardDeck.peek().getGuild() != 0)
                                {
                                    _players[_currentPlayer].getHand().add(_discardDeck.pop());
                                }
                                break;
                            case 20:
                                //Wizard
                                //Swap hand objects
                                //Create a temp hand to store while swapping
                                break;
                        }
                    }

                }
            break;
            default:
                Debug.Log("Unknown");
                break;
        }

        EndTurn(); // implement the player's turn
    }

    public bool ShouldAiTakeTurn()
    {
        var sensitivity = 200; // the higher the sensitivity, the less likely the AI is to trigger
        return ((Random.Range(0, sensitivity) == 1));
    }

    public GameAction AITurn() {
       return _ai.AiTurn(_players[_currentPlayer]);
        //HandleAction(choice);
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateCountDown();
        if (_players[GetCurrentPlayer()].isAi() && ShouldAiTakeTurn())
        {
            // game logic for triggering the AI's turn
            GameAction choice = AITurn();
            app.Notify(GameNotification.AiTookTurn, this, choice);
            Debug.Log("I'm about to take the AI's turn");
        }
    }
}