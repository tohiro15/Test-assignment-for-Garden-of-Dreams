using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    private GameConfig _gameConfig;

    private List<GameObject> _buildings = new();
    private GameObject _currentBuilding;
    private GameObject _buildingPreview;

    private GameObject[] _buildingPrefabs;

    public Vector2Int GridSize => _gameConfig.GridSize;

    private SaveManager _saveManager;

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

        _saveManager = FindObjectOfType<SaveManager>();
    }

    public void Init(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;

        if (_gameConfig == null)
        {
            Debug.LogError("GameConfig is not assigned!");
            return;
        }

        _buildingPrefabs = _gameConfig.BuildingPrefabs;
    }

    public void SelectBuilding(int index)
    {
        if (index >= 0 && index < _buildingPrefabs.Length)
        {
            _currentBuilding = _buildingPrefabs[index];

            if (_currentBuilding != null)
            {
                CreatePreview();
            }
            else
            {
                Debug.LogWarning("Selected building is null!");
            }
        }
        else
        {
            Debug.LogWarning("Invalid building index selected!");
        }
    }

    public void CreatePreview()
    {
        if (_buildingPreview != null) Destroy(_buildingPreview);
        _buildingPreview = Instantiate(_currentBuilding);
        _buildingPreview.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        _buildingPreview.SetActive(true);
    }

    public void EnablePreview()
    {
        if (_buildingPreview == null && _currentBuilding != null)
        {
            CreatePreview();
        }
        else if (_buildingPreview != null)
        {
            _buildingPreview.SetActive(true);
        }
    }

    public void DisablePreview()
    {
        if (_buildingPreview != null)
        {
            Destroy(_buildingPreview);
            _buildingPreview = null;
        }
    }

    public void UpdatePreview(Vector3 position)
    {
        if (_buildingPreview == null) return;

        Vector2Int buildingSize = _currentBuilding.GetComponent<Building>().Size;

        Vector3 gridPosition = SnapToGrid(position, buildingSize);
        _buildingPreview.transform.position = gridPosition;

        bool canPlace = IsAreaFree(gridPosition, buildingSize);
        _buildingPreview.GetComponent<Renderer>().material.color = canPlace ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
    }

    public void PlaceBuilding(Vector3 position)
    {
        if (_currentBuilding == null) return;

        Vector2Int buildingSize = _currentBuilding.GetComponent<Building>().Size;
        Vector3 gridPosition = SnapToGrid(position, buildingSize);

        if (IsAreaFree(gridPosition, buildingSize))
        {
            var building = Instantiate(_currentBuilding, gridPosition, Quaternion.identity);
            _buildings.Add(building);
        }
        else
        {
            Debug.LogWarning("Area is occupied!");
        }
    }

    private Vector3 SnapToGrid(Vector3 position, Vector2Int buildingSize)
    {
        float x = Mathf.Floor(position.x / GridSize.x) * GridSize.x;
        float z = Mathf.Floor(position.z / GridSize.y) * GridSize.y;

        float offsetX = (buildingSize.x * GridSize.x) / 2f;
        float offsetZ = (buildingSize.y * GridSize.y) / 2f;

        return new Vector3(x + offsetX, 0, z + offsetZ);
    }

    private bool IsAreaFree(Vector3 position, Vector2Int size)
    {
        Vector3 centerPosition = position;

        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.y; z++)
            {
                Vector3 offset = new Vector3(x * GridSize.x, 0, z * GridSize.y);
                Vector3 checkPosition = centerPosition + offset;

                bool isOccupied = false;

                foreach (var building in _buildings)
                {
                    Vector3 buildingPosition = building.transform.position;
                    Vector2Int buildingSize = building.GetComponent<Building>().Size;

                    bool isOverlappingX = Mathf.Abs(checkPosition.x - buildingPosition.x) < (buildingSize.x * GridSize.x);
                    bool isOverlappingZ = Mathf.Abs(checkPosition.z - buildingPosition.z) < (buildingSize.y * GridSize.y);

                    if (isOverlappingX && isOverlappingZ)
                    {
                        isOccupied = true;
                        break;
                    }
                }

                if (isOccupied)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void DeleteBuilding(Vector3 position)
    {
        int buildingLayerMask = 1 << LayerMask.NameToLayer("Buildings");

        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, buildingLayerMask))
        {
            Building building = hit.collider.GetComponent<Building>();
            if (building != null && _buildings.Contains(hit.collider.gameObject))
            {
                _buildings.Remove(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void LoadBuildings(BuildingsData data)
    {
        ClearAllBuildings();

        foreach (var buildingData in data.Buildings)
        {
            var prefab = _buildingPrefabs[buildingData.PrefabIndex];
            var building = Instantiate(prefab, buildingData.Position, Quaternion.identity);
            _buildings.Add(building);
        }
    }

    private void ClearAllBuildings()
    {
        foreach (var building in _buildings)
        {
            Destroy(building);
        }
        _buildings.Clear();
    }
}
