using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class PlayerInputProxy : MonoBehaviour, PlayerInputActions.IPlayerActions
{
    private bool _jumpQueued;

    [System.Serializable]
    public struct InputState
    {
        public Vector2 move;
        public Vector2 look;
        public bool sprint;
        public bool jumpPressed;
    }

    private InputState _state;
    public InputState State => _state;

    private PlayerInputActions _actions;

    private void OnEnable()
    {
        _actions = new PlayerInputActions();
        _actions.Player.SetCallbacks(this);
        _actions.Enable();
    }

    public bool ConsumeJump()
    {
        if (!_jumpQueued)
            return false;
        _jumpQueued = false;
        return true;
    }

    private void OnDisable() => _actions.Disable();

    public void OnMove(InputAction.CallbackContext context) =>
        _state.move = context.ReadValue<Vector2>();

    public void OnSprint(InputAction.CallbackContext context) =>
        _state.sprint = context.ReadValueAsButton();

    public void OnJump(InputAction.CallbackContext context) =>
        _state.jumpPressed = context.ReadValueAsButton();

    public void OnLook(InputAction.CallbackContext context) =>
        _state.look = context.ReadValue<Vector2>();
}
