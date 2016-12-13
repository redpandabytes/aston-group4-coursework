/* 
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */
using UnityEngine;
using UnityEngine.UI;

public class GameViewer : GuildsElement
{
    private const int DefaultTurnLength = 3;
    private float _expiryCountDown = DefaultTurnLength;

    private Hand _playersHand;
    private GameObject _handObject;
    private GameObject _currentPlayerLabel;

    //TODO: Write this class

    public void Initialise()
    {
        _playersHand = app.model.GetPlayerHand(0);
        _handObject = GameObject.Find("Hand0");
        _currentPlayerLabel = GameObject.Find("CurrentPlayerLabel");

        foreach(Transform child in _handObject.transform) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i <= app.model.GetStartingHandSize() - 1; i++)
        {
            Debug.Log("(Player's starting hand): Value is " + _playersHand.getCardAtIndex(i).getValue());
            Debug.Log("(Player's starting hand): Guild is " + _playersHand.getCardAtIndex(i).getGuild());

            GameObject card = Instantiate(Resources.Load("Card")) as GameObject;
            if (card != null)
            {
                card.transform.SetParent(_handObject.transform);
                card.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 300);
                card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                // convert the starting hand/value to a spite to load
                // TODO: Fix spaghetti, never spagetti XD actually I think how we handle this rn is pretty spaghetti :P

                string theGuild;

                if (_playersHand.getCardAtIndex(i).getGuild() == 0)
                {
                    theGuild = "Blue";
                }
                else if (_playersHand.getCardAtIndex(i).getGuild() == 1)
                {
                    theGuild = "Green";
                }
                else if (_playersHand.getCardAtIndex(i).getGuild() == 2)
                {
                    theGuild = "Purple";
                }
                else
                {
                    theGuild = "Yellow";
                }
                // this for instance is really spaghetti
                card.GetComponent<Image>().sprite = Resources.Load<Sprite>(theGuild + "-Card-" + _playersHand.getCardAtIndex(i).getValue());
            }
            else
            {
                Debug.Log("Card not found error");
            }
        }
        StartTurn();
        UpdateCountDown();  // Update text to reflect current player's turn

    }

    public void Start()
    {
        //            throw new System.NotImplementedException();
    }

    public void Intiailise(GameModel passedModel) // Setup the object with a constructor
    {
        app.model = passedModel; // TODO: When is this needed?
    }

    // Stuff that needs to be done each frame
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
            Debug.Log("No action was taken by the player.");
            app.Notify(GameNotification.TimeRanOut, this, false, null);
            ResetCountdownTimer();
        }
    }

    public void ResetCountdownTimer()
    {
        _expiryCountDown = DefaultTurnLength;
    }

    public void TakeAction()
    {
        throw new System.NotImplementedException();
    }

    public void StartTurn()
    {
        TogglePlayersHandEnabled(app.model.GetCurrentPlayer() == 0);
    }

    public void EndTurn()
    {
        Debug.Log("Updating view. (End of Turn)");
        StartTurn(); // start the next turn automatically after this turn has finished successfully
    }

    // True = enable the player's hand, false = disable their hand
    public void TogglePlayersHandEnabled(bool trueOrFalse)
    {
        GameObject.Find("playedCardsCell").GetComponent<DropZone>().enabled = trueOrFalse; // do/don't accept dragging
        var cardsToModify = _handObject.GetComponentsInChildren<Transform>();
        foreach(Transform card in cardsToModify)
        {
            if (card.GetComponent<Draggable>() == null)
            {
                Debug.Log("Error: Missing Draggable component!");
            }
            else
            {
                card.GetComponent<Draggable>().draggable = trueOrFalse;
                if (trueOrFalse)
                {
                    card.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                }
                else
                {
                    card.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
                }
            }

        }
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