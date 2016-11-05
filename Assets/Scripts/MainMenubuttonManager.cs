using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenubuttonManager : MonoBehaviour 
    {
        public void SingleplayerBtn(string startGame)
        {
            SceneManager.LoadScene (startGame);
        }

        public void btnExit()
        {
            Application.Quit();
        }
		
        public void toHelpBtn(string toHelp)
        {
            SceneManager.LoadScene (toHelp);
        }

        public void returnToMain(string returnToMain)
        {
            SceneManager.LoadScene (returnToMain);
        }
		
		
    }
}
