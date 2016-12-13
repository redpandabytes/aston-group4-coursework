using System.Collections.Generic;
using Random = UnityEngine.Random;

public class StaticAi
{
    //Fields
    private int _difficulty;
    private int _noOfPlayers;
    private Card _cardInPlay;
    private int[] _playersHandSizes;

    public void Initialise(int difficulty, int noOfPlayers)
    {
        _difficulty = difficulty;
        _noOfPlayers = noOfPlayers;
        _playersHandSizes = new int[_noOfPlayers];
        for (int i = 0; i < _noOfPlayers; i++)
        {
            _playersHandSizes[i] = 7;
        }
        _cardInPlay = null;
    }

//Initialization of AIController
private void Start()
{
}

//Method for when player turn is passed to AI
public GameAction AiTurn(Player x)
{
    if (_difficulty == 3)
    {
        return HardPlay();
    }
    else if (_difficulty == 2)
    {
        return MediumPlay();
    }
    else {
        return EasyPlay(x);
    }
} 

//Easy AI turn
public GameAction EasyPlay(Player x)
{
    Player p = x;
    Hand h = p.getHand();
        //Player has only one card of type weapon:
        if (h.getHandSize() == 1) {
            Card c = h.getCardAtIndex(0);
            if ((c.getValue() < 10) && ((c.getValue() == _cardInPlay.getValue()) || c.getGuild() == _cardInPlay.getGuild())){
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
                if  ((c.getValue() == _cardInPlay.getValue()) || c.getGuild() == _cardInPlay.getGuild())
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
    public GameAction MediumPlay() {

        return new GameAction();
    }
    public GameAction HardPlay() {
        return new GameAction();
     }
    //noOfCardsPlayed needs to know if it played none and picked up one
    public void UpdateAiKnowledge(int playerNo, int noOfCardsPlayed, Card cardInPlay) {
        this._cardInPlay = cardInPlay;
        _playersHandSizes[playerNo] = _playersHandSizes[playerNo] - noOfCardsPlayed;
    }
} 
