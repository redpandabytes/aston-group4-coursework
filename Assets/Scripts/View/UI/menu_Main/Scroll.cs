using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/*
 *  @Author: Dehul Shingadia 
 */

public class Scroll : MonoBehaviour
{

    public RectTransform panel; // Holds the panel
    public RectTransform center; // center position
    public Image[] buttons; // Array of images ie the buttons
    public float[] distance; // Distance of all buttons from the center 

    private bool dragging = false; //Only true if image is being dragged
    private int closestButton; // closest button to the center
    private int bttnDistance;

    static float t = 0; // used for keeping track of lerp amount in lerp function

    // Use this for initialization
    void Start()
    {
        int bttnLength = buttons.Length;
        distance = new float[bttnLength];
        //making the length of the distance array match the length of bttnLength

        bttnDistance = (int)Mathf.Abs(buttons[1].GetComponent<RectTransform>().anchoredPosition.x - buttons[0].GetComponent<RectTransform>().anchoredPosition.x);

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < buttons.Length; i++)
        {

            distance[i] = Mathf.Abs(center.transform.position.x - buttons[i].transform.position.x);
            //distance of card i from the center 

        }

        float minDistance = Mathf.Min(distance); //Gets the minimum distance

        for (int a = 0; a < buttons.Length; a++)
        {
            if (minDistance == distance[a])
            {
                closestButton = a;
                //sets the card with the closest value to the center to the colsestButton field
            }
        }

        if (!dragging)
        {
            LerpToButtons(closestButton * -bttnDistance);
        }




    }

    void LerpToButtons(int position)
    {
        Time.fixedDeltaTime = 2f;
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, t);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        t += 8f * Time.deltaTime;

        panel.anchoredPosition = newPosition;
        // method for lerp
    }

    public void startDrag()
    {
        dragging = true;
        //makes field dragging true
    }

    public void endDrag()
    {
        dragging = false;
        //makes field dragging false
    }



}
