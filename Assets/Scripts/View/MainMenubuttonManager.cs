﻿// @Author: Nathaniel Baulch-Jones

using System;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenubuttonManager : GuildsElement
{
    private AudioSource source; //TODO: Assign this
    public AudioClip hover;
    public AudioClip click;
    public GameObject card;

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
        Application.Quit();
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
        app.Notify(GameNotification.GameVictory,this);
    }


    public void pickCard() {
        Debug.Log("Pressed left click.");
        app.Notify(GameNotification.CardPicked,this);
        //card = Instantiate(card.transform.position, Quaternion, Identity) as GameObject;

    }
    
}
