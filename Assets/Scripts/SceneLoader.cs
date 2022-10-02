using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<Animator> transitions;
    public Animator activeTransitions;
    public float transitionTime = 1f;
    private static readonly int StartTransition = Animator.StringToHash("Start");
    private static readonly int EndTransition = Animator.StringToHash("End");

    private static SceneLoader _instance = null;
    public static SceneLoader Instance => _instance;
    
    public enum Scene
    {
        StartScene,
        GameScene,
        SuccessScene,
        GameOverScene,
        InstructionScene
    }

    private void Awake()
    {
        _instance = this;
        
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf == true)
            {
                activeTransitions = child.gameObject.GetComponent<Animator>();
                break;
            }
        }
    }

    public void LoadLevel(Scene nextScene)
    {
        StartCoroutine(LoadLevelTransition((int) nextScene));
    }
    
    IEnumerator LoadLevelTransition(int level)
    {
        activeTransitions.SetTrigger(StartTransition);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
