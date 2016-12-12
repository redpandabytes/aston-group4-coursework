// @Author: Nathaniel Baulch-Jones

using UnityEngine;

public class GameViewer : GuildsElement
{

    public GameModel model;

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
                
            }
            else
            {
                Debug.Log("Card not found error");
            }
//            GetComponent<Card>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

    }

    public void Start()
    {
        //            throw new System.NotImplementedException();
    }

    public void Intiailise(GameModel passedModel) // Setup the object with a constructor
    {
        this.model = passedModel;
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
    public void pickCArd(Card card)
    {

    }
}