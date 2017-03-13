/* 
 * @Author: Matthew Kavanagh
 * @Author: David Powell
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundControl : MonoBehaviour {
	GameObject[] audioArray;
    GameObject audioSource;
     
    float volume;
	// Use this for initialization
	void Start () {
		audioArray = GameObject.FindGameObjectsWithTag("music");
        audioSource = audioArray[0];
        // volume = GameObject.Find("sound").GetComponent<AudioSource>().volume;
        //PlayerPrefs.SetFloat("Volume", volume);
        //AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

	public void mute()
	{
		//audio.mute = true;
	}

	public void unMute()
	{
		//audio.mute = false;
	}

    public void Update()
    {
        Debug.Log(audioSource.GetComponent<AudioSource>().volume);
    }
    public void OnValueChanged(float newValue)
    {
        //audioSource.GetComponent<AudioSource>().volume = 0.1f;
        Debug.Log(newValue);
        var slider = GameObject.Find("Volume_Slider");
        var volumeVal = slider.GetComponent<Slider>().value;
        GameObject.FindGameObjectsWithTag("music")[0].GetComponent<AudioSource>().volume = volumeVal;
    }
}


