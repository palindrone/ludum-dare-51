using Managers;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _maxMoney = 0;
    private int _currentMoney = 0;
    private int _currentSand = 0;

    private MainSceneManager _manager;

    public static Player Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentMoney = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetManager(MainSceneManager manager)
    {
        _manager = manager;
    }

    public int GetCurrentMoney()
    {
        return _currentMoney;
    }

    public int AddMoney(int newMoney)
    {
        _currentMoney += newMoney;

        if (_currentMoney > _maxMoney)
        {
            _maxMoney = _currentMoney;
            CheckUnlocks();
        }

        return _currentMoney;
    }

    public int SpendMoney(int money)
    {
        if (money > _currentMoney)
        {
            return -1;
        }

        _currentMoney -= money;
        return _currentMoney;
    }
    
    public int GetCurrentSand()
    {
        return _currentSand;
    }

    public int AddSand(int newSand)
    {
        _currentSand += newSand;

        return _currentSand;
    }

    public int SpendSand(int sandToSpend)
    {
        if (sandToSpend > _currentSand)
        {
            return -1;
        }

        _currentSand -= sandToSpend;
        return _currentSand;
    }

    private void CheckUnlocks()
    {
        
    }
}
