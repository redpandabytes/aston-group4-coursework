// @Author: Matthew Kavanagh

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuScript : GuildsElement
{
    public Transform canvas;
    public Transform menu;
    public bool paused = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
//        //if (Input.GetMouseButtonDown (0)) {
//        if (Input.GetKeyDown(KeyCode.P))
//        {
//            if (canvas.gameObject.activeInHierarchy == false && menu.gameObject.activeInHierarchy == false && paused == true)
//            {
//                canvas.gameObject.SetActive(true);
//                menu.gameObject.SetActive(true);
//                Time.timeScale = 0;
//            }
//            else
//            {
//                canvas.gameObject.SetActive(false);
//                menu.gameObject.SetActive(false);
//                Time.timeScale = 1;
//            }
//        }
    }
    public void clickPauseBtn()
    {
        app.Notify(GameNotification.PauseGame, this, paused, canvas);
        paused = !paused;
		Time.timeScale = 0;
        Time.fixedDeltaTime = 0; //effects GUI elements
    }

    public void clickResumeBtn()
    {
        app.Notify(GameNotification.PauseGame, this, paused, canvas);
        paused = !paused;
		Time.timeScale = 1; //run in normal time
        Time.fixedDeltaTime = 0.02f; //return to default
    }

	public void clickSettingsBtn()
	{
		Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
	}

    public void ClickRestartBtn()
    {
        Time.timeScale = 1; //run in normal time
        Time.fixedDeltaTime = 0.02f; //return to default
    }

    public void ClickExitBtn()
    {
        Time.timeScale = 1; //run in normal time
        Time.fixedDeltaTime = 0.02f; //return to default
        SceneManager.LoadScene("Main_Menu");
    }
}

