using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private BuildingManager _buildingManager;

    private void Awake()
    {
        _gridManager.Init();
        _buildingManager.SelectBuilding(0);
        Debug.Log("Project initialized!");
    }
}