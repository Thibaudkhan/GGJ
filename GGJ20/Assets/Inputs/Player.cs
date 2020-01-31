// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""543676e8-71af-40c8-a022-c602178cec2d"",
            ""actions"": [
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""8d4edc0c-fc92-4e64-b106-5f9401e96d90"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""43983850-8923-485f-be7f-b0c797de131d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""88961aca-96a4-49ab-9535-e89102c950c2"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0ccaac5-fa28-4289-8b68-7d20c776563f"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3641f2de-9019-4e02-9af5-cbd8abcc945c"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b41ee5b4-491c-453a-91cb-b5de6e1d05f9"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Down = m_PlayerControls.FindAction("Down", throwIfNotFound: true);
        m_PlayerControls_Right = m_PlayerControls.FindAction("Right", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Down;
    private readonly InputAction m_PlayerControls_Right;
    public struct PlayerControlsActions
    {
        private @Player m_Wrapper;
        public PlayerControlsActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Down => m_Wrapper.m_PlayerControls_Down;
        public InputAction @Right => m_Wrapper.m_PlayerControls_Right;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Down.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDown;
                @Right.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnDown(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
