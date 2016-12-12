/* 
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */
using UnityEngine;
using UnityEngine.UI;

public class GameViewer : GuildsElement
{
    private GameObject _currentPlayerLabel;
    private const int DefaultTurnLength = 10;
    private float _expiryCountDown = DefaultTurnLength;

    //TODO: Write this class

    public void Initialise()
    {
        var playersHand = app.model.GetPlayerHand(0);
        var handObject = GameObject.Find("Hand");
        _currentPlayerLabel = GameObject.Find("CurrentPlayerLabel");

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
                // TODO: Fix spaghetti

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
        UpdateCountDown();  // Update text to reflect current player's turn

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
        UpdateCountDown();

    }

    public void UpdateCountDown()
    {
        _expiryCountDown -= Time.deltaTime;
        int curPlayer = app.model.GetCurrentPlayer();
        if (curPlayer == 0)
        {
            _currentPlayerLabel.GetComponent<Text>().text = "     Player, it is your turn! (" + Mathf.Floor(_expiryCountDown + 1) + ")";
        }
        else
        {
            _currentPlayerLabel.GetComponent<Text>().text = "CPU " + curPlayer + " is taking their turn! (" + Mathf.Floor(_expiryCountDown + 1) + ")";
        }

        if(_expiryCountDown <= 0)
        {
            app.Notify(GameNotification.TimeRanOut, this, false, null);
            ResetCountdownTimer();
        }
    }

    public void ResetCountdownTimer()
    {
        _expiryCountDown = DefaultTurnLength;
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
        Debug.Log("Called reset countdown");
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