using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _buildingPrefabs;
    private GameObject _currentBuilding;

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