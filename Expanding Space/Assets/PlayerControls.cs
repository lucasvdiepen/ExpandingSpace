// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""0e26092c-e27c-41d8-a49e-9af81532948e"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fd4e08ba-29a5-4cfe-9977-6e653fce8c72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dig"",
                    ""type"": ""Button"",
                    ""id"": ""b93d2629-b853-4639-abfb-f6b64cb9fc72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6a56cf9e-2bd5-44a1-bc30-ceb29982a730"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2172e891-9b85-4e2e-a9dd-72c6b8e6f75d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4327304-1fd1-479a-94d7-c4accccb0028"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5783cd07-a6b2-4ae3-becc-f5118839537c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbc332c8-5bab-4bbb-ba85-d69d5c3f414b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23617c4e-37a0-4743-be08-b22c837dc4c7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0f5d8c5f-6870-4275-9748-769a23a92e72"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""9939310a-2b7e-4e86-b338-6113f90e44ab"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""c91a2abc-ff68-4baf-803c-6e63b0b83ac2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""02f6221c-ed0e-41d5-807f-1e5d2b11c613"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""6017683d-96c5-4421-801c-89efa69e548f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Dialog"",
            ""id"": ""268c1a13-ea11-476f-bd12-fa918fab1ff4"",
            ""actions"": [
                {
                    ""name"": ""ContinueDialog"",
                    ""type"": ""Button"",
                    ""id"": ""986c66a5-9055-4f9f-a931-310c22690ed9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartDialog"",
                    ""type"": ""Button"",
                    ""id"": ""0e70b165-6c12-41ef-8717-86a8b10df83f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ba0f9cfa-ecfe-4a47-9464-7b67aaa94967"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContinueDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e771fff-ad08-49d7-9d3f-36191d3dac88"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContinueDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e1ffed3-7052-4bc2-b6cb-43c09189602e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c62e604-5e26-4c2c-bce5-6be4c202f8d3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shooting"",
            ""id"": ""16514041-f0a8-4eab-a9f3-bd98ee24a356"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b797099d-e637-4750-bdc0-7752b0f7770f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""b82f9725-429e-4c7b-aca9-f8bbcf48f0d0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimingMouse"",
                    ""type"": ""Value"",
                    ""id"": ""4b4e6729-0883-4a8c-9023-4606c978ae63"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimingController"",
                    ""type"": ""Value"",
                    ""id"": ""173006fd-a1eb-433a-9147-f7dd5bb12281"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""139a8a90-2136-4a02-bc36-bfd599a187ae"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2c4b737-14e2-4290-8e49-3988427597ba"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5f0c0c6-9b83-405e-b2d5-35e665261b52"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d2952d7-822d-4d48-b953-afd85e285aa2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3fd9181-7c5a-4dc7-8644-2d7699106d35"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimingMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2ec3b40-144c-4749-8a4a-ff298f874aaa"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimingController"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""6bea5eef-2265-400d-83fe-80a9b30330f8"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""506c6e38-7f87-41f0-98dd-0ba8b8d639f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ControllerMouse"",
                    ""type"": ""Value"",
                    ""id"": ""765e5007-0299-47ef-89b9-b5bffc33427c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ControllerClick"",
                    ""type"": ""Button"",
                    ""id"": ""ddce8323-4d1f-44ac-976d-c6f5fb341fab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35360cae-13bc-4399-9056-56bc367fe302"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f5f9c13-9a69-414d-926e-55b05bd95d0d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e236a9bf-a829-424a-a83b-c300d5079f0f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""97b689a3-c504-4b5c-ba22-26cbdf80df75"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMouse"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0b79666c-5174-413a-80d6-b08c7c59f030"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2b80d000-6f83-4a9c-b50a-d2dd880a1211"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cea05d03-a355-4bc8-b717-8758cdb86f40"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""34a9aa10-f41f-4b32-a27e-2c6ceac3791f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""037f3b13-359e-481a-90df-5287c70f1e4c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df687ba7-36f9-4338-bd41-b5ec2fc4d73c"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Base"",
            ""id"": ""725fafbb-330b-4ecc-9bf4-0ae443742d25"",
            ""actions"": [
                {
                    ""name"": ""EnterBase"",
                    ""type"": ""Button"",
                    ""id"": ""0b997afb-87dd-46f0-be4d-33df5225f1fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7253e11a-6758-4b22-b37e-381f1a42478a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterBase"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""374d0b54-6f49-4cf3-b796-10de2bcdf0d3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterBase"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Map"",
            ""id"": ""2550fa94-505f-4097-9c30-6d3c286fe384"",
            ""actions"": [
                {
                    ""name"": ""MapExit"",
                    ""type"": ""Button"",
                    ""id"": ""18d5a7ed-a987-49ce-9d96-5431428592c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""759c6c1c-3ba4-409f-88e4-e659de2b1625"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MapExit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab2cf6dc-e28a-4338-9cab-1ef442dc67c7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MapExit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Dig = m_Gameplay.FindAction("Dig", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        // Dialog
        m_Dialog = asset.FindActionMap("Dialog", throwIfNotFound: true);
        m_Dialog_ContinueDialog = m_Dialog.FindAction("ContinueDialog", throwIfNotFound: true);
        m_Dialog_StartDialog = m_Dialog.FindAction("StartDialog", throwIfNotFound: true);
        // Shooting
        m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
        m_Shooting_Shoot = m_Shooting.FindAction("Shoot", throwIfNotFound: true);
        m_Shooting_Aiming = m_Shooting.FindAction("Aiming", throwIfNotFound: true);
        m_Shooting_AimingMouse = m_Shooting.FindAction("AimingMouse", throwIfNotFound: true);
        m_Shooting_AimingController = m_Shooting.FindAction("AimingController", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        m_UI_ControllerMouse = m_UI.FindAction("ControllerMouse", throwIfNotFound: true);
        m_UI_ControllerClick = m_UI.FindAction("ControllerClick", throwIfNotFound: true);
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_EnterBase = m_Base.FindAction("EnterBase", throwIfNotFound: true);
        // Map
        m_Map = asset.FindActionMap("Map", throwIfNotFound: true);
        m_Map_MapExit = m_Map.FindAction("MapExit", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Dig;
    private readonly InputAction m_Gameplay_Move;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Dig => m_Wrapper.m_Gameplay_Dig;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Dig.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDig;
                @Dig.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDig;
                @Dig.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDig;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dig.started += instance.OnDig;
                @Dig.performed += instance.OnDig;
                @Dig.canceled += instance.OnDig;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Dialog
    private readonly InputActionMap m_Dialog;
    private IDialogActions m_DialogActionsCallbackInterface;
    private readonly InputAction m_Dialog_ContinueDialog;
    private readonly InputAction m_Dialog_StartDialog;
    public struct DialogActions
    {
        private @PlayerControls m_Wrapper;
        public DialogActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ContinueDialog => m_Wrapper.m_Dialog_ContinueDialog;
        public InputAction @StartDialog => m_Wrapper.m_Dialog_StartDialog;
        public InputActionMap Get() { return m_Wrapper.m_Dialog; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogActions set) { return set.Get(); }
        public void SetCallbacks(IDialogActions instance)
        {
            if (m_Wrapper.m_DialogActionsCallbackInterface != null)
            {
                @ContinueDialog.started -= m_Wrapper.m_DialogActionsCallbackInterface.OnContinueDialog;
                @ContinueDialog.performed -= m_Wrapper.m_DialogActionsCallbackInterface.OnContinueDialog;
                @ContinueDialog.canceled -= m_Wrapper.m_DialogActionsCallbackInterface.OnContinueDialog;
                @StartDialog.started -= m_Wrapper.m_DialogActionsCallbackInterface.OnStartDialog;
                @StartDialog.performed -= m_Wrapper.m_DialogActionsCallbackInterface.OnStartDialog;
                @StartDialog.canceled -= m_Wrapper.m_DialogActionsCallbackInterface.OnStartDialog;
            }
            m_Wrapper.m_DialogActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ContinueDialog.started += instance.OnContinueDialog;
                @ContinueDialog.performed += instance.OnContinueDialog;
                @ContinueDialog.canceled += instance.OnContinueDialog;
                @StartDialog.started += instance.OnStartDialog;
                @StartDialog.performed += instance.OnStartDialog;
                @StartDialog.canceled += instance.OnStartDialog;
            }
        }
    }
    public DialogActions @Dialog => new DialogActions(this);

    // Shooting
    private readonly InputActionMap m_Shooting;
    private IShootingActions m_ShootingActionsCallbackInterface;
    private readonly InputAction m_Shooting_Shoot;
    private readonly InputAction m_Shooting_Aiming;
    private readonly InputAction m_Shooting_AimingMouse;
    private readonly InputAction m_Shooting_AimingController;
    public struct ShootingActions
    {
        private @PlayerControls m_Wrapper;
        public ShootingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Shooting_Shoot;
        public InputAction @Aiming => m_Wrapper.m_Shooting_Aiming;
        public InputAction @AimingMouse => m_Wrapper.m_Shooting_AimingMouse;
        public InputAction @AimingController => m_Wrapper.m_Shooting_AimingController;
        public InputActionMap Get() { return m_Wrapper.m_Shooting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
        public void SetCallbacks(IShootingActions instance)
        {
            if (m_Wrapper.m_ShootingActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Aiming.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAiming;
                @AimingMouse.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAimingMouse;
                @AimingMouse.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAimingMouse;
                @AimingMouse.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAimingMouse;
                @AimingController.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAimingController;
                @AimingController.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAimingController;
                @AimingController.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnAimingController;
            }
            m_Wrapper.m_ShootingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @AimingMouse.started += instance.OnAimingMouse;
                @AimingMouse.performed += instance.OnAimingMouse;
                @AimingMouse.canceled += instance.OnAimingMouse;
                @AimingController.started += instance.OnAimingController;
                @AimingController.performed += instance.OnAimingController;
                @AimingController.canceled += instance.OnAimingController;
            }
        }
    }
    public ShootingActions @Shooting => new ShootingActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    private readonly InputAction m_UI_ControllerMouse;
    private readonly InputAction m_UI_ControllerClick;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputAction @ControllerMouse => m_Wrapper.m_UI_ControllerMouse;
        public InputAction @ControllerClick => m_Wrapper.m_UI_ControllerClick;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @ControllerMouse.started -= m_Wrapper.m_UIActionsCallbackInterface.OnControllerMouse;
                @ControllerMouse.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnControllerMouse;
                @ControllerMouse.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnControllerMouse;
                @ControllerClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnControllerClick;
                @ControllerClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnControllerClick;
                @ControllerClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnControllerClick;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @ControllerMouse.started += instance.OnControllerMouse;
                @ControllerMouse.performed += instance.OnControllerMouse;
                @ControllerMouse.canceled += instance.OnControllerMouse;
                @ControllerClick.started += instance.OnControllerClick;
                @ControllerClick.performed += instance.OnControllerClick;
                @ControllerClick.canceled += instance.OnControllerClick;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Base
    private readonly InputActionMap m_Base;
    private IBaseActions m_BaseActionsCallbackInterface;
    private readonly InputAction m_Base_EnterBase;
    public struct BaseActions
    {
        private @PlayerControls m_Wrapper;
        public BaseActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @EnterBase => m_Wrapper.m_Base_EnterBase;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void SetCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterface != null)
            {
                @EnterBase.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnEnterBase;
                @EnterBase.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnEnterBase;
                @EnterBase.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnEnterBase;
            }
            m_Wrapper.m_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EnterBase.started += instance.OnEnterBase;
                @EnterBase.performed += instance.OnEnterBase;
                @EnterBase.canceled += instance.OnEnterBase;
            }
        }
    }
    public BaseActions @Base => new BaseActions(this);

    // Map
    private readonly InputActionMap m_Map;
    private IMapActions m_MapActionsCallbackInterface;
    private readonly InputAction m_Map_MapExit;
    public struct MapActions
    {
        private @PlayerControls m_Wrapper;
        public MapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MapExit => m_Wrapper.m_Map_MapExit;
        public InputActionMap Get() { return m_Wrapper.m_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActions set) { return set.Get(); }
        public void SetCallbacks(IMapActions instance)
        {
            if (m_Wrapper.m_MapActionsCallbackInterface != null)
            {
                @MapExit.started -= m_Wrapper.m_MapActionsCallbackInterface.OnMapExit;
                @MapExit.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnMapExit;
                @MapExit.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnMapExit;
            }
            m_Wrapper.m_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MapExit.started += instance.OnMapExit;
                @MapExit.performed += instance.OnMapExit;
                @MapExit.canceled += instance.OnMapExit;
            }
        }
    }
    public MapActions @Map => new MapActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnDig(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IDialogActions
    {
        void OnContinueDialog(InputAction.CallbackContext context);
        void OnStartDialog(InputAction.CallbackContext context);
    }
    public interface IShootingActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnAimingMouse(InputAction.CallbackContext context);
        void OnAimingController(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnControllerMouse(InputAction.CallbackContext context);
        void OnControllerClick(InputAction.CallbackContext context);
    }
    public interface IBaseActions
    {
        void OnEnterBase(InputAction.CallbackContext context);
    }
    public interface IMapActions
    {
        void OnMapExit(InputAction.CallbackContext context);
    }
}
