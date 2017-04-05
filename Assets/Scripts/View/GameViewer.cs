/* 
 * @Author: Nathaniel Baulch-Jones
 * @Author: Dehul Shingadia
 */

using System;
using UnityEngine;
using UnityEngine.UI;

public class GameViewer : GuildsElement
{
    public Transform targetCanvas;
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

        RenderPlayerHand();
        StartTurn();

    }

    public void Start()
    {
        //            throw new System.NotImplementedException();
    }
    public void RenderPlayerHand()
    {
        _playersHand = app.model.GetPlayerHand(0);
        foreach (Transform child in _handObject.transform) {
            Destroy(child.gameObject);
        }

        for (var i = 0; i <= app.model.GetPlayerHand(0).getHandSize() - 1; i++)
        {
//            Debug.Log("(Player's starting hand): Value is " + _playersHand.getCardAtIndex(i).getValue());
//            Debug.Log("(Player's starting hand): Guild is " + _playersHand.getCardAtIndex(i).getGuild());

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
    }

    //public void Intiailise(GameModel passedModel) // Setup the object with a constructor
    //{
    //    app.model = passedModel; // TODO: When is this needed?
    //}

    // Stuff that needs to be done each frame
    public void Update()
    {
//        UpdateCountDown();

    }

    public void UpdateCountDown(String passedString)
    {
    _currentPlayerLabel.GetComponent<Text>().text = passedString;
    }

    public void HandleAction(GameAction gameAction)
    {
        // Do stuff to make the player's action look pretty
        //check card
        if (gameAction.getChoice() == GameNotification.CardPlayed) {
            if (gameAction.getSelectedCard().getValue() == 16) {
                //code for chooseTarget
                //FIX: Had to comment the next line as it was saying the canvas was unassigned
             //   targetCanvas.gameObject.SetActive(true);
            }
        }

        StartTurn();
    }

    public void StartTurn() // This should ensure that the view is appropriate for the current turn
    {
        // update the player's hand with the correct values
        Debug.Log("(GameViewer.cs) About to Update the Player's hand view.");

        RenderPlayerHand();
        TogglePlayersHandEnabled(app.model.GetCurrentPlayer() == 0);
        GameObject.Find("Player1_Lbl").GetComponent<Text>().text = "(" + app.model.GetPlayerHand(1).getHandSize() +
                                                                   " cards)";
        GameObject.Find("Player2_Lbl").GetComponent<Text>().text = "(" + app.model.GetPlayerHand(2).getHandSize() +
                                                                   " cards)";
        GameObject.Find("Player3_Lbl").GetComponent<Text>().text = "(" + app.model.GetPlayerHand(3).getHandSize() +
                                                                   " cards)";

        if (app.model.PeekInPlayCard() != null) // only update the card in the middle if it isn't null
        {
//            Debug.Log("(GameViewer.cs) In play card: Guild:" + app.model.PeekInPlayCard().getGuild() + ", Value: " + app.model.PeekInPlayCard().getValue());
            Debug.Log("(GameViewer.cs) About to update the central view");
            var peekedGuild = app.model.PeekInPlayCard().getGuild();
            var peekedValue = app.model.PeekInPlayCard().getValue();

//            String imageName = eventData.pointerDrag.GetComponentInChildren<Image>().sprite.name;
            var imageName = "";
            Debug.Log("The string is " + imageName);
            switch (peekedGuild)
            {
                case 1:
                    imageName = "Blue";
                    break;
                case 2:
                    imageName = "Green";
                    break;
                case 3:
                    imageName = "Purple";
                    break;
                case 4:
                    imageName = "Yellow";
                    break;
                default:
                    imageName = "Triumph";
                    break;
            }

            imageName = imageName + "-Card-" + peekedValue;

            Debug.Log("(GameViewer.cs) We need to initiate a PreFab with " + imageName);

            foreach (Transform child in GameObject.Find("playedCardsCell").GetComponentInChildren<Transform>())
            {
                Destroy(child.gameObject);
            }

            var card = Instantiate(Resources.Load("Card")) as GameObject;
            //GetComponent<Card>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            // this.transform.SetParent(mainPanel);


            card.GetComponent<Image>().sprite = Resources.Load<Sprite>(imageName);
            card.transform.SetParent(GameObject.Find("playedCardsCell").transform);
            card.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 300);
            card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        }

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
//                Debug.Log("Warning: Missing Draggable component in card item"); //TODO: Fix this
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