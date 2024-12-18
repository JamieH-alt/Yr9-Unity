using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;

public class InputManager : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 Movement;
    public static bool JumpWasPressed;
    public static bool JumpIsHeld;
    public static bool JumpWasReleased;
    public static bool RunIsHeld;
    public static bool DashWasPressed;
    public static bool TestWasPressed;

    public static int Device;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _runAction;
    private InputAction _dashAction;
    private InputAction _testAction;
    private InputAction _optionsAction;
    private InputAction _resetAction;

    private DeviceType activeDevice = DeviceType.Desktop;
    
    [SerializeField] private GameObject settingsUi;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _jumpAction = PlayerInput.actions["Jump"];
        _runAction = PlayerInput.actions["Run"];
        _dashAction = PlayerInput.actions["Dash"];

        _optionsAction = PlayerInput.actions["Options"];
        _resetAction = PlayerInput.actions["Reset"];

        _testAction = PlayerInput.actions["Test"];
    }

    private void Update()
    {
        
        if (_resetAction.WasPressedThisFrame())
        {
            NextLevel.instance.LoadSameScene();
        }

        if (_optionsAction.WasPressedThisFrame() && settingsUi != null)
        {
            if (settingsUi.activeSelf == false)
            {
                OpenSettings.instance.OpenSettingsMenu();
            }
            else
            {
                OpenSettings.instance.CloseSettingsMenu();
            }
        }

        Movement = _moveAction.ReadValue<Vector2>();

        JumpWasPressed = _jumpAction.WasPressedThisFrame();
        JumpIsHeld = _jumpAction.IsPressed();
        JumpWasReleased = _jumpAction.WasReleasedThisFrame();

        RunIsHeld = _runAction.IsPressed();


        DashWasPressed = _dashAction.WasPressedThisFrame();

        TestWasPressed = _testAction.WasPressedThisFrame();

        if (PlayerInput.currentControlScheme == "Keyboard&Mouse")
        {
            Device = 0;
        } else if (PlayerInput.currentControlScheme == "Gamepad")
        {
            if (DualShockGamepad.current != null)
            {
                Device = 1;
            }
            else
            {
                Device = 2;
            }
        }
    }
}
