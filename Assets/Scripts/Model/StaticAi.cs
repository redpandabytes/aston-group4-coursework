﻿using System.Collections.Generic;
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
public Action AITurn(Player x)
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
public Action easyPlay(Player x)
{
    Player p = x;
    Hand h = p.getHand();
        //Player has only one card of type weapon:
        if (h.getHandSize() == 1) {
            Card c = h.getCardAtIndex(0);
            if ((c.getValue() < 10) && ((c.getValue() == cardInPlay.getValue()) || c.getGuild() == cardInPlay.getGuild())){
                Action a = new Action();
                a.Initialise("playCard", c);
                return a;
            } else {
                Action a = new Action();
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
            Card chosen = viableChoices[Random.Range(0, viableChoices.Count)];
            Action a = new Action();
            a.Initialise("playCard", chosen);
            return a;
        }
}
    public Action mediumPlay() {

        return new Action();
    }
    public Action hardPlay() {
        return new Action();
     }
    public void updateAIKnowledge() { }
} 
