using System.Collections.Generic;
using UnityEngine;

public sealed class WeaponPreviewPool : MonoBehaviour
{
    public static WeaponPreviewPool Instance { get; private set; }

    [Header("Camera")]
    [SerializeField]
    private int resolution = 256;

    [SerializeField] private int previewLayer = 8;

    [SerializeField] private Vector3 camOffset = new(0, 0, -3);

    private Camera _cam;
    private readonly Dictionary<WeaponFlyweight, RenderTexture> _cache = new();

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _cam = new GameObject("PreviewCamera").AddComponent<Camera>();
        _cam.transform.SetParent(transform, false);
        _cam.gameObject.layer = LayerMask.NameToLayer("Preview");
        _cam.clearFlags = CameraClearFlags.SolidColor;
        _cam.backgroundColor = Color.clear;
        _cam.cullingMask = 1 << previewLayer;
        _cam.enabled = false;
    }

    public RenderTexture GetPreview(WeaponFlyweight fw)
    {
        if (_cache.TryGetValue(fw, out var rt))
            return rt;

        rt = new RenderTexture(resolution, resolution, 16, RenderTextureFormat.ARGB32)
        {
            hideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor,
        };
        _cache[fw] = rt;

        var root = new GameObject("PreviewRoot")
        {
            layer = previewLayer
        };
        var filter = root.AddComponent<MeshFilter>();
        filter.sharedMesh = fw.mesh;
        var meshRenderer = root.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = fw.baseMaterial;

        var b = fw.mesh.bounds;
        _cam.transform.position = b.center + camOffset;
        _cam.transform.LookAt(b.center);

        var old = RenderTexture.active;
        _cam.targetTexture = rt;
        _cam.Render();
        _cam.targetTexture = null;
        RenderTexture.active = old;

        Destroy(root);
        return rt;
    }
}
