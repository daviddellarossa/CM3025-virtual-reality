using UnityEngine;

namespace SimonVR.Assets.Scripts.SceneManagement
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
    public class Level : GameScene
    {
        [Header("Level specific")] 
        public int EnemiesCount;
    }
}
