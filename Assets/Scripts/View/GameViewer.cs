/* 
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */
using UnityEngine;
using UnityEngine.UI;

public class GameViewer : GuildsElement
{
    private int _expiryCountDown = 10; // the default amount of time a player has to take their turn

    //TODO: Write this class

    public void Initialise()
    {
        var playersHand = app.model.GetPlayerHand(0);
        var handObject = GameObject.Find("Hand");

        foreach(Transform child in handObject.transform) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i <= app.model.GetStartingHandSize() - 1; i++)
        {
            Debug.Log("(Player's starting hand): Value is " + playersHand.getCardAtIndex(i).getValue());
            Debug.Log("(Player's starting hand): Guild is " + playersHand.getCardAtIndex(i).getGuild());

            GameObject card = Instantiate(Resources.Load("Card")) as GameObject;
            if (card != null)
            {
                card.transform.SetParent(handObject.transform);
                card.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 300);
                card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                // convert the starting hand/value to a spite to load
                // TODO: Fix spaghetti, never spagetti XD

                string theGuild;

                if (playersHand.getCardAtIndex(i).getGuild() == 0)
                {
                    theGuild = "Blue";
                }
                else if (playersHand.getCardAtIndex(i).getGuild() == 1)
                {
                    theGuild = "Green";
                }
                else if (playersHand.getCardAtIndex(i).getGuild() == 2)
                {
                    theGuild = "Purple";
                }
                else
                {
                    theGuild = "Yellow";
                }

                card.GetComponent<Image>().sprite = Resources.Load<Sprite>(theGuild + "-Card-" + playersHand.getCardAtIndex(i).getValue());
            }
            else
            {
                Debug.Log("Card not found error");
            }
        }
        // Update text to reflect current player's turn
        int curPlayer = app.model.GetCurrentPlayer();
        if (curPlayer == 0)
        {
            GameObject.Find("CurrentPlayerLabel").GetComponent<Text>().text = "     Player, it is your turn! (10)";
        }
        else
        {
            GameObject.Find("CurrentPlayerLabel").GetComponent<Text>().text = "CPU " + curPlayer + " is taking their turn! (10)";
        }
    }

    public void Start()
    {
        //            throw new System.NotImplementedException();
    }

    public void Intiailise(GameModel passedModel) // Setup the object with a constructor
    {
        app.model = passedModel; // TODO: Is this necessary?
    }

    public void Update()
    {
        //            throw new System.NotImplementedException();
    }

    public void StartTurn()
    {
        throw new System.NotImplementedException();
    }

    public void TakeAction()
    {
        throw new System.NotImplementedException();
    }

    public void EndTurn()
    {
        throw new System.NotImplementedException();
    }

    public void CheckForWinner()
    {
        throw new System.NotImplementedException();
    }

    public void EndGame()
    {
        throw new System.NotImplementedException();
    }
    public void pickCard(Card card)
    {

    }
    private void destroyChild()
    {
        
    }
}