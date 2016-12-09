using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler
{
    Vector3 startPosition;
    Transform startParent;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //itemBeingDragged = gameObject;
    }
}