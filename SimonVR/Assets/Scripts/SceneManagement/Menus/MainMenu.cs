using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SimonVR.Assets.Scripts.SceneManagement.Menus
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject Menu;
        public GameObject LoadingInterface;
        public Image LoadingProgressBar;

        public event EventHandler StartGameEvent;

        private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

        //This should be moved to GameManager
        public void StartGame()
        {
            StartGameEvent?.Invoke(this, new EventArgs());
            //HideMenu();
            //ShowLoadingScreen();
            //DDR: Why the menu knows about the scenes to load?
            //DDR: This should be the GameManager's duty
            //scenesToLoad.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Gameplay"));
            //scenesToLoad.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level01Part01", LoadSceneMode.Additive));
        }
        //This should be moved to GameManager
        public void ExitGame()
        {
            Application.Quit();
        }

        public void HideMenu()
        {
            Menu.SetActive(false);
        }

        public void ShowLoadingScreen()
        {
            LoadingInterface.SetActive(true);
        }

        public IEnumerator LoadingScreen()
        {
            float totalProgress = 0;
            //Iterate through all the scenes to load
            for (int i = 0; i < scenesToLoad.Count; ++i)
            {
                while (!scenesToLoad[i].isDone)
                {
                    //Adding the scene progress to the total progress
                    totalProgress += scenesToLoad[i].progress;
                    //the fillAmount needs a value between 0 and 1, so we divide the progress by the number of scenes to load
                    LoadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                    yield return null;
                }
            }
        }
    }
}
