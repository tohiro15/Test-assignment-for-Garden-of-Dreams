using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInputActions _input;
    
    private void Awake()
    {
        _input = new PlayerInputActions();
        _input.BuildingSelection.SelectBuilding1.performed += ctx => SelectBuilding(0);
        _input.BuildingSelection.SelectBuilding2.performed += ctx => SelectBuilding(1);
        _input.BuildingSelection.SelectBuilding3.performed += ctx => SelectBuilding(2);
        _input.Enable();
    }

    private void SelectBuilding(int index)
    {
        BuildingManager.Instance.SelectBuilding(index);
    }
}