using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static bool TutorialShown = false;

        private static GameManager _instance = null;
        public static GameManager Instance => _instance;
        
        void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            AudioManager.Instance.PlaySong(AudioManager.Song.Title);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
