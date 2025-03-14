using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""BuildingSelection"",
            ""id"": ""b6d6536c-0bed-44f4-9d17-b2d8ee7f0432"",
            ""actions"": [
                {
                    ""name"": ""SelectBuilding1"",
                    ""type"": ""Button"",
                    ""id"": ""c828a157-73f9-407d-8ae9-d130e86ef4eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectBuilding2"",
                    ""type"": ""Button"",
                    ""id"": ""78b7506f-4048-47a4-8760-68f9b4110478"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectBuilding3"",
                    ""type"": ""Button"",
                    ""id"": ""9df35ef4-54ce-40a8-822b-61cb13c905bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9eb2200e-e5c4-48d2-92ad-0559a9e0e424"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectBuilding1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09ef2061-5a93-4714-92e9-94c9cade3bde"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectBuilding2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e5fe9fd-fb7e-46f9-89b2-fe76a626b135"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectBuilding3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlacementMode"",
            ""id"": ""b4e7cb91-66df-43b9-a7b9-4d19680a2ac5"",
            ""actions"": [
                {
                    ""name"": ""PlaceBuilding"",
                    ""type"": ""Button"",
                    ""id"": ""3c28bb40-1612-418c-ad6a-409647abb992"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dee2c26a-c874-4ef9-b3a9-8755310b1705"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceBuilding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DeletionMode"",
            ""id"": ""bff5066a-1c4c-421a-a716-b871dfda46db"",
            ""actions"": [
                {
                    ""name"": ""DeleteBuilding"",
                    ""type"": ""Button"",
                    ""id"": ""2c84585b-f7b8-4b8b-83c6-ff321e871180"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a89b29bb-63dc-41a9-888d-0369cd4bacb8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeleteBuilding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        m_BuildingSelection = asset.FindActionMap("BuildingSelection", throwIfNotFound: true);
        m_BuildingSelection_SelectBuilding1 = m_BuildingSelection.FindAction("SelectBuilding1", throwIfNotFound: true);
        m_BuildingSelection_SelectBuilding2 = m_BuildingSelection.FindAction("SelectBuilding2", throwIfNotFound: true);
        m_BuildingSelection_SelectBuilding3 = m_BuildingSelection.FindAction("SelectBuilding3", throwIfNotFound: true);
        m_PlacementMode = asset.FindActionMap("PlacementMode", throwIfNotFound: true);
        m_PlacementMode_PlaceBuilding = m_PlacementMode.FindAction("PlaceBuilding", throwIfNotFound: true);
        m_DeletionMode = asset.FindActionMap("DeletionMode", throwIfNotFound: true);
        m_DeletionMode_DeleteBuilding = m_DeletionMode.FindAction("DeleteBuilding", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    private readonly InputActionMap m_BuildingSelection;
    private List<IBuildingSelectionActions> m_BuildingSelectionActionsCallbackInterfaces = new List<IBuildingSelectionActions>();
    private readonly InputAction m_BuildingSelection_SelectBuilding1;
    private readonly InputAction m_BuildingSelection_SelectBuilding2;
    private readonly InputAction m_BuildingSelection_SelectBuilding3;
    public struct BuildingSelectionActions
    {
        private @PlayerInputActions m_Wrapper;
        public BuildingSelectionActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectBuilding1 => m_Wrapper.m_BuildingSelection_SelectBuilding1;
        public InputAction @SelectBuilding2 => m_Wrapper.m_BuildingSelection_SelectBuilding2;
        public InputAction @SelectBuilding3 => m_Wrapper.m_BuildingSelection_SelectBuilding3;
        public InputActionMap Get() { return m_Wrapper.m_BuildingSelection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BuildingSelectionActions set) { return set.Get(); }
        public void AddCallbacks(IBuildingSelectionActions instance)
        {
            if (instance == null || m_Wrapper.m_BuildingSelectionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BuildingSelectionActionsCallbackInterfaces.Add(instance);
            @SelectBuilding1.started += instance.OnSelectBuilding1;
            @SelectBuilding1.performed += instance.OnSelectBuilding1;
            @SelectBuilding1.canceled += instance.OnSelectBuilding1;
            @SelectBuilding2.started += instance.OnSelectBuilding2;
            @SelectBuilding2.performed += instance.OnSelectBuilding2;
            @SelectBuilding2.canceled += instance.OnSelectBuilding2;
            @SelectBuilding3.started += instance.OnSelectBuilding3;
            @SelectBuilding3.performed += instance.OnSelectBuilding3;
            @SelectBuilding3.canceled += instance.OnSelectBuilding3;
        }

        private void UnregisterCallbacks(IBuildingSelectionActions instance)
        {
            @SelectBuilding1.started -= instance.OnSelectBuilding1;
            @SelectBuilding1.performed -= instance.OnSelectBuilding1;
            @SelectBuilding1.canceled -= instance.OnSelectBuilding1;
            @SelectBuilding2.started -= instance.OnSelectBuilding2;
            @SelectBuilding2.performed -= instance.OnSelectBuilding2;
            @SelectBuilding2.canceled -= instance.OnSelectBuilding2;
            @SelectBuilding3.started -= instance.OnSelectBuilding3;
            @SelectBuilding3.performed -= instance.OnSelectBuilding3;
            @SelectBuilding3.canceled -= instance.OnSelectBuilding3;
        }

        public void RemoveCallbacks(IBuildingSelectionActions instance)
        {
            if (m_Wrapper.m_BuildingSelectionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBuildingSelectionActions instance)
        {
            foreach (var item in m_Wrapper.m_BuildingSelectionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BuildingSelectionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BuildingSelectionActions @BuildingSelection => new BuildingSelectionActions(this);

    private readonly InputActionMap m_PlacementMode;
    private List<IPlacementModeActions> m_PlacementModeActionsCallbackInterfaces = new List<IPlacementModeActions>();
    private readonly InputAction m_PlacementMode_PlaceBuilding;
    public struct PlacementModeActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlacementModeActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceBuilding => m_Wrapper.m_PlacementMode_PlaceBuilding;
        public InputActionMap Get() { return m_Wrapper.m_PlacementMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlacementModeActions set) { return set.Get(); }
        public void AddCallbacks(IPlacementModeActions instance)
        {
            if (instance == null || m_Wrapper.m_PlacementModeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlacementModeActionsCallbackInterfaces.Add(instance);
            @PlaceBuilding.started += instance.OnPlaceBuilding;
            @PlaceBuilding.performed += instance.OnPlaceBuilding;
            @PlaceBuilding.canceled += instance.OnPlaceBuilding;
        }

        private void UnregisterCallbacks(IPlacementModeActions instance)
        {
            @PlaceBuilding.started -= instance.OnPlaceBuilding;
            @PlaceBuilding.performed -= instance.OnPlaceBuilding;
            @PlaceBuilding.canceled -= instance.OnPlaceBuilding;
        }

        public void RemoveCallbacks(IPlacementModeActions instance)
        {
            if (m_Wrapper.m_PlacementModeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlacementModeActions instance)
        {
            foreach (var item in m_Wrapper.m_PlacementModeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlacementModeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlacementModeActions @PlacementMode => new PlacementModeActions(this);

    private readonly InputActionMap m_DeletionMode;
    private List<IDeletionModeActions> m_DeletionModeActionsCallbackInterfaces = new List<IDeletionModeActions>();
    private readonly InputAction m_DeletionMode_DeleteBuilding;
    public struct DeletionModeActions
    {
        private @PlayerInputActions m_Wrapper;
        public DeletionModeActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @DeleteBuilding => m_Wrapper.m_DeletionMode_DeleteBuilding;
        public InputActionMap Get() { return m_Wrapper.m_DeletionMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeletionModeActions set) { return set.Get(); }
        public void AddCallbacks(IDeletionModeActions instance)
        {
            if (instance == null || m_Wrapper.m_DeletionModeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DeletionModeActionsCallbackInterfaces.Add(instance);
            @DeleteBuilding.started += instance.OnDeleteBuilding;
            @DeleteBuilding.performed += instance.OnDeleteBuilding;
            @DeleteBuilding.canceled += instance.OnDeleteBuilding;
        }

        private void UnregisterCallbacks(IDeletionModeActions instance)
        {
            @DeleteBuilding.started -= instance.OnDeleteBuilding;
            @DeleteBuilding.performed -= instance.OnDeleteBuilding;
            @DeleteBuilding.canceled -= instance.OnDeleteBuilding;
        }

        public void RemoveCallbacks(IDeletionModeActions instance)
        {
            if (m_Wrapper.m_DeletionModeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDeletionModeActions instance)
        {
            foreach (var item in m_Wrapper.m_DeletionModeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DeletionModeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DeletionModeActions @DeletionMode => new DeletionModeActions(this);
    public interface IBuildingSelectionActions
    {
        void OnSelectBuilding1(InputAction.CallbackContext context);
        void OnSelectBuilding2(InputAction.CallbackContext context);
        void OnSelectBuilding3(InputAction.CallbackContext context);
    }
    public interface IPlacementModeActions
    {
        void OnPlaceBuilding(InputAction.CallbackContext context);
    }
    public interface IDeletionModeActions
    {
        void OnDeleteBuilding(InputAction.CallbackContext context);
    }
}
