using UnityEngine;

[DisallowMultipleComponent]
public sealed class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform camRoot;

    [SerializeField]
    private PlayerInputProxy input;

    [Header("Settings")]
    [Min(0.01f)]
    public float sensX = 0.1f;

    [Min(0.01f)]
    public float sensY = 0.1f;
    public float minPitch = -80f;
    public float maxPitch = 80f;
    public bool smoothed = true;

    [Range(1f, 30f)]
    public float smoothSpeed = 10f;

    private float _yaw;
    private float _pitch;

    private void LateUpdate()
    {
        if (!input || !camRoot)
            return;

        var look = input.State.look;

        _yaw += look.x * sensX;
        _pitch -= look.y * sensY;
        _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);

        if (smoothed)
        {
            var targetBody = Quaternion.Euler(0f, _yaw, 0f);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetBody,
                smoothSpeed * Time.deltaTime
            );

            var targetHead = Quaternion.Euler(_pitch, 0f, 0f);
            camRoot.localRotation = Quaternion.Slerp(
                camRoot.localRotation,
                targetHead,
                smoothSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, _yaw, 0f);
            camRoot.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
        }
    }
}
