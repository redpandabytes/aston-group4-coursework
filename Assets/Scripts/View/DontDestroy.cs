using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//@author: Ann Tomi
public class DontDestroy : MonoBehaviour {

	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("music");
        if (objs.Length > 1)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            Destroy(this.gameObject);
        }
        Debug.Log(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad (this.gameObject);


	}
		
}
