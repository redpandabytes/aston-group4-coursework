﻿/*
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
    //public GameController gameController;
    //public int position;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (draggable == true)
        {
            Debug.Log("Card Picked Up");
            //itemBeingDragged = gameObject;
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Card Being Dragged");
        
        if (draggable == true)
        {
            this.transform.position = eventData.position;//position of mouse
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int player = app.model.GetCurrentPlayer();
        //if (player == 0)
        //{
        //    draggable = true;
        //}
        //else
        //{
        //    draggable = false;
        //}
            //dropZone2 = GameObject.Find("Dropzone");
            if (draggable == true)
            {
                //Debug.Log(GameObject.Find("Hand").transform.position);
                //Debug.Log("Card Dropped");
                this.transform.SetParent(parentToReturnTo);

                //x 270 y guress
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