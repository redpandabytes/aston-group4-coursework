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


    }
	
	// Update is called once per frame
	void Update ()
    {
	
        for (int i = 0; i < buttons.Length; i++)
        {

            distance[i] = Mathf.Abs(center.transform.position.x - buttons[i].transform.position.x);

            //Console.WriteLine(distance[i]);
        
        }

        
	}

    public void startDrag()
    {
        dragging = true;
    }

    public void endDragging()
    {
        dragging = false;
    }

}
