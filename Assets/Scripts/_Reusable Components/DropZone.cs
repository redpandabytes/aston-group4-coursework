/*
 * @Author: Dehul Shingadia
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DropZone : MonoBehaviour, IDropHandler
{

    //public GameObject dropZone;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " Dropped on: " + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.parentToReturnTo = this.transform;
           // dropZone = gameObject;
           // Debug.Log(gameObject.name);

        }
    }
}
