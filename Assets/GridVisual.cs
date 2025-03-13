using UnityEngine;

public class GridVisual : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private Vector2Int _gridSize;
    private float _cellSize;
    private float _heightAdjustment = 0.5f; // �������� ��� ���������� ������ �������

    private void Start()
    {
        DrawGrid();
    }

    private void DrawGrid()
    {
        // ������� ���������� �����: ������������ � ��������������
        int verticalLines = _gridSize.x + 1; // �� 1 ������, ����� ���������� ��������� ������������ �����
        int horizontalLines = _gridSize.y + 1; // �� 1 ������, ����� ���������� ��������� �������������� �����
        int totalLines = verticalLines + horizontalLines;

        // ������������� ���������� ����� ��� ���������
        _lineRenderer.positionCount = totalLines * 2;

        int index = 0;

        // ������������ ������������ �����
        for (int x = 0; x <= _gridSize.x; x++)
        {
            float xPos = x * _cellSize;
            Vector3 start = new Vector3(xPos, _heightAdjustment, 0); // ������ ������������ ����� � �������
            Vector3 end = new Vector3(xPos, _heightAdjustment, _gridSize.y * _cellSize); // ����� ������������ ����� � �������
            _lineRenderer.SetPosition(index++, start);
            _lineRenderer.SetPosition(index++, end);
        }

        // ������������ �������������� �����
        for (int z = 0; z <= _gridSize.y; z++)
        {
            float zPos = z * _cellSize;
            Vector3 start = new Vector3(0, _heightAdjustment, zPos); // ������ �������������� ����� � �������
            Vector3 end = new Vector3(_gridSize.x * _cellSize, _heightAdjustment, zPos); // ����� �������������� ����� � �������
            _lineRenderer.SetPosition(index++, start);
            _lineRenderer.SetPosition(index++, end);
        }
    }
}
