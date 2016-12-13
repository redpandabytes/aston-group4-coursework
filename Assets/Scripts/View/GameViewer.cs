/* 
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */

using System;
using UnityEngine;
using UnityEngine.UI;

public class GameViewer : GuildsElement
{
    private Hand _playersHand;
    private GameObject _handObject;
    private GameObject _currentPlayerLabel;
    private GameObject _cardStackBtn;

    //TODO: Write this class

    public void Initialise()
    {
        _playersHand = app.model.GetPlayerHand(0);
        _handObject = GameObject.Find("Hand0");
        _currentPlayerLabel = GameObject.Find("CurrentPlayerLabel");
        _cardStackBtn = GameObject.Find("CardStackBtn");

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
                    theGuild = "Triumph";
                }
                else if (_playersHand.getCardAtIndex(i).getGuild() == 1)
                {
                    theGuild = "Blue";
                }

                else if (_playersHand.getCardAtIndex(i).getGuild() == 2)
                {
                    theGuild = "Green";
                }
                else if (_playersHand.getCardAtIndex(i).getGuild() == 3)
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
//        UpdateCountDown();
    }

    public void UpdateCountDown(String passedString)
    {
    _currentPlayerLabel.GetComponent<Text>().text = passedString;
    }

    public void HandleAction()
    {
        // Do stuff to make the player's action look pretty
        StartTurn();
    }

    public void StartTurn() // This should ensure that the view is appropriate for the current turn
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
                Debug.Log("Warning: Missing Draggable component in card item");
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
            if (trueOrFalse)
            {
                _cardStackBtn.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
            }
            else
            {
                _cardStackBtn.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
            }
            _cardStackBtn.GetComponent<Button>().interactable = trueOrFalse;
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