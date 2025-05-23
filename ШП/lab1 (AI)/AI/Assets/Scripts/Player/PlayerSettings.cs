using UnityEngine;

[CreateAssetMenu(menuName = "Game/Player Settings", fileName = "PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Header("Movement")]
    [Min(0.1f)] public float walkSpeed = 4f;
    [Min(0.1f)] public float sprintSpeed = 7f;
    [Header("Jump")]
    [Min(0.1f)] public float jumpHeight = 1.6f;
    [Header("Physics")]
    public float gravity = -25f;
    public float groundedSkin = 0.2f;
}