using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 startPosition;
    Transform startParent;


    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("Hello");
        //itemBeingDragged = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Hello 2");
        //throw new NotImplementedException();

        this.transform.position = eventData.position;//position of mouse
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Hello 3");
        //throw new NotImplementedException();
    }

}