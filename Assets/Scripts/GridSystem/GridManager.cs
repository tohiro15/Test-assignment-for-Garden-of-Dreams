using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize = new(10, 10);
    [SerializeField] private float _cellSize = 1f;
    private bool[,] _grid;

    public void Init()
    {
        _grid = new bool[_gridSize.x, _gridSize.y];
        GenerateGridVisual();
    }

    private void GenerateGridVisual()
    {
        Debug.Log("Grid generated with size: " + _gridSize);
    }

    public Vector3 GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        int z = Mathf.FloorToInt(worldPosition.z / _cellSize);
        return new Vector3(x * _cellSize, 0, z * _cellSize);
    }
}