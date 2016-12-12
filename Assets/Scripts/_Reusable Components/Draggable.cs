/*
 * @Author: Dehul Shingadia 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 startPosition;
    Transform startParent;

    public Transform parentToReturnTo = null;

    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("Card Picked Up");
        //itemBeingDragged = gameObject;

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Card Being Dragged");
        //throw new NotImplementedException();

        this.transform.position = eventData.position;//position of mouse
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Card Dropped");
        this.transform.SetParent(parentToReturnTo);
        //throw new NotImplementedException();
    }

}