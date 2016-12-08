// @Author: Nathaniel Baulch-Jones
// Please follow the naming conventions: http://answers.unity3d.com/questions/10571/where-are-the-rules-of-capitalization-documented.html

using UnityEngine;

namespace New_Scripts
{
    public class Card : MonoBehaviour
    {
        //Fields
        private Sprite _face;
        private int _guild;
        private int _value;

        // Use this for initialization
        public void Initialise(int guild, int value, Sprite face)
        {
            this._guild = guild;
            this._value = value;
            this._face = face;
        }

        // Update is called once per frame
        public int getGuild()
        {
            return _guild;
        }

        public int getValue()
        {
            return _value;
        }
    }
}