using UnityEngine;

namespace Assets.Scripts
{
    public class CardModel : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        public Sprite[] faces;
        public Sprite cardBack;
        public int cardIndex; // e.g. faces[cardIndex];

        public void ToggleFace(bool showFace)
        {
            if (showFace)
            {
                Debug.Log("Max is: " +faces.Length + "we want to access" + cardIndex);
                spriteRenderer.sprite = faces[cardIndex];
            }
            else
            {
                spriteRenderer.sprite = cardBack;
            }
        }

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

    }
}
