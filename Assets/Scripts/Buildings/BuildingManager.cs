using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    [SerializeField] private GameObject[] _buildingPrefabs;
    private GameObject _currentBuilding;

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

    public void PlaceBuilding(Vector3 position)
    {
        if (_currentBuilding == null) return;

        var building = Instantiate(_currentBuilding, position, Quaternion.identity);
        Debug.Log("Building placed at: " + position);
    }

    public void SelectBuilding(int index)
    {
        if (index >= 0 && index < _buildingPrefabs.Length)
        {
            _currentBuilding = _buildingPrefabs[index];
            Debug.Log("Selected building: " + _currentBuilding.name);
        }
    }
}