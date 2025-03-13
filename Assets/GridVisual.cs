using UnityEngine;

public class GridVisual : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private Vector2Int _gridSize;
    private float _cellSize;
    private float _heightAdjustment = 0.5f; // ѕараметр дл€ увеличени€ высоты графики

    private void Start()
    {
        DrawGrid();
    }

    private void DrawGrid()
    {
        // —читаем количество линий: вертикальные и горизонтальные
        int verticalLines = _gridSize.x + 1; // на 1 больше, чтобы нарисовать последнюю вертикальную линию
        int horizontalLines = _gridSize.y + 1; // на 1 больше, чтобы нарисовать последнюю горизонтальную линию
        int totalLines = verticalLines + horizontalLines;

        // ”станавливаем количество точек дл€ отрисовки
        _lineRenderer.positionCount = totalLines * 2;

        int index = 0;

        // ќтрисовываем вертикальные линии
        for (int x = 0; x <= _gridSize.x; x++)
        {
            float xPos = x * _cellSize;
            Vector3 start = new Vector3(xPos, _heightAdjustment, 0); // Ќачало вертикальной линии с высотой
            Vector3 end = new Vector3(xPos, _heightAdjustment, _gridSize.y * _cellSize); //  онец вертикальной линии с высотой
            _lineRenderer.SetPosition(index++, start);
            _lineRenderer.SetPosition(index++, end);
        }

        // ќтрисовываем горизонтальные линии
        for (int z = 0; z <= _gridSize.y; z++)
        {
            float zPos = z * _cellSize;
            Vector3 start = new Vector3(0, _heightAdjustment, zPos); // Ќачало горизонтальной линии с высотой
            Vector3 end = new Vector3(_gridSize.x * _cellSize, _heightAdjustment, zPos); //  онец горизонтальной линии с высотой
            _lineRenderer.SetPosition(index++, start);
            _lineRenderer.SetPosition(index++, end);
        }
    }
}
