using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public sealed class WeaponInstance : MonoBehaviour
{
    [SerializeField]
    private WeaponInstanceData data;

    private MeshFilter _mf;
    private MeshRenderer _mr;
    private MaterialPropertyBlock _mpb;

    private void Awake()
    {
        _mf = GetComponent<MeshFilter>();
        _mr = GetComponent<MeshRenderer>();
        _mpb = new MaterialPropertyBlock();

        ApplyFlyweight();
        ApplyExtrinsic();
    }

    private void ApplyFlyweight()
    {
        var fw = WeaponFlyweightFactory.Get(data.flyweightId);
        if (!fw)
            return;

        _mf.sharedMesh = fw.mesh;
        _mr.sharedMaterial = fw.baseMaterial;
    }

    private void ApplyExtrinsic()
    {
        _mpb.SetColor($"_BaseColor", data.tint);
        _mpb.SetInt($"_DecalIndex", data.patternIndex);
        _mpb.SetInt($"_Serial", data.serial);
        _mr.SetPropertyBlock(_mpb);
    }

#if UNITY_EDITOR
    // Чтобы изменения в инспекторе тут же отражались
    private void OnValidate()
    {
        if (!Application.isPlaying || !_mr)
            return;
        ApplyExtrinsic();
        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif
}
