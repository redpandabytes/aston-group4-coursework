// @Author: Dehul Shingadia


using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ScrollRectSnap : MonoBehaviour {
    //Public Variables
    public RectTransform Main_Panel; // Will hold the scrollPanel
    public Image[] bttn;
    public RectTransform center;// Center to compate the distance form each button
    public float[] distance;// All buttons distance from the center
    public float[] distReposition;

    //Private Variables
    
    private bool dragging = false;// will only be true if panel is being dragged
    private float bttnDistance;// The distance between the buttons
    private int minButtonNum;// holds the button number which is closest to the center
    private int bttnLength;


    void start()
    {
		int bttnLength = bttn.Length;
        distance = new float[bttnLength];
        distReposition = new float [ bttnLength ];

        
        bttnDistance = bttn[1].transform.position.x - bttn[0].transform.position.x;
        

        //getting the distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);

    }

    void update()
    { 
           

        for (int i = 0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]); ///center.transform.position.x - bttn[i].transform.position.x

            if (distReposition[i] > 1000)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;// current x positioon of button
                float cury = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;// current x positioon of button
                System.Console.WriteLine("button: " + bttn[i]  + curX);
                System.Console.WriteLine("button: " + bttn[i]  + cury);
                Vector2 newAnchoredPos = new Vector2(curX + (bttnLength * bttnDistance), cury);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
             
            }
            
        }



        float minDistance = Mathf.Min(distance);//gets min distance

        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;

            }

            if (!dragging)
            {
                //LerpToBttn(minButtonNum * -bttnDistance);
            }
        }
    }

    void LerpToBttn(int position )
    {
        float newX = Mathf.Lerp(Main_Panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, Main_Panel.anchoredPosition.y);

        Main_Panel.anchoredPosition = newPosition;
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