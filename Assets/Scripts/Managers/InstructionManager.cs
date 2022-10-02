using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InstructionManager : MonoBehaviour
{
    public static InstructionManager Instance { get; private set; }

    [SerializeField]
    private GameObject showHideWrapper;
    [SerializeField]
    private TextMeshProUGUI titleField;
    [SerializeField]
    private TextMeshProUGUI descriptionField;
    [SerializeField]
    private TextMeshProUGUI descriptionField2;

    [SerializeField]
    private GameObject costWrapper;
    
    [SerializeField]
    private Image costSprite;

    [SerializeField]
    private TextMeshProUGUI costAmount;
    
    
    private IEnumerator _hidePanel;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    
    public void SetData(string title, string description, string description2, [CanBeNull] Sprite sprite = null, int amount = 0, bool show = true)
    {
        titleField.text = title;
        descriptionField.text = description;
        descriptionField2.text = description2;

        if (sprite != null)
        {
            costSprite.sprite = sprite;
            costAmount.text = "" + amount;
            costWrapper.SetActive(true);
        }
        else
        {
            costWrapper.SetActive(false);   
        }
        
        if (show)
        {
            Show();
        }
    }

    public void Show()
    {
        if (_hidePanel != null)
            StopCoroutine(_hidePanel);
        
        showHideWrapper.SetActive(true);
    }

    public void Hide()
    {
        if (_hidePanel != null)
            StopCoroutine(_hidePanel);

        _hidePanel = PanelTimeout();
        StartCoroutine(_hidePanel);
    }

    IEnumerator PanelTimeout()
    {
        yield return new WaitForSeconds(1.0f);

        showHideWrapper.SetActive(false);
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
