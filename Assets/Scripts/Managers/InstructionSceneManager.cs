using UnityEngine;

namespace Managers
{
    public class InstructionSceneManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        public void BackToMain()
        {
            SceneLoader.Instance.LoadLevel(SceneLoader.Scene.StartScene);
        }
    }
}
