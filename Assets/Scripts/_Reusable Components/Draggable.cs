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

    // bool isOver = false;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("ClICK!!!!!!");
        //if (tapCooldown > 0 && tapCount == 1)
        //{
        MainMenubuttonManager main = new MainMenubuttonManager();

        if (zoom == false)
        {
            if (tapCooldown > 0 && tapCount == 1 && main.zoomedCardCount == 0 )
            {
                //double tapped
                Debug.Log("Double TAPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP, number of cards zoomed" + main.zoomedCardCount);
                print(gameObject.transform.position);
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 600);
                print(gameObject.GetComponent<RectTransform>().sizeDelta);
                //change parent to zoom zone
                //only one objetc at any given time
                //grid layout group used to hold all the card in the players hand is restricting the cards size from being changed, neeed to implement a new zone for card to apprear in if we want them to zoom
                // make card much larger
                main.zoomedCardCount = main.zoomedCardCount + 1;
                
                zoom = true;
            }
            else
            {
                tapCount += 1;
            }
        }
        if (zoom == true)
        {
            if (tapCooldown > 0 && tapCount == 2)
            {
                Debug.Log("unzoommmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm");
                //unzoom
                main.zoomedCardCount = main.zoomedCardCount - 1;
                zoom = false;
                tapCount = 0;
                //take back card from zoom zone and place back in players hand
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

}
