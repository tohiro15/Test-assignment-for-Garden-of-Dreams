using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Button[] _buildingButtons;
    [SerializeField] private Button _placeButton, _deleteButton;
    [SerializeField] private TextMeshProUGUI _modeText;

    private bool _isUIActive = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        for (int i = 0; i < _buildingButtons.Length; i++)
        {
            int index = i;
            _buildingButtons[i].onClick.AddListener(() => BuildingManager.Instance.SelectBuilding(index));
        }

        _placeButton.onClick.AddListener(() => InputHandler.Instance.EnablePlacementMode());
        _deleteButton.onClick.AddListener(() => InputHandler.Instance.EnableDeletionMode());

        UpdateModeText();
    }

    public void UpdateModeText()
    {
        if (InputHandler.Instance.IsInDeletionMode)
        {
            _modeText.text = "Режим \"Уничтожение\"";
        }
        else if (InputHandler.Instance.IsBuildingSelected)
        {
            _modeText.text = "Режим \"Создание\"";
        }
        else
        {
            _modeText.text = "Выберите режим";
        }
    }

    public bool IsUIActive()
    {
        return _isUIActive;
    }

    public void SetUIActive(bool isActive)
    {
        _isUIActive = isActive;
    }

    public void EnableUI()
    {
        SetUIActive(true);
    }

    public void DisableUI()
    {
        SetUIActive(false);
    }
}
