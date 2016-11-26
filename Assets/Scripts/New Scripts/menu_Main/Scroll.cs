using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Scroll : MonoBehaviour {

    public RectTransform panel; // Holds the panel
    public RectTransform center; // center position
    public Image[] buttons; // Array of images ie the buttons
    public float[] distance; // Distance of all buttons from the center 

    private bool dragging = false; //Only true if image is being dragged
    private int closestButton; // closest button to the center
    
	// Use this for initialization
	void Start ()
    {
        int bttnLength = buttons.Length;
        distance = new float[bttnLength];
        //making the length of the distance array match the length of bttnLength

    }
	
	// Update is called once per frame
	void Update ()
    {
	
        for (int i = 0; i < buttons.Length; i++)
        {

            distance[i] = Mathf.Abs(center.transform.position.x - buttons[i].transform.position.x);
            //distance of card i from the center 
        
        }

        float minDistance = Mathf.Min(distance);

        for (int a = 0; a < buttons.Length; a++ )
        {
            if (minDistance == distance[a])
            {
                closestButton = a;
                //sets the card with the closest value to the center to the colsestButton field
            }
        }

        if (!dragging)
        {
           // LerpToButtons(closestButton * -distance);

        }


	}

    void LerpToButtons(int position) 
    {
        // method for lerp
    }

    public void startDrag()
    {
        dragging = true;
        //makes field dragging true
    }

    public void endDragging()
    {
        dragging = false;
        //makes field dragging false
    }

    //watch tut 2 - 4

}
