using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

namespace Assets.Scripts.New_Scripts
{
    public class Draggable : MonoBehaviour, IBeginDragHandler
    {

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            throw new NotImplementedException();
        }
    }
}