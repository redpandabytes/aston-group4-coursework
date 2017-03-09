using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour {
    public GameObject card;
    GameObject cardClone;
    private void OnMouseEnter()
    {
        cardClone = Instantiate(card);
        // wiat 3 seconds?
        //show larger card
        //make exisiting card large? or spawn new one
    }

    private void OnMouseExit()
    {

        //remove large card
        //or destroy
    }

    private void OnMouseOver()
    {
        //all in one method?

    }
}
