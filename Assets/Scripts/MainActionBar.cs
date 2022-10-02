using System.Collections;
using System.Collections.Generic;
using Delegates;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainActionBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BuildFarmCarrot()
    {
        BuildFromButton();
    }

    public void BuildFarmTomato()
    {
        BuildFromButton();
    }

    public void BuildFarmBurrito()
    {
        BuildFromButton();
    }

    public void BuildFarmPizza()
    {
        BuildFromButton();
    }

    public void BuildMine()
    {
        BuildFromButton();
    }

    public void BuildSandPit()
    {
        BuildFromButton();
    }
    
    public void BuildPacifier()
    {
        BuildFromButton();
    }

    private void BuildFromButton()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        var buildButton = button.GetComponent<BuildButton>();

        if (buildButton != null)
        {
            BuildingManager.Instance.InitiateBuild(buildButton.building);
        }
    }
}
