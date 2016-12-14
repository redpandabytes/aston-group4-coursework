/* 
 * @Author: Matthew Kavanagh
 * @Author: David Powell
 */

using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	public void mute()
	{
		audio.mute = true;
	}

	public void unMute()
	{
		audio.mute = false;
	}
}
