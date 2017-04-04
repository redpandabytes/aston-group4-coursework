/*
 * @Author: Dehul Shingadia 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Draggable : GuildsElement, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Transform parentToReturnTo = null;
    public Boolean draggable = true;
    public float tapCooldown = 0.5f;
    private int tapCount = 0;
    public bool zoom = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (draggable == true)
        {
            if (this.transform.parent == GameObject.Find("playedCardsCell").transform)
            {
                draggable = false;
            }
            else
            {
                Debug.Log("Card Picked Up");
                parentToReturnTo = this.transform.parent;
                this.transform.SetParent(this.transform.parent.parent);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggable == true)
        {
            this.transform.position = eventData.position;//position of mouse
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int player = app.model.GetCurrentPlayer();

        if (draggable == true)
        {
            this.transform.SetParent(parentToReturnTo);
            //if card is in center make uninteractable

            if (this.transform.position == GameObject.Find("Hand0").transform.position ||
                    this.transform.parent == GameObject.Find("zoomCardCell").transform)
            {
                draggable = false;
            }
            else
            {
                draggable = true;
            }
        }
    }

    public void Update()
    {
        if (this.transform.parent.transform.childCount > 1 && this.transform.parent == GameObject.Find("zoomCardCell").transform)
        {
            Unzoom();
            //only one card zoomed at any given time
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //zoom
        if (zoom == false)
        {
            if (tapCooldown > 0 && tapCount == 1)
            {
                if (this.transform.parent == GameObject.Find("playedCardsCell").transform)
                {
                   //Do Nothing
                }
                else {
                    Zoom();
                    //card moves to zoomCell
                }
            }
            else
            {
                tapCount += 1;
            }
        }

        //unzoom
        if (zoom == true)
        {
            if (tapCooldown > 0 && tapCount == 2)
            {
                    Unzoom();
                    //card moves back to its past parent
            }
            else
            {
                tapCount += 1;
            }
        }


        if (tapCooldown > 0)
        {
            tapCooldown -= 1 * Time.deltaTime;

        }
        else
        {
            tapCount = 0;
        }
    }
    public void Zoom()
    {
        //double tapped
        Debug.Log("Double TAP");
        //print(gameObject.transform.position);
        //gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 600);
        parentToReturnTo = this.transform.parent;
        Debug.Log("cards original parent set");
        this.transform.parent = GameObject.Find("zoomCardCell").transform;//change parent to zoom zone
        zoom = true;
                
        
        //grid layout group used to hold all the card in the players hand is restricting the cards size from being changed, neeed to implement a new zone for card to apprear in if we want them to zoom
        // make card much larger
    }

    public void Unzoom()
    {
        Debug.Log("unzoom");
        this.transform.parent = parentToReturnTo;
        //unzoom
        //main.zoomedCardCount = main.zoomedCardCount - 1;// check to ensure only one card is zoomed
        zoom = false;
        tapCount = 0;
        //take back card from zoom zone and place back in players hand
    }
}
