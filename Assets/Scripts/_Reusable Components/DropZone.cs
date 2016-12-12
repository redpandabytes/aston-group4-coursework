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
        Debug.Log(eventData.pointerDrag.name + " Dropped on: " + gameObject.name);
        String imageName = eventData.pointerDrag.GetComponentInChildren<Image>().sprite.name;
        Debug.Log("The string is " + imageName);
        int guildValue;
        int cardValue;
        if (imageName.Contains("Blue"))
        {
            guildValue = 0;
        }
        else if(imageName.Contains("Green"))
        {
            guildValue = 1;
        }
        else if (imageName.Contains("Purple"))
        {
            guildValue = 2;
        }
        else
        {
            guildValue = 3;
        }

        if (imageName.Contains("1"))
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
        else if (imageName.Contains("10"))
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
        else
        {
            cardValue = 0;
        }

        if (app.model.IsCardPlayable(guildValue, cardValue))
        {
            // card can be played, so let's play it
            Debug.Log("Attempting to play card: Guild " + guildValue + ", Card " + cardValue);
        }
        else
        {
            // card isn't playable, do shit
            Debug.Log("This card is not playable.");
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.parentToReturnTo = this.transform;
           // dropZone = gameObject;
           // Debug.Log(gameObject.name);

        }
    }

    private void destroyChild()
    {
        if (transform child in GameObject.Find("dropZone"). )
        {

        }
    }

}
