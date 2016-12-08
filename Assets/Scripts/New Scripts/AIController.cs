using UnityEngine;

namespace Assets.Scripts.New_Scripts
{
    public class AiController : MonoBehaviour {
        //Fields
        private int _difficulty;
        private int _noOfPlayers;

        public void Initialise(int difficulty, int noOfPlayers)
        {
            this._difficulty = difficulty;
            this._noOfPlayers = noOfPlayers;
        }
        /* private int difficulty; //1 = easy, 2 = medium, 3 = hard
    private Card cardInPlay;
    private int[] playersHandSizes;

    //Initialization of AIController
    private void Start(int difficulty, int noOfPlayers)
    {
        this.difficulty = difficulty;
       // playersHandSizes = int[noOfPlayers];
        cardInPlay = null;
        for (int i = 0; i < noOfPlayers; i++)
        {
            playersHandSizes[i] = 7;
        }
    }

    //Method for when player turn is passed to AI
    public Action AITurn(Player x, int playerNo)
    {
        if (difficulty == 3)
        {
            hardPlay();
        }
        else if (difficulty == 2)
        {
            mediumPlay();
        }
        else
        {
            easyPlay();
        }
    }
    //Easy AI turn
    public Action easyPlay(Player x, int playerNo)
    {
        Player p = x;
        int pNo = playerNo;
        //GET HAND METHOD NEEDED
        x.getHand() == Hand h;
         if(hand.size == 1){
                 if(hand[0].getValye() <// 10 && ((hand[0].getValue() || hand[0].getGuild() ==currentcrd.getguild());
         }
    }
    public Action mediumPlay() { }
    public Action hardPlay() { }
    public Action updateAIKnowledge() { }
} */
    }
}
