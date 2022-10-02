using UnityEngine;

namespace Managers
{
    public class StartingSceneManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void ButtonStartGame()
        {
            Debug.Log("Game Starting!");
            SceneLoader.Instance.LoadLevel(SceneLoader.Scene.GameScene);
        }

        public void ButtonDontStart()
        {
            Debug.Log("Game Exiting. Bye Bye.");
            Application.Quit();
        }

        public void ShowInstructions()
        {
            SceneLoader.Instance.LoadLevel(SceneLoader.Scene.InstructionScene);
        }
    }
}
