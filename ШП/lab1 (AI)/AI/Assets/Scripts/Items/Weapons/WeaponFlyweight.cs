using UnityEngine;

[CreateAssetMenu(menuName = "Game/Flyweights/Weapon", fileName = "Weapon_")]
public sealed class WeaponFlyweight : ScriptableObject
{
    [Header("Shared (intrinsic)")]
    public Mesh mesh;
    public Material baseMaterial;
    public Sprite icon;

    [Header("Stats")]
    public float fireRate;
    public int damage;
}
