using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimonVR.Assets.Scripts.SceneManagement
{
    /// <summary>
    /// <see cref="https://blog.unity.com/technology/achieve-better-scene-workflow-with-scriptableobjects"/>
    /// </summary>
    [CreateAssetMenu(fileName = "sceneDB", menuName = "Scene Data/Scene Manager")]
    public class SceneManager : ScriptableObject
    {
        public List<Level> levels = new List<Level>();
        public List<Menu> menus = new List<Menu>();
        public int CurrentLevelIndex = 1;

        #region Levels

        /// <summary>
        /// Load a scene with a given index
        /// </summary>
        /// <param name="index"></param>
        public void LoadLevelWithIndex(int index)
        {
            if (index <= levels.Count)
            {
                //Load Gameplay scene for the level
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Gameplay" + index.ToString());
                //Load first part of the level in additive mode
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level" + index.ToString() + "Part1",
                    LoadSceneMode.Additive);
            }
            //reset the index if we have no more levels
            else
            {
                CurrentLevelIndex = 1;
            }
        }

        /// <summary>
        /// Start next level
        /// </summary>
        public void NextLevel()
        {
            CurrentLevelIndex++;
            LoadLevelWithIndex(CurrentLevelIndex);
        }

        /// <summary>
        /// Restart current level
        /// </summary>
        public void RestartLevel()
        {
            LoadLevelWithIndex(CurrentLevelIndex);
        }

        /// <summary>
        /// New game, load level 1
        /// </summary>
        public void NewGame()
        {
            LoadLevelWithIndex(1);
        }
        #endregion

        #region Menus

        /// <summary>
        /// Load main menu
        /// </summary>
        public void LoadMainMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(menus[(int) MenuType.Main].SceneName);
        }

        /// <summary>
        /// Load pause menu
        /// </summary>
        public void LoadPauseMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(menus[(int) MenuType.Pause].SceneName);
        }

        #endregion
    }
}
