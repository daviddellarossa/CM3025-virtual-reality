using UnityEngine;

namespace SimonVR.Assets.Scripts.SceneManagement
{
    public class GameScene : ScriptableObject
    {
        [Header("Information")] 
        public string SceneName;

        public string ShortDescription;

        //[Header("Sounds")] public AudioClip Music;
        //[Range(0.0f, 1.0f)] public float MusicVolume;

        //[Header("Visuals")] public PostProcessProfile PostProcess;

    }
}
