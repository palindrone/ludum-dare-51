using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using TMPro;
using Trigger;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private const int HardTime = 10;
    
    [SerializeField]
    private Image timerImage;
    
    [SerializeField]
    private TextMeshProUGUI timeField;

    private static Timer _mainTimer;
    public static Timer MainTimer => _mainTimer;

    public int lastInt;

    private void Awake()
    {
        if (_mainTimer != null)
        {
            Destroy(gameObject);
        }

        _mainTimer = this;
        lastInt = HardTime;
    }

    public void SetTime(float time)
    {
        if (time < 0)
            time = 0;
        
        var intTime = (int) Math.Ceiling(time);
        var rad = time / HardTime;

        timerImage.fillAmount = rad;
        timeField.text = "" + intTime;

        if (intTime > 5)
        {
            timerImage.color = Color.white;
        } else if (intTime > 3)
        {
            timerImage.color = Color.yellow;
        }
        else
        {
            timerImage.color = Color.red;
            if (intTime != lastInt && intTime != 0)
            {
                OceanTrigger.AnimateOcean(true);
                AudioManager.Instance.PlayEffect(AudioManager.Effect.Boop);
                lastInt = intTime;
            }
        }
        
        lastInt = intTime;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
