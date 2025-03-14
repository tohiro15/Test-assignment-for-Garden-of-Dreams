using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }

    private PlayerInputActions _input;
    private bool _isDeletionMode;
    private bool _isBuildingSelected;

    private void Awake()
    {
        InitializeSingleton();
        InitializeInputActions();
        DisableAllModes();
    }

    private void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeInputActions()
    {
        _input = new PlayerInputActions();

        _input.BuildingSelection.SelectBuilding1.performed += ctx => SelectBuilding(0);
        _input.BuildingSelection.SelectBuilding2.performed += ctx => SelectBuilding(1);
        _input.BuildingSelection.SelectBuilding3.performed += ctx => SelectBuilding(2);
        _input.PlacementMode.PlaceBuilding.performed += ctx => PlaceBuilding();
        _input.PlacementMode.RotateBuilding.performed += ctx => RotateBuilding();
        _input.DeletionMode.DeleteBuilding.performed += ctx => DeleteBuilding();
        _input.General.Quit.performed += ctx => QuitGame();


        _input.Enable();
    }

    private void RotateBuilding()
    {
        if (_isBuildingSelected)
        {
            BuildingManager.Instance.RotatePreview(90);
        }
    }

    private void DisableAllModes()
    {
        _input.PlacementMode.Disable();
        _input.DeletionMode.Disable();
    }

    private void Update()
    {
        if (_isDeletionMode)
        {
            HandleDeletionMode();
        }
        else if (_isBuildingSelected)
        {
            UpdatePreview();
        }
    }

    private void HandleDeletionMode()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUI())
        {
            PerformRaycastAndDelete();
        }
    }

    private void PerformRaycastAndDelete()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            BuildingManager.Instance.DeleteBuilding(hit.point);
        }
    }

    private void UpdatePreview()
    {
        if (!_isBuildingSelected) return;

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            BuildingManager.Instance.UpdatePreview(hit.point);
        }
    }

    private void PlaceBuilding()
    {
        if (_isDeletionMode || IsPointerOverUI()) return;

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            BuildingManager.Instance.PlaceBuilding(hit.point);
        }
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void DeleteBuilding()
    {
        if (!_isDeletionMode || IsPointerOverUI()) return;

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        BuildingManager.Instance.DeleteBuilding(mousePosition);
    }

    private void SelectBuilding(int buildingIndex)
    {
        if (_isDeletionMode) return;

        _isBuildingSelected = true;
        BuildingManager.Instance.SelectBuilding(buildingIndex);
        BuildingManager.Instance.EnablePreview();
        EnablePlacementMode();
    }

    public void EnablePlacementMode()
    {
        if (_isDeletionMode) DisableDeletionMode();

        _isBuildingSelected = true;
        _input.PlacementMode.Enable();
        _input.DeletionMode.Disable();
        BuildingManager.Instance.EnablePreview();
        UIManager.Instance.UpdateModeText();
    }

    public void EnableDeletionMode()
    {
        if (_isBuildingSelected) DisableBuildingMode();

        _isBuildingSelected = false;
        _isDeletionMode = true;
        _input.DeletionMode.Enable();
        _input.PlacementMode.Disable();
        BuildingManager.Instance.DisablePreview();
        UIManager.Instance.UpdateModeText();
    }

    private void DisableBuildingMode()
    {
        _isBuildingSelected = false;
        BuildingManager.Instance.DisablePreview();
        _input.PlacementMode.Disable();
    }

    private void DisableDeletionMode()
    {
        _isDeletionMode = false;
        _input.DeletionMode.Disable();
        BuildingManager.Instance.DisablePreview();
    }

    private void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnDestroy()
    {
        _input.Disable();
    }

    public bool IsInDeletionMode => _isDeletionMode;
    public bool IsBuildingSelected => _isBuildingSelected;
}
