// @Author: Dehul Shingadia

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour {
    //Public Variables
    public RectTransform Main_Panel; // Will hold the scrollPanel
    public Image[] bttn;
    public RectTransform center;// Center to compate the distance form each button

    //Private Variables
    private float[] distance;// All buttons distance from the center
    private bool dragging = false;// will only be true if panel is being dragged
    private int bttnDistance;// The distance between the buttons
    private int minButtonNum;// holds the button number which is closest to the center

    void start()
    {
		int bttnLength = bttn.Length;
        distance = new float[bttnLength];

        //getting the distance between buttons
       bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
       
    }

    void update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i].transform.position.x);
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
                LerpToBttn(minButtonNum * -bttnDistance);
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