/*
 * @Author: Dehul Shingadia 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    //public Transform dropZone;
    public Boolean draggable = true;
    public GameController gameController;
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
        //throw new NotImplementedException();
        if (draggable == true)
        {
            this.transform.position = eventData.position;//position of mouse
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggable == true)
        {
            Debug.Log("Card Dropped");
        this.transform.SetParent(parentToReturnTo);
            //throw new NotImplementedException();
            //x 270 y guress
            //if card is in center make uninteractable

            if (this.transform.parent = gameController.dropzone)
            {
                draggable = false;
            }
            
        }
        
    }

}