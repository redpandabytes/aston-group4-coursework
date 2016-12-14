using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StaticAi : GuildsElement
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
public GameAction EasyPlay(Player p)
{
    var h = p.getHand();
        //Player has only one card of type weapon:
//        if (h.getHandSize() == 1) {
//            var c = h.getCardAtIndex(0);
//            if (app.model.IsCardPlayable(c.getGuild(), c.getValue()))
//            {
//                Debug.Log("we should be able to win :D");
//                return null;
//            }
//            else
//            {
//                Debug.Log("we cannot play this card.");
//                return null;
//            }
//            if ((c.getValue() < 10) && ((c.getValue() == _cardInPlay.getValue()) || c.getGuild() == _cardInPlay.getGuild())){
//                var a = new GameAction();
//                a.Initialise(GameNotification.CardPlayed, c);
//                return a;
//            } else {
//                var a = new GameAction();
//                a.Initialise(GameNotification.CardPickedUp, null);
//                return a;
//            }
            //Sort through viable cards and pick a random one
            var viableChoices = new List<Card>();
            for (var i=0; i < h.getHandSize(); i++)
            {
                var c = h.getCardAtIndex(i);
                if (_cardInPlay == null)
                {
                    viableChoices.Add(c);
                }
                else
                {
                    if (c.getValue() == _cardInPlay.getValue() || c.getGuild() == _cardInPlay.getGuild())
                    {
                        viableChoices.Add(c);
                    }
                }


            }
            Debug.Log("(StaticAi.cs) Viable count: " + viableChoices.Count);
            if (viableChoices.Count > 0)
            {
                var chosen = viableChoices[Random.Range(0, viableChoices.Count)];
                var a = new GameAction();
                Debug.Log("(StaticAi.cs) Returning a viable choice");
                a.Initialise(GameNotification.CardPlayed, chosen);
                return a;
            }
            else
            {
                var a = new GameAction();
                Debug.Log("(StaticAi.cs) Returning instruction to pickup a card");
                a.Initialise(GameNotification.CardPickedUp);
                return a;
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
//        Debug.Log("(StaticAi.cs) Is the discard deck null?: "+ (cardInPlay == null));
        _cardInPlay = cardInPlay;
        _playersHandSizes[playerNo] = _playersHandSizes[playerNo] - noOfCardsPlayed;
    }
} 
