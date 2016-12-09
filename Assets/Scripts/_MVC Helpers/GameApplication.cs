// @Author: Nathaniel Baulch-Jones

using UnityEngine;

// Base class for all elements in the application
public class GuildsElement : MonoBehaviour
{
    public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication>(); } }
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

    // Iterates all Controllers and delegates the notification data
    // This method can easily be found because every class is “GuildsElement” and has an “app”
    // instance.
    public void Notify(string p_event_path, Object p_target, params object[] p_data)
    {
        GameController controller_list = GetAllControllers();
        //            foreach (GameController c in controller_list)
        //            {
        controller_list.OnNotification(p_event_path, p_target, p_data);
        //            }
    }

    // Return all controllers
    // Signature can easily be modified to add more controllers if game becomes too complex
    public GameController GetAllControllers()
    {
        return controller;
    }

}