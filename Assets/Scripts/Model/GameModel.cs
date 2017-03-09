// @Author: Nathaniel Baulch-Jones

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private const int DefaultTurnLength = 10;
    private float _expiryCountDown;

    private bool reversedPlay = false; // (Crazy Professor) card in action
    private bool messenger = false; //MESSENGER

    public void Initialise()
    {
        //Script procedure to initialise a new game:
        _discardDeck = new Deck();
        _drawDeck = new Deck();
        _difficulty = 1; // TODO: this is hard coded for now
        _noOfPlayers = 4; // TODO: Different game modes may have <4 || >4 players?
        _expiryCountDown = DefaultTurnLength;

        // For guilds 1-4, create cards 1-20 and add to the draw deck
        // Value DB Google Drive: https://docs.google.com/spreadsheets/d/1aoWqoUjY1dmnW7_qooTxKf3aJFOO_YblTjn5QbRmTHU/
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

        // Shuffle is required for distributing cards to players randomly
        _drawDeck.shuffle();

        //SET UP PLAYERS
        // TODO: Only hardcoded for a single player right now
        _players = new List<Player>();

        _ai = new StaticAi();
        _ai.Initialise(_difficulty, _noOfPlayers);

        if (GameMode == 1) // GameMode 1 is a singleplayer game
        {
            Player newPlayer = new Player();
            String userName = "Player 1";
            newPlayer.Initialise(userName, false);
            _players.Add(newPlayer);
            for (int p = 1; p < _noOfPlayers; p++) // initalise AIs for each other player (4 in a standard single player)
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
                    curHand.add(cardToAdd);
                }
            }

            // decide which player goes first, in single player the player is always at Index 0 in _players
            _currentPlayer = Random.Range(0, 4);
 

        }
        else
        {
            // TODO: Multiplayer setup
        }
    }

    // Implement basic anti-cheat functionality. Model should decline invalid plays regardless of action
    public bool IsCardPlayable(int guildValue, int cardValue)
    {
        if (_discardDeck.getAmountOfCards() > 0)
        {
            if (_discardDeck.peek().getGuild() == guildValue)
            {
                return true;
            }
            else if (_discardDeck.peek().getValue() == cardValue)
            {
                return true;
            }
            else
            {
                return guildValue == 0; // Triumph card is always playable
            }
        }
        // cards are always playable if there is nothing in the discard deck yet
        //exception: can't play Smith if discard deck is empty
        else if (cardValue == 19) {
            return false; 
        }
        return true;
    }

    public void ResetCountdownTimer()
    {
        Debug.Log("Reset countdown");
        _expiryCountDown = DefaultTurnLength;
    }


    public void UpdateCountDown()
    {
        _expiryCountDown -= Time.fixedDeltaTime;
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
            Debug.Log("(GameModel.cs) No action was taken by the player.");
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
    }

    public void TakeAction(GameAction a)
    {
        //TODO: Implement

    }

    public void DrawToPlayer(int playerID, int amount)
    {
        // TODO: Code to handle the draw deck being empty
        for (var i = 0; i < amount; i++)
        {
            _players[playerID].getHand().add(_drawDeck.pop());
            Debug.Log("(GameModelcs) Actually added a card to their hand.");
        }
        Debug.Log("(GameModel.cs) Added " + amount + " card(s) to player " + playerID + "'s hand.");
    }

    public void EndTurn()
    {
        // TODO: Implement
        if (reversedPlay == false)
        {

            if (messenger == true) {
                messenger = false;
            }
                else if (_currentPlayer == (_players.Count - 1))
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
            if (messenger == true)
            {
                messenger = false;
            }
            else if (_currentPlayer == 0)
            {
                _currentPlayer = (_players.Count - 1);
            }
            else
            {
                _currentPlayer--;
            }
        }
        if (_players[_currentPlayer].getMissingTurn() == true) {
            Debug.Log(_currentPlayer + " is MISSING THEIR TURN");
            _players[_currentPlayer].setMissingTurn();
            EndTurn();
        }
            // IF PLAYER IS MISSING TURN INCREMENT AND SET THEIR BOOLEAN TO FALSE
        ResetCountdownTimer();
        _ai.UpdateAiKnowledge(_currentPlayer, 1, PeekInPlayCard());
        CheckForWinner(); // check for winner before we increment anything
        StartTurn(); // move on to the next player
    }

    public void CheckForWinner()
    {
        for (int i = 0; i < _players.Count; i++) {
            if (_players[i].getHand().getHandSize() == 0) {
//                EndGame(); // TODO: DO this properly
                if (_players[i].isAi())
                {
                    SceneManager.LoadScene("Defeat");
                }
                else
                {
                    SceneManager.LoadScene("Victory_Scene");
                }
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
        Debug.Log("(GameModel.cs) The gameaction choice was: " + gameAction.getChoice());
        switch (gameAction.getChoice())
        {
            case null:
                Debug.Log("(GameModel.cs) Warning: NULL ACTION");
                break;
            case GameNotification.TimeRanOut:
                DrawToPlayer(_currentPlayer, 1);
                Debug.Log("(GameModel.cs) Time ran out. Player drew a card as punishment.");
                break;

            case GameNotification.CardPickedUp:
                Debug.Log("(GameModel.cs) (Predraw) The player currently has " + _players[_currentPlayer].getHand().getHandSize());
                DrawToPlayer(_currentPlayer, 1);
                Debug.Log("(GameModel.cs) I am drawing to Player " + _currentPlayer + ". They now have " + _players[_currentPlayer].getHand().getHandSize() + " cards.");
                // deal with card picked up
                break;

            case GameNotification.CleanSlate:
                //discard hand and get new cards
                _players[_currentPlayer].setCleanSlate();
                for (int i = 0; i < _players[_currentPlayer].getHand().getHandSize(); i++)
                {
                    _discardDeck.push(_players[_currentPlayer].getHand().getCardAtIndex(i));
                    _players[_currentPlayer].getHand().addAtIndex(i, _drawDeck.pop());
                }
                break;

            case GameNotification.CardPlayed:
//                Debug.Log("(GameModel.cs) A card was played");
                _discardDeck.push(gameAction.getSelectedCard());

                //WARNING: Check for Triumph card first because if it's played it breaks everything else
                //This is a temporary workaround for the demo ONLY
                //TODO: Fix spaghetti

                if (gameAction.WasTriumphCard())
                {
                    // TODO: For the time being Triumph is pretty shit, basically just so it does something in the demo
                    //  var tempHand = _players[0].getHand();
                    //  var tempHand2 = _players[1].getHand();
                    Debug.Log("OOOOOOOOOOOOOOOOOO TRIUMPH CARD");
                    //  _players[0].setHand(tempHand2);
                    //   _players[1].setHand(tempHand);
                    _discardDeck.push(_players[0].getHand().getCardAtIndex(0));
                    _players[0].getHand().removeAtIndex(0);
                    _discardDeck.push(_players[0].getHand().getCardAtIndex(0));
                    _players[0].getHand().removeAtIndex(0);
                    for (int i = 1; i < _players.Count; i++)
                    {
                        _players[i].getHand().add(_drawDeck.pop());
                    }

                    // this should work I think
                    //   break;
                }
                else if (gameAction.getSelectedCard().getValue() == 14)
                {
                    //Apprentice
                    Debug.Log("APPRENTICE - EVERYONE PICK UP");
                    for (var i = 0; i < _players.Count; i++)
                    {
                        if (i != _currentPlayer)
                        {
                            _players[i].getHand().add(_drawDeck.pop());
                        }
                    }
                    //  break;
                }
                else if (gameAction.getSelectedCard().getValue() == 12)
                {
                    Debug.Log("CRAZY PROFESSOR- REVERSED PLAY");
                    reversedPlay = !reversedPlay;
                    //  break;
                }
                else if(gameAction.getSelectedCard().getValue() == 17)
                {
                    Debug.Log("THUG - change card in middle");
                    
                }
                else if (gameAction.getSelectedCard().getValue() == 13)
                {
                    Debug.Log("SHIELDBEARER - immune for one round");

                    
                }
                //TODO: decide what happens when 19 used on first turn - cant pick up nothing
                else if (gameAction.getSelectedCard().getValue() == 19)
                {
                    Debug.Log("SMITH- PICKED UP FROM MIDDLE");
                    _players[_currentPlayer].getHand().add(_discardDeck.second());

                }
                else if (gameAction.getSelectedCard().getValue() == 15)
                {
                    Debug.Log("MESSENGER - EXTRA TURN");
                    messenger = true;
                }
                else if (gameAction.getSelectedCard().getValue() == 200)
                {
                    //Not working right now 
                    Debug.Log("WIZARD- SWAP HANDS");
                    int target = Random.Range(0, 4);
                    while (target == _currentPlayer)
                    {
                        target = Random.Range(0, 4);
                    }
                    
             
                    Hand temp1 = _players[_currentPlayer].getHand();
                    Hand temp2 = _players[target].getHand();
                    _players[_currentPlayer].setHand(temp2);
                    _players[target].setHand(temp1);
                   
                } 
                //TODO: get player to select target
                else if (gameAction.getSelectedCard().getValue() == 18) {
                    Debug.Log("JESTER - MISSES TURN");
                    int target = Random.Range(0, 4);
                    while (target == _currentPlayer)
                    {
                        target = Random.Range(0, 4);
                    }

                    if (_players[target].getMissingTurn() == false)
                    {
                        _players[target].setMissingTurn();
                    }
                    else { }

                }
                removeCardPlayed(gameAction);

                // Remove card by iterating through player's hand
                //TODO: Find solution using references instead of loops - this is fine because it's not too inefficient - but it's quite messy.


                // Update the model depending on special actions of the card
                // TODO: Sorry whoever coded this game logic, I coded most of it out for now as for the MVP I'm just implementing the Triumph card

                //check if card equals value or guild
                //                var c = gameAction.getSelectedCard();
                //                if ((c.getGuild() == _discardDeck.peek().getGuild())
                //                    || (c.getValue() == _discardDeck.peek().getGuild())
                //                    || c.getGuild() == 0)
                //                {
                //                    //TRIUMPH CARD
                //                    if (c.getValue() == 0)
                //                    {
                //                        //add 5 cards to each player excl. current
                //                        for (int i = 0; i < _players.Count; i++)
                //                        {
                //                            for (int j = 0; j < 5; j++)
                //                            {
                //                                if (i != _currentPlayer)
                //                                {
                //                                    _players[i].getHand().add(_drawDeck.pop());
                //                                }
                //                            }
                //                        }
                //                        //then remove card from player
                //                    }
                //                    //WEAPON CARD
                //                    else if (c.getValue() < 11)
                //                    {
                //                        _discardDeck.push(c);
                //                        // _players[_currentPlayer].getHand().hasCard(c); remove card
                //                    }
                //                    //SPECIAL CARD
                //                    else
                //                    {
                //                        _discardDeck.push(c);
                //                        //remove card from player
                //                        switch (c.getValue())
                //                        {
                //                            case 11:
                //                                //Professor
                //                                //Takes selectedCard and secondCard in GameAction
                //                                //Swaps the cards with two random from targetedPlayer in GameAction
                //                                //Makes sure the same card slot in the targets hand is not chosen twice
                //                                Hand targetsHand = _players[gameAction.getTarget()].getHand();
                //                                var ran = Random.Range(0, (targetsHand.getHandSize() - 1));
                //                                _players[gameAction.getTarget()].getHand().addAtIndex(ran, gameAction.getSelectedCard());
                //                                var newRan = Random.Range(0, (targetsHand.getHandSize() - 1));
                //                                while (newRan == ran) {
                //                                    newRan = Random.Range(0, (targetsHand.getHandSize() - 1));
                //                                }
                //                                _players[gameAction.getTarget()].getHand().addAtIndex(newRan, gameAction.getSelectedCard());
                //                                break;
                //                            case 12:
                //                                //Crazy Prof - DONE
                //                                reversedPlay = !reversedPlay;
                //                                break;
                //                            case 13:
                //                                //ShieldBearer
                //                                //targetedPlayer in GameAction cannot equal currentPlayer
                //                                //One turn only
                //                                break;
                //                            case 14:
                //                                //Apprentice - DONE
                //                                for (var i = 0; i < _players.Count; i++)
                //                                {
                //                                    if (i != _currentPlayer)
                //                                    {
                //                                        _players[i].getHand().add(_drawDeck.pop());
                //                                    }
                //                                }
                //                                break;
                //                            case 15:
                //                                //Messenger - DONE
                //                                //Rolls back current player before the end increment?
                //                                break;
                //                            case 16:
                //                                //Spy
                //                                //Returns hand of another player
                //                                //?: Where to put this view method so players can't access it normally
                //                                break;
                //                            case 17:
                //                                //Thug
                //                                //Change suit of card in middle
                //                                //?: Or add a new card to middle?
                //                                break;
                //                            case 18:
                //                                //Jester  - DONE BUT NEEDS TO LET PLAYER CHOOSE
                //                                //Player has boolean missingTurn
                //                                //If true, skips player and sets missingTurn to false
                //                                _players[gameAction.getTarget()].setMissingTurn();
                //                                break;
                //                            case 19:
                //                                //Smith (only for non triumph cards)   - DONE
                //                                if (_discardDeck.peek().getGuild() != 0)
                //                                {
                //                                    _players[_currentPlayer].getHand().add(_discardDeck.pop());
                //                                }
                //                                break;
                //                            case 20:
                //                                //Wizard
                //                                //Swap hand objects
                //                                //Create a temp hand to store while swapping
                //                                break;
                //                        }
                //                    }
                //
                //                }
                break;
            default:
                Debug.Log("(GameModel.cs) Unknown Command");
                break;
        }

        EndTurn(); // implement the player's turn
    }

    public bool ShouldAiTakeTurn()
    {
        var sensitivity = 50; // the higher the sensitivity, the less likely the AI is to trigger
        return ((Random.Range(0, sensitivity) == 1) && (_expiryCountDown < (DefaultTurnLength / 1.5f)) );
    }

    public GameAction GenerateAiAction() {
       return _ai.AiTurn(_players[_currentPlayer]);
    }

    public void removeCardPlayed(GameAction gameAction)
    {
        Debug.Log("(GameModel.cs) Attempting to remove the player's played card. Hand size is: " + _players[_currentPlayer].getHand().getHandSize());
        for (var i = 0; i <= _players[_currentPlayer].getHand().getHandSize() - 1; i++)
        {
            if ((_players[_currentPlayer].getHand().getCardAtIndex(i).getGuild() ==
                 gameAction.getSelectedCard().getGuild()) &&
                ((_players[_currentPlayer].getHand().getCardAtIndex(i).getValue() ==
                  gameAction.getSelectedCard().getValue())))
            {
                Debug.Log("(GameModel.cs) About to remove card! Was looking for '" + gameAction.getSelectedCard().getGuild() + ", " + gameAction.getSelectedCard().getValue() + "'. Found '" + _players[_currentPlayer].getHand().getCardAtIndex(i).getGuild() + ", " + (_players[_currentPlayer].getHand().getCardAtIndex(i).getValue()) + "' :).");
                _players[_currentPlayer].getHand().removeAtIndex(i);
                break;
            }
        }
    }
    // Update is called once per frame
    public void Update()
    {
        UpdateCountDown();
        if (_players[GetCurrentPlayer()].isAi() && ShouldAiTakeTurn())
        {
            // game logic for triggering the AI's turn
            GameAction choice = GenerateAiAction();
            app.Notify(GameNotification.AiTookTurn, this, choice);
        }
    }
}