using UnityEngine;

namespace SimonVR.Assets.Scripts.SceneManagement
{
    [CreateAssetMenu(fileName = "NewMenu", menuName = "Scene Data/Menu")]
    public class Menu :  GameScene
    {
        [Header("Menu specific")] 
        public MenuType MenuType;
    }
}
