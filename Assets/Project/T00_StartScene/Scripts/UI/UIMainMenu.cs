using UnityEngine;
using UnityEngine.UI;


namespace T0 {
    public class UIMainMenu : MonoBehaviour {

        //ButtonList
        //Scenes
        [SerializeField] private Button _buttonT01_Scene;
        [SerializeField] private Button _buttonT02_Scene;
        [SerializeField] private Button _buttonT03_Scene;

        private void Awake() {
            UIManager.ButtonLoadScene(_buttonT01_Scene, ScenesList.T01_Scene);
            UIManager.ButtonLoadScene(_buttonT02_Scene, ScenesList.T01_Scene);
            UIManager.ButtonLoadScene(_buttonT03_Scene, ScenesList.T01_Scene);
        }
    }
}
