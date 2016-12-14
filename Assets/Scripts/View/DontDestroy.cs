using UnityEngine;
using System.Collections;
//@author: Ann Tomi
public class DontDestroy : MonoBehaviour {

	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("music");
		if (objs.Length > 1)
			Destroy (this.gameObject);
		DontDestroyOnLoad (this.gameObject);


	}
		
}
