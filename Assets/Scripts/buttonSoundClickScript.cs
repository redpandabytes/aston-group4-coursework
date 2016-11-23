using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class buttonSoundClickScript : MonoBehaviour {

	// Use this for initialization
	public AudioClip buttonSound;

	private Button button
	{ 
		get { 
				return GetComponent<Button> (); 
			}
	}
	private AudioSource source {
		get {
			return GetComponent<AudioSource> (); 
			}
	}

	void Start () 
	{
		gameObject.AddComponent<AudioSource>();
		source.clip = buttonSound;
		source.playOnAwake = false;
		button.onClick.AddListener (() => PlaySound ());
	}

	void PlaySound()
	{
		source.PlayOneShot(buttonSound);
	}

}
