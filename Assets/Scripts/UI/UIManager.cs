using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button[] _buildingButtons;
    [SerializeField] private Button _placeButton, _deleteButton;

    public void Init(BuildingManager buildingManager)
    {
        for (int i = 0; i < _buildingButtons.Length; i++)
        {
            int index = i;
            _buildingButtons[i].onClick.AddListener(() => buildingManager.SelectBuilding(index));
        }

        _placeButton.onClick.AddListener(() => Debug.Log("Place mode activated"));
        _deleteButton.onClick.AddListener(() => Debug.Log("Delete mode activated"));
    }
}