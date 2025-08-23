using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Water : MonoBehaviour
{
    [Header("Main Texture Wave Settings")]
    [SerializeField] private float _waveSpeedX = 0;
    [SerializeField] private float _waveSpeedY = 0;
    [SerializeField] private float _waveScaleX = 0;
    [SerializeField] private float _waveScaleY = 0;

    [Header("Normal Map Wave Settings")]
    [SerializeField] private float _normalWaveSpeedX = 0;
    [SerializeField] private float _normalWaveSpeedY = 0;
    [SerializeField] private float _normalWaveScaleX = 0;
    [SerializeField] private float _normalWaveScaleY = 0;

    [Header("Tiling Settings")]
    [SerializeField] private float _tilingSpeed = 0;
    [SerializeField] private float _tilingScale = 0;

    private MeshRenderer _meshRenderer;
    private Material _material;
    private Vector2 _baseOffset;
    private Vector2 _baseNormalOffset;
    private Vector2 _baseTiling;

    private readonly string _normalMapProperty = "_DetailAlbedoMap";

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _material = _meshRenderer.material;
        _baseOffset = _material.mainTextureOffset;
        _baseTiling = _material.mainTextureScale;
    }

    void Update()
    {
        if (_material != null)
        {
            // メインテクスチャのオフセットアニメーション
            float offsetX = _baseOffset.x + Mathf.Sin(Time.time * _waveSpeedX) * _waveScaleX;
            float offsetY = _baseOffset.y + Mathf.Sin(Time.time * _waveSpeedY) * _waveScaleY;
            _material.mainTextureOffset = new Vector2(offsetX, offsetY);

            // Normal mapのオフセットアニメーション（異なる動き）
            if (!string.IsNullOrEmpty(_normalMapProperty))
            {
                float normalOffsetX = _baseNormalOffset.x + Mathf.Cos(Time.time * _normalWaveSpeedX) * _normalWaveScaleX;
                float normalOffsetY = _baseNormalOffset.y + Mathf.Sin(Time.time * _normalWaveSpeedY * 1.5f) * _normalWaveScaleY;
                _material.SetTextureOffset(_normalMapProperty, new Vector2(normalOffsetX, normalOffsetY));
            }

            // Tilingのアニメーション
            float tilingX = _baseTiling.x + Mathf.Sin(Time.time * _tilingSpeed) * _tilingScale;
            float tilingY = _baseTiling.y + Mathf.Cos(Time.time * _tilingSpeed) * _tilingScale;
            _material.mainTextureScale = new Vector2(tilingX, tilingY);
        }
    }
}
