using System.Linq;
using UnityEngine;

/// <summary>
/// ステージを生成するジェネレータークラス。
/// </summary>
[RequireComponent(typeof(Stage))]
public class StageGenerator : MonoBehaviour
{
    /// <summary>
    /// ステージ生成元のデータ。
    /// </summary>
    [SerializeField]
    private StageSource _stageSource;

    /// <summary>
    /// ステージブロックのプレハブを格納する配列。
    /// </summary>
    [SerializeField]
    private StagePrefabs _prefabs;

    /// <summary>
    /// 生成するブロックのスケール（単位サイズ）。
    /// </summary>
    [SerializeField]
    private float _blockScale = 1f;

    /// <summary>
    /// ステージを生成する。
    /// </summary>
    public void GenerateMap()
    {
        if (_stageSource == null)
        {
            Debug.LogWarning("ステージソースが設定されていません。");
            return;
        }
        if (_prefabs == null)
        {
            Debug.LogWarning("ステージブロックのプレハブが設定されていません。");
            return;
        }

        var stage = GetComponent<Stage>();

        // 親となる空のGameObjectを作成し、マップアセット名を設定
        var mapContainer = new GameObject(_stageSource.StageName);
        mapContainer.transform.SetParent(stage.transform, false);

        var blocks = _stageSource.Blocks;
        for (var r = 0; r < blocks.Length; r++)
        {
            for (var c = 0; c < blocks[r].Length; c++)
            {
                var index = blocks[r][c];
                if (!_prefabs.TryGetBlockPrefab(index, out var prefab))
                {
                    throw new System.Exception($"プレハブが設定されていません: インデックス{index} (行{r+1}, 列{c+1})");
                }
                var block = Instantiate(prefab, mapContainer.transform);
                block.Row = r;
                block.Column = c;
                block.transform.localPosition = new Vector3(c * _blockScale, 0, -r * _blockScale);
                block.transform.localScale = Vector3.one * _blockScale;
                block.name = $"Block({r}, {c})";
            }
        }
        Debug.Log("マップ生成完了");
    }
}
