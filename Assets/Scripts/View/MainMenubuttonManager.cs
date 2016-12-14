/* @Author: Nathaniel Baulch-Jones
 * @Author: David Powell
 * @Author: Matthew Kavanagh
 * @Author: Dehul Shingadia
*/

using System;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenubuttonManager : GuildsElement
{
    private AudioSource source; //TODO: Assign this
    public AudioClip hover;
    public AudioClip click;
    private GameObject _handObject;
    // public Transform mainPanel;
    //public GameObject card = Instantiate(Resources.Load("Card")) as GameObject;

    public void SingleplayerBtn(string startGame)
    {
        SceneManager.LoadScene(startGame);
        Camera.main.GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        source.PlayOneShot(click);
    }
    public void OnHover()
    {
        source.PlayOneShot(hover);

    }
    public void btnExit()
    {
		UnityEditor.EditorApplication.isPlaying = false;
    }

    public void toHelpBtn(string toHelp)
    {
        SceneManager.LoadScene(toHelp);
    }

    public void btnToSettings(string toSettings)
    {
        SceneManager.LoadScene(toSettings);
    }

    public void returnToMain(string returnToMain)
    {
        SceneManager.LoadScene(returnToMain);
    }

    public void NotifyMVC()
    {
        Debug.Log("sdsdfdsd");
        app.Notify(GameNotification.GameVictory, this);
    }

    public void playTriumph()
    {
        var action = new GameAction();
        action.Initialise(GameNotification.TriumphCard);
        app.Notify(GameNotification.ActionTaken, this, action);
    }


    public void pickCard()
    {
        Debug.Log("Pressed left click.");
        app.Notify(GameNotification.CardPickedUp, this);
        GameObject card = Instantiate(Resources.Load("Card")) as GameObject;
        //GetComponent<Card>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        // this.transform.SetParent(mainPanel);

        card.transform.SetParent(GameObject.Find("Hand0").transform);
        card.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 300);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);


        //card.renderer.transparent.material.color = new Color(1.0f, 1.0.f, 1.0f, 1.0f);
        /*
            if (GameController.player == 1)
            {
                //set parent of card to player 1 hand
            }
            if (GameController.player == 2)
            {
                //set parent of card to player 2 hand
            }
            if (GameController.player == 3)
            {
                //set parent of card to player 3 hand
            }
            if (GameController.player == 4)
            {
                //set parent of card to player 4 hand
            }
            */
    }
       
}
    
    

