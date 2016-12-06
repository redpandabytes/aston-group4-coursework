using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
	public Transform canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.P)) {
		if (Input.GetMouseButtonDown(0)) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
			} else {
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
			}
		}

	}

	//public void ResumePlayBtn() {
	//	canvas.gameObject.activeInHierarchy == false;
	//}
}
