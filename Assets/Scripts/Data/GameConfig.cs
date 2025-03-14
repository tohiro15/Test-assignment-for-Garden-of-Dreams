using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    public Vector2Int GridSize;
    public GameObject[] BuildingPrefabs;
}