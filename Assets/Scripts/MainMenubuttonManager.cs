using Assets.Scripts.New_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenubuttonManager : GuildsElement
    {
		private AudioSource source; //TODO: Assign this
		public AudioClip hover;
		public AudioClip click;

        public void SingleplayerBtn(string startGame)
        {
            SceneManager.LoadScene (startGame);
			Camera.main.GetComponent<AudioSource> ();
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

        public void NotifyMVC()
        {
            app.controller.EndGame();
        }
		
		
    }
}
