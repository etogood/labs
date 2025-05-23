using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[DisallowMultipleComponent]
public sealed class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private PlayerSettings settings;

    [SerializeField]
    private PlayerInputProxy inputProxy;

    private CharacterController _cc;
    private Vector3 _velocity;

    private void Awake() => _cc = GetComponent<CharacterController>();

    private void FixedUpdate()
    {
        if (!settings || !inputProxy)
        {
            return;
        }

        var i = inputProxy.State;
        
        var speed = i.sprint ? settings.sprintSpeed : settings.walkSpeed;
        var moveDir = new Vector3(i.move.x, 0, i.move.y);
        var world = transform.TransformDirection(moveDir);
        _cc.Move(world * (speed * Time.fixedDeltaTime));
        
        if (_cc.isGrounded)
        {
            _velocity.y = -settings.groundedSkin;
            if (i.jumpPressed)
            {
                _velocity.y = Mathf.Sqrt(settings.jumpHeight * -2f * settings.gravity);
            }
        }
        else
        {
            _velocity.y += settings.gravity * Time.fixedDeltaTime;
        }

        _cc.Move(_velocity * Time.fixedDeltaTime);
    }
}
