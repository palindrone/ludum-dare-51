using Managers;
using UnityEngine;

public class Beast : MonoBehaviour
{
    private int _currentMaxHunger = 1;
    private int _currentHunger = 1;

    public static Beast Instance { get; private set; }

    private MainSceneManager _manager;

    
    private int _currentFeed = 0;
    
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    public void SetManager(MainSceneManager manager)
    {
        _manager = manager;
    }
    
    public int GetCurrentHunger()
    {
        return _currentHunger;
    }

    public int Feed(int feedAmount)
    {
        var newHunger = _currentHunger - feedAmount;

        if (newHunger > 0)
        {
            _currentHunger = newHunger;
            return newHunger;
        }
        
        newHunger = 0;
        ResetFeed();

        return 0;
    }

    private void ResetFeed()
    {
        _manager.ResetTimer();
        
        _currentFeed++;
        // Increment Feed
        if (_currentFeed % 4 == 0)
        {
            _currentMaxHunger++;
            _manager.BeastGrowl();
        }
        
        _currentHunger = _currentMaxHunger;
    }
}
