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
        for (int i = 0; i < noOfPlayers; i++)
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
/*public Action AITurn(Player x, int playerNo)
{
    if (_difficulty == 3)
    {
        hardPlay();
    }
    else if (_difficulty == 2)
    {
        mediumPlay();
    }
    else {
        easyPlay(x, playerNo);
    }
} */

//Easy AI turn
public Action easyPlay(Player x, int playerNo)
{
    Player p = x;
    int pNo = playerNo;
    Hand h = p.getHand();
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
        } else {
            Action a = new Action();
            a.Initialise("pickUp", null);
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
