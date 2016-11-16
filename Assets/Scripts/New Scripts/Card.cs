// @Author: Nathaniel Baulch-Jones
// Please follow the naming conventions: http://answers.unity3d.com/questions/10571/where-are-the-rules-of-capitalization-documented.html

using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    //Fields
    private Sprite face;
    private int guild;
    private int value;

	// Use this for initialization
	private void Start (int guild, int value)
	{
	    this.guild = guild;
	    this.value = value;
	}
	
	// Update is called once per frame
	public int getGuild()
	{
	    return guild;
	}

    public int getValue()
    {
        return value;
    }
}
