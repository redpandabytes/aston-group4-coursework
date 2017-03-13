/* 
 * @Author: Matthew Kavanagh
 * @Author: David Powell
 */

using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {
	AudioSource audio;
    float volume;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
       // volume = GameObject.Find("sound").GetComponent<AudioSource>().volume;
        //PlayerPrefs.SetFloat("Volume", volume);
        //AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

	public void mute()
	{
		audio.mute = true;
	}

	public void unMute()
	{
		audio.mute = false;
	}

    public void Update()
    {
        AudioListener.volume = 0.1f;
    }
   
}


