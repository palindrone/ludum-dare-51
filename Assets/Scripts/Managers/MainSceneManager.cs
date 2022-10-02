using System;
using System.Collections;
using TMPro;
using Trigger;
using UnityEngine;

namespace Managers
{
    public class MainSceneManager : MonoBehaviour
    {
        private static MainSceneManager _instance;
        
        public static bool IsTimerRunning;
        public static bool IsGameActive;
        private const float MaxTime = 10.0f;
        private float _currentTime = MaxTime;

        public bool devPause = false;

        private IEnumerator _failureCoroutine;

        // The Player
        [SerializeField]
        private Player thePlayer;
        
        // The BEAST
        [SerializeField]
        private Beast theBeast;
        
        #region UIElements
        
        public TextMeshProUGUI coinText;
        public TextMeshProUGUI sandText;
        public TextMeshProUGUI hungerText;
        
        #endregion

        public float maxCameraDistance = 14.0f;
        public float currentCameraDistance;
        public float newCameraDistance;
        public float minCameraDistance = 3.5f;

        public float cameraSpeed = 1;

        private Camera mainCamera;
        
        [SerializeField]
        public Animator userFeedbackAnimation;
        [SerializeField]
        public Animator beastFeedbackAnimation;

        private static readonly int Shake = Animator.StringToHash("Shake");
        private static readonly int Growl = Animator.StringToHash("Growl");

        private void Awake()
        {
            _instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            IsTimerRunning = true;
            IsGameActive = true; // TODO: Change this for tutorial stuff
            theBeast.SetManager(this);
            thePlayer.SetManager(this);

            _failureCoroutine = TriggerTimer();
            
            mainCamera = Camera.main;
            currentCameraDistance = newCameraDistance = mainCamera.orthographicSize;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.mouseScrollDelta != Vector2.zero)
            {
                
                Debug.Log(Input.mouseScrollDelta.x);
                Debug.Log(Input.mouseScrollDelta.y);
                
                switch (Input.mouseScrollDelta.y)
                {
                    case 1:
                        newCameraDistance = Math.Max(minCameraDistance, newCameraDistance - 1);
                        break;
                    case -1:
                        newCameraDistance = Math.Min(maxCameraDistance, newCameraDistance + 1);;
                        break;
                }
            }
        }

        private void FixedUpdate()
        {
            currentCameraDistance = mainCamera.orthographicSize;
            
            if (Math.Abs(currentCameraDistance - newCameraDistance) > 0.1)
            {
                if (currentCameraDistance > newCameraDistance)
                {
                    currentCameraDistance -= (cameraSpeed * Time.deltaTime);
                }
                else
                {
                    currentCameraDistance += (cameraSpeed * Time.deltaTime);
                }
            }
            else
            {
                currentCameraDistance = newCameraDistance;
            }

            mainCamera.orthographicSize = currentCameraDistance;

            TickClock();
        }

        public void ResetTimer()
        {
            if (_failureCoroutine != null)
            {
                StopCoroutine(_failureCoroutine);
                IsTimerRunning = true;
            }
            
            OceanTrigger.AnimateOcean(false);
            
            _currentTime = MaxTime;
            Timer.MainTimer.SetTime(_currentTime);
        }

        private void TickClock()
        {
            if (!IsTimerRunning || devPause)
            {
                return;
            }
        
            _currentTime -= Time.deltaTime;
            Timer.MainTimer.SetTime(_currentTime);

            coinText.text = "" + thePlayer.GetCurrentMoney();
            sandText.text = "" + thePlayer.GetCurrentSand();
            hungerText.text = "" + theBeast.GetCurrentHunger();
            
            if (_currentTime <= 0)
            {
                IsTimerRunning = false;
                StartCoroutine(_failureCoroutine);
            }
        }

        IEnumerator TriggerTimer()
        {
            yield return new WaitForSeconds(1.0f);
            
            // Do Some Unpacking
            SceneLoader.Instance.LoadLevel(SceneLoader.Scene.GameOverScene);
        }

        public static void WinGameStatic()
        {
            SceneLoader.Instance.LoadLevel(SceneLoader.Scene.SuccessScene);

        }
        
        public void WinGame()
        {
            SceneLoader.Instance.LoadLevel(SceneLoader.Scene.SuccessScene);
        }

        public static void PlayerShake()
        {
            _instance.userFeedbackAnimation.SetTrigger(Shake);
        }
        
        public void BeastGrowl()
        {
            beastFeedbackAnimation.SetTrigger(Growl);   
        }
    }
}
