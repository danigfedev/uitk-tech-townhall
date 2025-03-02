using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class TestToggleManager : MonoBehaviour
{
    [SerializeField] private Transform _uiParent;
    public VisualTreeAsset _buttonTemplate;

    private UIDocument _testCaseSelector;
    private VisualElement _mainContainer;
    private GameObject[] _uiTestCases;
    private Button [] _buttons;
    private GameObject _activeUI;
    private Button _activeButton;

    private void OnEnable()
    {
        if (_uiParent == null)
        {
            Debug.LogWarning("C'mon...you've forgotten the reference to the UI parent...");
            return;
        }
        
        Init();
        SetupButtons();
        ToggleUiTestCase(0);
    }
    
    private void Init()
    {
        _testCaseSelector = GetComponent<UIDocument>();
        _mainContainer = _testCaseSelector.rootVisualElement.Q<VisualElement>("mainContainer");
    }

    private void SetupButtons()
    {
        _uiTestCases = new GameObject[_uiParent.childCount];
        _buttons = new Button[_uiParent.childCount];

        var index = 0;
        foreach(Transform child in _uiParent)
        {
            var clonedVisualElement = _buttonTemplate.CloneTree();
            var clonedButton = clonedVisualElement.Q<Button>();
            clonedButton.text = child.name;

            var localIndex = index;
            clonedButton.clickable.clicked += () =>
            {
                ToggleUiTestCase(localIndex);
            };
            
            _buttons[index] = clonedButton;
            _mainContainer.Add(clonedVisualElement);
            
            var childGO = child.gameObject;
            childGO.SetActive(false);
            _uiTestCases[index] = childGO;
                
            index++;
        }
    }

    private void ToggleUiTestCase(int index)
    {
        _activeUI?.SetActive(false);
        _activeUI = _uiTestCases[index];
        _activeUI.SetActive(true);
        
        _activeButton?.RemoveFromClassList("highlighted");
        _activeButton = _buttons[index];
        _activeButton.AddToClassList("highlighted");
    }
}
