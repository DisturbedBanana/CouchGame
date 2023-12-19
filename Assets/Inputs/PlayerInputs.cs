//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/PlayerInputs.inputactions
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

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Controller"",
            ""id"": ""995a9c64-a1e6-486d-845b-62deac28a5ec"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""93505179-ea6e-48dd-a8f6-5855f21a2afc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Tool"",
                    ""type"": ""Button"",
                    ""id"": ""e1326a6c-9bad-4a78-810f-b29952059ce6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0d0449e9-1198-444a-94e5-ef51f16c79b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""1b1713c4-137d-4582-a43d-19b7eb258be4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""a857cf32-2ade-447c-9708-89bd1a886311"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropWood"",
                    ""type"": ""Button"",
                    ""id"": ""367ae521-211a-4bc8-9cae-f31215f2d7d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropCoal"",
                    ""type"": ""Button"",
                    ""id"": ""1f5c0769-aa97-45fe-b12a-6ecd63c251ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropIron"",
                    ""type"": ""Button"",
                    ""id"": ""a26d1aba-7391-4a1a-b995-9a718acb2249"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Revive"",
                    ""type"": ""Button"",
                    ""id"": ""e473b32d-93dd-4818-ac28-708806a38976"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TotemTeleport"",
                    ""type"": ""Button"",
                    ""id"": ""10274c8b-b7e8-4b9e-8c6e-89ee642ccb6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TotemActivate"",
                    ""type"": ""Button"",
                    ""id"": ""b15c06c5-fa68-4967-860e-053edbc77294"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rope"",
                    ""type"": ""Button"",
                    ""id"": ""d2b22184-2dcb-49db-8323-f549fc64e05f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RepairBridge"",
                    ""type"": ""Button"",
                    ""id"": ""942305ee-435b-419d-b0e9-064510ad8852"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3222b9d-04c9-47ca-b3a5-13712656e110"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""afc2ff80-eff3-4d35-a024-ef10f48dd8d1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""51e759df-ddba-49b3-93d2-8234dd99cdd7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b0822c80-f20a-4d2e-aa2c-2026a018c05f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dae0b5b6-1c3b-42a0-a749-863d557eacb7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""142bb6c5-14c9-41fb-8488-38f5e6060a36"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""19ee6733-dfde-42bd-aa8c-6e76959baced"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Tool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c55b15d9-fb21-4dda-8a5f-1494e239134c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad5ccaf1-72d2-4c62-a81e-aab975142a2a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d1cb7eb-5e93-46d1-8798-ce61b7b190ac"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6e3a5b1-1d1b-41d7-83e4-abf6beb27b21"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""DropWood"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2811b7f-62c8-46ca-92dd-95b98033a9c5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b247d40-feb0-40ef-b4b7-78636c2da970"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TotemTeleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f4599ab-598a-4391-93c3-16ffe1f20974"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TotemActivate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""308aab06-5a00-4f1a-a6eb-81efe36404a6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rope"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e52d1ce5-fb77-4bd1-bcee-2b791e12bb6d"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""DropCoal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf6fbcd8-6319-45f8-a3b0-67eb07234975"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""DropIron"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb1a4d87-78df-4157-a754-a1fe4843b7ee"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RepairBridge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""cb5a8df0-a67e-423b-9fe8-3f282f779999"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""193ad603-6482-4245-b3e5-477471f557cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3d577a15-2127-470c-aacf-f61eb517455c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a6e95ab7-b5ba-4cce-95d5-7dbf0dab1f65"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9df0646-73d3-4b04-9339-ae834395ccda"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dead"",
            ""id"": ""a0f82322-92cf-4777-8790-49609db50ae2"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2b1c8ea3-a2e5-42e0-acb5-726a91574dc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""32007b05-63b9-4ed5-ac64-3c9a77cb47d9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3cf5e83-a85b-4388-90cc-72e6c61b22e4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ee037795-5d50-4fed-ac42-c7c58060dcf4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""30a9b38d-4c91-4d85-81cb-fc71ccfec5fa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a7d51fb9-ab99-4b33-8184-f2604a418016"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f7bfd271-e16e-44e5-a127-228997210175"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c27d2c95-6c27-42f6-8df0-c0cac0949b01"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c5c72e1c-e35f-47d1-bc6d-39b2f9a00a6f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Controller
        m_Controller = asset.FindActionMap("Controller", throwIfNotFound: true);
        m_Controller_Movement = m_Controller.FindAction("Movement", throwIfNotFound: true);
        m_Controller_Tool = m_Controller.FindAction("Tool", throwIfNotFound: true);
        m_Controller_Jump = m_Controller.FindAction("Jump", throwIfNotFound: true);
        m_Controller_Pause = m_Controller.FindAction("Pause", throwIfNotFound: true);
        m_Controller_PickUp = m_Controller.FindAction("PickUp", throwIfNotFound: true);
        m_Controller_DropWood = m_Controller.FindAction("DropWood", throwIfNotFound: true);
        m_Controller_DropCoal = m_Controller.FindAction("DropCoal", throwIfNotFound: true);
        m_Controller_DropIron = m_Controller.FindAction("DropIron", throwIfNotFound: true);
        m_Controller_Revive = m_Controller.FindAction("Revive", throwIfNotFound: true);
        m_Controller_TotemTeleport = m_Controller.FindAction("TotemTeleport", throwIfNotFound: true);
        m_Controller_TotemActivate = m_Controller.FindAction("TotemActivate", throwIfNotFound: true);
        m_Controller_Rope = m_Controller.FindAction("Rope", throwIfNotFound: true);
        m_Controller_RepairBridge = m_Controller.FindAction("RepairBridge", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Back = m_UI.FindAction("Back", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        // Dead
        m_Dead = asset.FindActionMap("Dead", throwIfNotFound: true);
        m_Dead_Pause = m_Dead.FindAction("Pause", throwIfNotFound: true);
        m_Dead_Movement = m_Dead.FindAction("Movement", throwIfNotFound: true);
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

    // Controller
    private readonly InputActionMap m_Controller;
    private List<IControllerActions> m_ControllerActionsCallbackInterfaces = new List<IControllerActions>();
    private readonly InputAction m_Controller_Movement;
    private readonly InputAction m_Controller_Tool;
    private readonly InputAction m_Controller_Jump;
    private readonly InputAction m_Controller_Pause;
    private readonly InputAction m_Controller_PickUp;
    private readonly InputAction m_Controller_DropWood;
    private readonly InputAction m_Controller_DropCoal;
    private readonly InputAction m_Controller_DropIron;
    private readonly InputAction m_Controller_Revive;
    private readonly InputAction m_Controller_TotemTeleport;
    private readonly InputAction m_Controller_TotemActivate;
    private readonly InputAction m_Controller_Rope;
    private readonly InputAction m_Controller_RepairBridge;
    public struct ControllerActions
    {
        private @PlayerInputs m_Wrapper;
        public ControllerActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Controller_Movement;
        public InputAction @Tool => m_Wrapper.m_Controller_Tool;
        public InputAction @Jump => m_Wrapper.m_Controller_Jump;
        public InputAction @Pause => m_Wrapper.m_Controller_Pause;
        public InputAction @PickUp => m_Wrapper.m_Controller_PickUp;
        public InputAction @DropWood => m_Wrapper.m_Controller_DropWood;
        public InputAction @DropCoal => m_Wrapper.m_Controller_DropCoal;
        public InputAction @DropIron => m_Wrapper.m_Controller_DropIron;
        public InputAction @Revive => m_Wrapper.m_Controller_Revive;
        public InputAction @TotemTeleport => m_Wrapper.m_Controller_TotemTeleport;
        public InputAction @TotemActivate => m_Wrapper.m_Controller_TotemActivate;
        public InputAction @Rope => m_Wrapper.m_Controller_Rope;
        public InputAction @RepairBridge => m_Wrapper.m_Controller_RepairBridge;
        public InputActionMap Get() { return m_Wrapper.m_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void AddCallbacks(IControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_ControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControllerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Tool.started += instance.OnTool;
            @Tool.performed += instance.OnTool;
            @Tool.canceled += instance.OnTool;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @PickUp.started += instance.OnPickUp;
            @PickUp.performed += instance.OnPickUp;
            @PickUp.canceled += instance.OnPickUp;
            @DropWood.started += instance.OnDropWood;
            @DropWood.performed += instance.OnDropWood;
            @DropWood.canceled += instance.OnDropWood;
            @DropCoal.started += instance.OnDropCoal;
            @DropCoal.performed += instance.OnDropCoal;
            @DropCoal.canceled += instance.OnDropCoal;
            @DropIron.started += instance.OnDropIron;
            @DropIron.performed += instance.OnDropIron;
            @DropIron.canceled += instance.OnDropIron;
            @Revive.started += instance.OnRevive;
            @Revive.performed += instance.OnRevive;
            @Revive.canceled += instance.OnRevive;
            @TotemTeleport.started += instance.OnTotemTeleport;
            @TotemTeleport.performed += instance.OnTotemTeleport;
            @TotemTeleport.canceled += instance.OnTotemTeleport;
            @TotemActivate.started += instance.OnTotemActivate;
            @TotemActivate.performed += instance.OnTotemActivate;
            @TotemActivate.canceled += instance.OnTotemActivate;
            @Rope.started += instance.OnRope;
            @Rope.performed += instance.OnRope;
            @Rope.canceled += instance.OnRope;
            @RepairBridge.started += instance.OnRepairBridge;
            @RepairBridge.performed += instance.OnRepairBridge;
            @RepairBridge.canceled += instance.OnRepairBridge;
        }

        private void UnregisterCallbacks(IControllerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Tool.started -= instance.OnTool;
            @Tool.performed -= instance.OnTool;
            @Tool.canceled -= instance.OnTool;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @PickUp.started -= instance.OnPickUp;
            @PickUp.performed -= instance.OnPickUp;
            @PickUp.canceled -= instance.OnPickUp;
            @DropWood.started -= instance.OnDropWood;
            @DropWood.performed -= instance.OnDropWood;
            @DropWood.canceled -= instance.OnDropWood;
            @DropCoal.started -= instance.OnDropCoal;
            @DropCoal.performed -= instance.OnDropCoal;
            @DropCoal.canceled -= instance.OnDropCoal;
            @DropIron.started -= instance.OnDropIron;
            @DropIron.performed -= instance.OnDropIron;
            @DropIron.canceled -= instance.OnDropIron;
            @Revive.started -= instance.OnRevive;
            @Revive.performed -= instance.OnRevive;
            @Revive.canceled -= instance.OnRevive;
            @TotemTeleport.started -= instance.OnTotemTeleport;
            @TotemTeleport.performed -= instance.OnTotemTeleport;
            @TotemTeleport.canceled -= instance.OnTotemTeleport;
            @TotemActivate.started -= instance.OnTotemActivate;
            @TotemActivate.performed -= instance.OnTotemActivate;
            @TotemActivate.canceled -= instance.OnTotemActivate;
            @Rope.started -= instance.OnRope;
            @Rope.performed -= instance.OnRope;
            @Rope.canceled -= instance.OnRope;
            @RepairBridge.started -= instance.OnRepairBridge;
            @RepairBridge.performed -= instance.OnRepairBridge;
            @RepairBridge.canceled -= instance.OnRepairBridge;
        }

        public void RemoveCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_ControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Back;
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @PlayerInputs m_Wrapper;
        public UIActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_UI_Back;
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Back.started += instance.OnBack;
            @Back.performed += instance.OnBack;
            @Back.canceled += instance.OnBack;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Back.started -= instance.OnBack;
            @Back.performed -= instance.OnBack;
            @Back.canceled -= instance.OnBack;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);

    // Dead
    private readonly InputActionMap m_Dead;
    private List<IDeadActions> m_DeadActionsCallbackInterfaces = new List<IDeadActions>();
    private readonly InputAction m_Dead_Pause;
    private readonly InputAction m_Dead_Movement;
    public struct DeadActions
    {
        private @PlayerInputs m_Wrapper;
        public DeadActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Dead_Pause;
        public InputAction @Movement => m_Wrapper.m_Dead_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Dead; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeadActions set) { return set.Get(); }
        public void AddCallbacks(IDeadActions instance)
        {
            if (instance == null || m_Wrapper.m_DeadActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DeadActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IDeadActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(IDeadActions instance)
        {
            if (m_Wrapper.m_DeadActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDeadActions instance)
        {
            foreach (var item in m_Wrapper.m_DeadActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DeadActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DeadActions @Dead => new DeadActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IControllerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnTool(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnDropWood(InputAction.CallbackContext context);
        void OnDropCoal(InputAction.CallbackContext context);
        void OnDropIron(InputAction.CallbackContext context);
        void OnRevive(InputAction.CallbackContext context);
        void OnTotemTeleport(InputAction.CallbackContext context);
        void OnTotemActivate(InputAction.CallbackContext context);
        void OnRope(InputAction.CallbackContext context);
        void OnRepairBridge(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IDeadActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
