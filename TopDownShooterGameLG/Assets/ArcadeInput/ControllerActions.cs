//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/ArcadeInput/ControllerActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ControllerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControllerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControllerActions"",
    ""maps"": [
        {
            ""name"": ""gamingActionMap"",
            ""id"": ""117ba502-b680-4494-bc0f-6dcf39dc4abd"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Value"",
                    ""id"": ""64ecdf55-ef43-4543-aabe-31c873883b11"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""shootInDirection"",
                    ""type"": ""Value"",
                    ""id"": ""efb40e1b-fbca-4d9a-bbc7-4f048b0d3484"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc87bdce-ae4a-4cdb-83b3-bc4b29692040"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox controlscheme"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b719090e-15e8-440f-9acf-27c5267f130b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox controlscheme"",
                    ""action"": ""shootInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""xbox controlscheme"",
            ""bindingGroup"": ""xbox controlscheme"",
            ""devices"": []
        }
    ]
}");
        // gamingActionMap
        m_gamingActionMap = asset.FindActionMap("gamingActionMap", throwIfNotFound: true);
        m_gamingActionMap_movement = m_gamingActionMap.FindAction("movement", throwIfNotFound: true);
        m_gamingActionMap_shootInDirection = m_gamingActionMap.FindAction("shootInDirection", throwIfNotFound: true);
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

    // gamingActionMap
    private readonly InputActionMap m_gamingActionMap;
    private IGamingActionMapActions m_GamingActionMapActionsCallbackInterface;
    private readonly InputAction m_gamingActionMap_movement;
    private readonly InputAction m_gamingActionMap_shootInDirection;
    public struct GamingActionMapActions
    {
        private @ControllerActions m_Wrapper;
        public GamingActionMapActions(@ControllerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_gamingActionMap_movement;
        public InputAction @shootInDirection => m_Wrapper.m_gamingActionMap_shootInDirection;
        public InputActionMap Get() { return m_Wrapper.m_gamingActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamingActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IGamingActionMapActions instance)
        {
            if (m_Wrapper.m_GamingActionMapActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_GamingActionMapActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_GamingActionMapActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_GamingActionMapActionsCallbackInterface.OnMovement;
                @shootInDirection.started -= m_Wrapper.m_GamingActionMapActionsCallbackInterface.OnShootInDirection;
                @shootInDirection.performed -= m_Wrapper.m_GamingActionMapActionsCallbackInterface.OnShootInDirection;
                @shootInDirection.canceled -= m_Wrapper.m_GamingActionMapActionsCallbackInterface.OnShootInDirection;
            }
            m_Wrapper.m_GamingActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @shootInDirection.started += instance.OnShootInDirection;
                @shootInDirection.performed += instance.OnShootInDirection;
                @shootInDirection.canceled += instance.OnShootInDirection;
            }
        }
    }
    public GamingActionMapActions @gamingActionMap => new GamingActionMapActions(this);
    private int m_xboxcontrolschemeSchemeIndex = -1;
    public InputControlScheme xboxcontrolschemeScheme
    {
        get
        {
            if (m_xboxcontrolschemeSchemeIndex == -1) m_xboxcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("xbox controlscheme");
            return asset.controlSchemes[m_xboxcontrolschemeSchemeIndex];
        }
    }
    public interface IGamingActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShootInDirection(InputAction.CallbackContext context);
    }
}