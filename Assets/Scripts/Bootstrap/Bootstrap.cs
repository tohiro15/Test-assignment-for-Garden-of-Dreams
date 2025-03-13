using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _ground;
    [SerializeField] private BuildingManager _buildingManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private SaveManager _saveManager;

    [Header("Game Config")]
    [SerializeField] private GameConfig _gameConfig;

    private void Awake()
    {
        if (_gameConfig == null)
        {
            _gameConfig = Resources.Load<GameConfig>("GameConfig");
        }

        if (_gameConfig != null && _buildingManager != null)
        {
            _buildingManager.Init(_gameConfig);
        }
        else
        {
            Debug.LogError("GameConfig или BuildingManager не назначены!");
        }

        Vector3 floorSize = _ground.GetComponent<Renderer>().bounds.size;
        Vector2Int gridSize = new Vector2Int(Mathf.RoundToInt(floorSize.x), Mathf.RoundToInt(floorSize.z));

        _uiManager.Init();

        var buildingsData = _saveManager.LoadBuildings();
        if (buildingsData != null)
        {
            _buildingManager.LoadBuildings(buildingsData);
        }

        Debug.Log("ѕроект инициализирован!");
    }
}
