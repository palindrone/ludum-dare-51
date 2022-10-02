using UnityEngine;

namespace Managers
{
    public class EndSceneManager : MonoBehaviour
    {
        public void ShowCredits()
        {
            
        }

        public void BackToStart()
        {
            SceneLoader.Instance.LoadLevel(SceneLoader.Scene.StartScene);
        }   

        public void Exit()
        {
            Application.Quit();
        }
    }
}