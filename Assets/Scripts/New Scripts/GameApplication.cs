using UnityEngine;

namespace Assets.Scripts.New_Scripts
{
    // Base class for all elements in the application
    public class GuildsElement : MonoBehaviour
    {
        public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication>(); }}
    }

    // Entry point to our application
    public class GameApplication : MonoBehaviour
    {
        // References to root instances of the MVC
        public GameModel model;
        public GameViewer viewer;
        public GameController controller;

        // Initialise stuff here
        void Start()
        {
            //
        }
    }
}