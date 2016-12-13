using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StaticAi
{
    //Fields
    private int _difficulty;
    private int _noOfPlayers;
    private Card cardInPlay;
    private int[] playersHandSizes;

    public void Initialise(int difficulty, int noOfPlayers)
    {
        this._difficulty = difficulty;
        this._noOfPlayers = noOfPlayers;
        playersHandSizes = new int[_noOfPlayers];
        for (int i = 0; i < _noOfPlayers; i++)
        {
            playersHandSizes[i] = 7;
        }
        cardInPlay = null;
    }

//Initialization of AIController
private void Start()
{
}

//Method for when player turn is passed to AI
public GameAction AITurn(Player x)
{
    if (_difficulty == 3)
    {
        return hardPlay();
    }
    else if (_difficulty == 2)
    {
        return mediumPlay();
    }
    else {
        return easyPlay(x);
    }
} 

//Easy AI turn
public GameAction easyPlay(Player x)
{
    Player p = x;
    Hand h = p.getHand();
        //Player has only one card of type weapon:
        if (h.getHandSize() == 1) {
            Card c = h.getCardAtIndex(0);
            if ((c.getValue() < 10) && ((c.getValue() == cardInPlay.getValue()) || c.getGuild() == cardInPlay.getGuild())){
                GameAction a = new GameAction();
                a.Initialise("playCard", c);
                return a;
            } else {
                GameAction a = new GameAction();
                a.Initialise("pickUp", null);
                return a;
            }
        } else{
            //Sort through viable cards and pick a random one
            List<Card> viableChoices = new List<Card>();
            for (int i=0; i < h.getHandSize(); i++)
            {
                Card c = h.getCardAtIndex(i);
                if  ((c.getValue() == cardInPlay.getValue()) || c.getGuild() == cardInPlay.getGuild())
                {
                    viableChoices.Add(c);
                }
            }
            if (viableChoices.Count != 0)
            {
                Card chosen = viableChoices[Random.Range(0, viableChoices.Count)];
                GameAction a = new GameAction();
                a.Initialise("playCard", chosen);
                return a;
            }
            else
            {
                GameAction a = new GameAction();
                a.Initialise("pickUp", null);
                return a;
            }
        }
}
    public GameAction mediumPlay() {

        return new GameAction();
    }
    public GameAction hardPlay() {
        return new GameAction();
     }
  //  public void updateAIKnowledge(int playerNo, int noOfCardsPlayed) {
  //  }
} 
