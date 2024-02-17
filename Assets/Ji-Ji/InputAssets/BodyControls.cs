//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Ji-Ji/InputAssets/BodyControls.inputactions
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

public partial class @BodyControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BodyControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BodyControls"",
    ""maps"": [
        {
            ""name"": ""BodyMovement"",
            ""id"": ""255112ee-4381-48b6-84ea-117622eb720e"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""9e0a5459-7438-4a5c-ba76-ce90db748089"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""cdca0d4a-990d-4c39-9d70-487cc54cb5af"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Strafe"",
                    ""type"": ""Value"",
                    ""id"": ""945571d2-d712-4227-96a8-69fc2a7c56c7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WS"",
                    ""id"": ""3f8d2bea-cb0a-42f2-80cb-056a0c970860"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""673d91d5-0488-401b-bf1f-2409edc532d0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c314ee7a-d100-4418-bd57-dd46edb360af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""623e8f65-3253-4566-bd30-9725202571f3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""206732dc-d4d2-4f2d-8cb5-0d0e89d66120"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b0d169e2-dccc-4121-8ccf-6fc552e70ad8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""QE"",
                    ""id"": ""3ab92c1e-002c-40df-9493-8792dd7d5274"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""70c146a1-094e-411e-b1fe-1dff17db3f4b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b2ff2ead-5b30-4422-a5c4-61f2595e57ce"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BodyMovement
        m_BodyMovement = asset.FindActionMap("BodyMovement", throwIfNotFound: true);
        m_BodyMovement_Walk = m_BodyMovement.FindAction("Walk", throwIfNotFound: true);
        m_BodyMovement_Turn = m_BodyMovement.FindAction("Turn", throwIfNotFound: true);
        m_BodyMovement_Strafe = m_BodyMovement.FindAction("Strafe", throwIfNotFound: true);
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

    // BodyMovement
    private readonly InputActionMap m_BodyMovement;
    private List<IBodyMovementActions> m_BodyMovementActionsCallbackInterfaces = new List<IBodyMovementActions>();
    private readonly InputAction m_BodyMovement_Walk;
    private readonly InputAction m_BodyMovement_Turn;
    private readonly InputAction m_BodyMovement_Strafe;
    public struct BodyMovementActions
    {
        private @BodyControls m_Wrapper;
        public BodyMovementActions(@BodyControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_BodyMovement_Walk;
        public InputAction @Turn => m_Wrapper.m_BodyMovement_Turn;
        public InputAction @Strafe => m_Wrapper.m_BodyMovement_Strafe;
        public InputActionMap Get() { return m_Wrapper.m_BodyMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BodyMovementActions set) { return set.Get(); }
        public void AddCallbacks(IBodyMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_BodyMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BodyMovementActionsCallbackInterfaces.Add(instance);
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
            @Turn.started += instance.OnTurn;
            @Turn.performed += instance.OnTurn;
            @Turn.canceled += instance.OnTurn;
            @Strafe.started += instance.OnStrafe;
            @Strafe.performed += instance.OnStrafe;
            @Strafe.canceled += instance.OnStrafe;
        }

        private void UnregisterCallbacks(IBodyMovementActions instance)
        {
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
            @Turn.started -= instance.OnTurn;
            @Turn.performed -= instance.OnTurn;
            @Turn.canceled -= instance.OnTurn;
            @Strafe.started -= instance.OnStrafe;
            @Strafe.performed -= instance.OnStrafe;
            @Strafe.canceled -= instance.OnStrafe;
        }

        public void RemoveCallbacks(IBodyMovementActions instance)
        {
            if (m_Wrapper.m_BodyMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBodyMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_BodyMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BodyMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BodyMovementActions @BodyMovement => new BodyMovementActions(this);
    public interface IBodyMovementActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnStrafe(InputAction.CallbackContext context);
    }
}
