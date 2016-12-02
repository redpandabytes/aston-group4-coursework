using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

	public float loadingTime;
	public Image loadingBar;
	public Text percent;

	void Start () {

		loadingBar.fillAmount = 0;
	
	}


	void Update () {
	
		if (loadingBar.fillAmount <= 1) {
			loadingBar.fillAmount += 1.0f / loadingTime * Time.deltaTime;
		}
		if (loadingBar.fillAmount == 1.0f) {
			SceneManager.LoadScene("Main_Menu");
		}
		percent.text = (loadingBar.fillAmount * 100).ToString("f0");
	}
}
