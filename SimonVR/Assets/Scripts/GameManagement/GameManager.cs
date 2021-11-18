using System.Collections;
using System.Linq;
using SimonVR.Assets.Scripts.GameManagement.StateMachine;
using SimonVR.Assets.Scripts.SceneManagement.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SimonVR.Assets.Scripts.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public State CurrentState { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            ChangeStateRequestEventHandler(this, new MenuState(this));

            //Invoke(nameof(OpenMenu), 2);
            //StartCoroutine(nameof(OpenMenuCoroutine));
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            var rootGameObjects = arg0.GetRootGameObjects();
            var interfaceGO = rootGameObjects.Single(x => x.name == "Interface");
            var mainMenuScript = interfaceGO.GetComponent<MainMenu>();
            mainMenuScript.StartGameEvent += MainMenuScript_StartGameEvent;
        }

        IEnumerator OpenMenuCoroutine()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

            yield return new WaitForFixedUpdate();

            var scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName("MainMenu");
            var rootGameObjects = scene.GetRootGameObjects();
            var interfaceGO = rootGameObjects.Single(x => x.name == "Interface");
            var mainMenuScript = interfaceGO.GetComponent<MainMenu>();
            mainMenuScript.StartGameEvent += MainMenuScript_StartGameEvent;
        }

        void OpenMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            var scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName("MainMenu");

            var rootGameObjects = scene.GetRootGameObjects();
            var interfaceGO = rootGameObjects.Single(x => x.name == "Interface");
            var mainMenuScript = interfaceGO.GetComponent<MainMenu>();
            mainMenuScript.StartGameEvent += MainMenuScript_StartGameEvent;
        }

        private void MainMenuScript_StartGameEvent(object sender, System.EventArgs e)
        {
            Debug.Log("Let's play!");
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void ChangeStateRequestEventHandler(object sender, State e)
        {
            //Debug.Log($"Changing state from {sender} to {e}");
            if (CurrentState != null)
            {
                CurrentState.ChangeStateRequestEvent -= ChangeStateRequestEventHandler;
                CurrentState.OnExit();
            }
            CurrentState = e;
            CurrentState.ChangeStateRequestEvent += ChangeStateRequestEventHandler;
            CurrentState.OnEnter();
        }
    }
}
