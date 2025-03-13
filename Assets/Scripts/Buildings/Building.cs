using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2Int _size = new Vector2Int(1, 1);

    public Vector2Int Size => _size;
}