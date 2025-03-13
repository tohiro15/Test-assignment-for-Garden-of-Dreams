using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;

    private void Awake()
    {
        _gridManager.Init();
        Debug.Log("Project initialized!");
    }
}