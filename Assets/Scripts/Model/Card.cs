// @Author: Nathaniel Baulch-Jones

using UnityEngine;

public class Card
{
    //Fields
    private Sprite _face;
    private int _guild;
    private int _value;

    public Color color { get; internal set; }

    /// <summary>
    /// Initialise.</summary>
    /// <param name="guild"> The ID of the guild to create</param>
    /// <param name="value"> The value of the card to create</param>
    /// <param name="face"> The face of the card (may be null)</param> 
    /// <seealso cref="https://docs.google.com/spreadsheets/d/1aoWqoUjY1dmnW7_qooTxKf3aJFOO_YblTjn5QbRmTHU/">
    /// The database of card value pairs </seealso>
    // Use this for initialization
    public void Initialise(int guild, int value, Sprite face)
    {
        this._guild = guild;
        this._value = value;
        this._face = face;
    }
    
    // Generic getters/setters
    public int getGuild()
    {
        return _guild;
    }

    public int getValue()
    {
        return _value;
    }
    public void setGuild(int newGuild)
    {
        if ((newGuild >= 0) && (newGuild <=3))
        {
            _guild = newGuild;
        }
    }
    public string toString()
    {
        string s =_guild + "," + _value;
        return s;
    }
}