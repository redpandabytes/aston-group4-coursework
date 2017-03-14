/* 
 * @Author: Matthew Kavanagh
 * @Author: David Powell
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundControl : MonoBehaviour {
    GameObject localSlider;
    GameObject localAudioSource;
     
    float volume;
	// Use this for initialization
	void Start () {

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
        if(localSlider == null)
        {
            localSlider = GameObject.Find("Volume_Slider");
            localAudioSource = GameObject.FindGameObjectsWithTag("music")[0];
        }
        else
        {
            localSlider.GetComponent<Slider>().value = localAudioSource.GetComponent<AudioSource>().volume;
        }
    }
    public void OnValueChanged(float newValue)
    {
        var slider = GameObject.Find("Volume_Slider");
        var volumeVal = slider.GetComponent<Slider>().value;
        GameObject.FindGameObjectsWithTag("music")[0].GetComponent<AudioSource>().volume = volumeVal;
    }
}


