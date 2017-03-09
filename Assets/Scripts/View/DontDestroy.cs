using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//@author: Ann Tomi
public class DontDestroy : MonoBehaviour {

	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("music"); //all music objects tagged music are stored in array
        if (objs.Length > 1) //if more than one sound clip present 
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            Destroy(this.gameObject); //destroy second instance
        }
        Debug.Log(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad (this.gameObject); //if you only sound object in scene keep object alive


    }
		
}
