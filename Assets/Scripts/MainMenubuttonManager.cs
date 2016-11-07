using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenubuttonManager : MonoBehaviour 
    {
		public AudioSource source;
		public AudioClip hover;
		public AudioClip click;

        public void SingleplayerBtn(string startGame)
        {
            SceneManager.LoadScene (startGame);
        }

		public void OnClick ()
		{

			source.PlayOneShot (click);
		}
		public void OnHover()
		{
			source.PlayOneShot (hover);

		}
        public void btnExit()
        {
            Application.Quit();
        }
		
        public void toHelpBtn(string toHelp)
        {
            SceneManager.LoadScene (toHelp);
        }

		public void btnToSettings(string toSettings)
		{
			SceneManager.LoadScene (toSettings);
		}

        public void returnToMain(string returnToMain)
        {
            SceneManager.LoadScene (returnToMain);
        }
		
		
    }
}
