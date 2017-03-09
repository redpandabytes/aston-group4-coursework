/*
 * @Author: Dehul Shingadia 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Draggable : GuildsElement, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Boolean draggable = true;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (draggable == true)
        {
            if (this.transform.parent == GameObject.Find("playedCardsCell").transform)
            {
                draggable = false;
            } else { 
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

                if (this.transform.position == GameObject.Find("Hand0").transform.position)
                {
                    draggable = false;
                }
                else
                {
                    draggable = true;
                }
            }
      }

  
}