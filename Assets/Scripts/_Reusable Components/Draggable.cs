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
    public float tapCooldown = 0.001f;
    private int tapCount = 0;
    public Boolean large = false;

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

  
    void Update()
    {
        var GameAction = new GameAction();
        bool zoom = false;
        
        if (Input.anyKeyDown)
        {
            if (tapCooldown > 0 && tapCount == 2)
            {
                if (zoom == false)
                {
                    //double tapped
                    Debug.Log("Double TAPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP");
                    // make card much larger
                    // yield return new WaitForSeconds(1.0f);
                    //zoom = true;
                }
            }
            else if (tapCooldown >0 && tapCount == 2)
            {
                if (zoom == true)
                {
                Debug.Log("unzoom");
                //unzoom
                //zoom = false;
                }
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
        else {
            tapCount = 0;
        }
    }
    // refactor update method into multiple functions to prevent onclick being detected in multiple frames emulating multiple clicks
}
  