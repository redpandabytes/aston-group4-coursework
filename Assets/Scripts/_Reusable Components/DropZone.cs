/*
 * @Author: Dehul Shingadia
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class DropZone : GuildsElement, IDropHandler
{

    //public GameObject dropZone;

    public void OnDrop(PointerEventData eventData)
    {
        bool doNothing = false;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Debug.Log(eventData.pointerDrag.name + " Dropped on: " + gameObject.name);
        String imageName = eventData.pointerDrag.GetComponentInChildren<Image>().sprite.name;
        Debug.Log("The string is " + imageName);
        int guildValue;
        int cardValue;
        if (imageName.Contains("Blue"))
        {
            guildValue = 1;
        }
        else if(imageName.Contains("Green"))
        {
            guildValue = 2;
        }
        else if (imageName.Contains("Purple"))
        {
            guildValue = 3;
        }
        else if (imageName.Contains(("Yellow")))
        {
            guildValue = 4;
        }
        else
        {
            guildValue = 0;
        }

        if (imageName.Contains("10"))
        {
            cardValue = 10;
        }
        else if (imageName.Contains("11"))
        {
            cardValue = 11;
        }
        else if (imageName.Contains("12"))
        {
            cardValue = 12;
        }
        else if (imageName.Contains("13"))
        {
            cardValue = 13;
        }
        else if (imageName.Contains("14"))
        {
            cardValue = 14;
        }
        else if (imageName.Contains("15"))
        {
            cardValue = 15;
        }
        else if (imageName.Contains("16"))
        {
            cardValue = 16;
        }
        else if (imageName.Contains("17"))
        {
            cardValue = 17;
        }
        else if (imageName.Contains("18"))
        {
            cardValue = 18;
        }
        else if (imageName.Contains("19"))
        {
            cardValue = 19;
        }
        else if (imageName.Contains("20"))
        {
            cardValue = 20;
        }

        else if (imageName.Contains("1"))
        {
            cardValue = 1;
        }
        else if (imageName.Contains("2"))
        {
            cardValue = 2;
        }
        else if (imageName.Contains("3"))
        {
            cardValue = 3;
        }
        else if (imageName.Contains("4"))
        {
            cardValue = 4;
        }
        else if (imageName.Contains("5"))
        {
            cardValue = 5;
        }
        else if (imageName.Contains("6"))
        {
            cardValue = 6;
        }
        else if (imageName.Contains("7"))
        {
            cardValue = 7;
        }
        else if (imageName.Contains("8"))
        {
            cardValue = 8;
        }
        else if (imageName.Contains("9"))
        {
            cardValue = 9;
        }
        else
        {
            cardValue = 0;
        }

        if (app.model.IsCardPlayable(guildValue, cardValue))
        {
            // card can be played, so let's play it
            Debug.Log("Attempting to play card: Guild " + guildValue + ", Card " + cardValue);
            app.Notify(GameNotification.CardPlayed, this, guildValue, cardValue);

            var card = Instantiate(Resources.Load("Card")) as GameObject;
            //GetComponent<Card>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            // this.transform.SetParent(mainPanel);

            card.transform.SetParent(GameObject.Find("playedCardsCell").transform);
            card.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 300);
            card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            destroyChild();
        }
        else
        {
            // card isn't playable, inform user with pretty error
            doNothing = true;
            d = null;
            Debug.Log("(DropZone.cs) This card is not playable.");
        }

        if (d != null && doNothing == false)
        {
            d.parentToReturnTo = this.transform;
        }

    }

    private void destroyChild()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            Destroy(child.gameObject);
        }

    }

}
