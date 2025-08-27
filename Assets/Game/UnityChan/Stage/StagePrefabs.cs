using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "StagePrefabs", menuName = "Scriptable Objects/StagePrefabs")]
public class StagePrefabs : ScriptableObject
{
    /// <summary>
    /// ステージブロックのプレハブを格納する配列。
    /// </summary>
    [SerializeField]
    private StageBlock[] _blockPrefabs;
    public StageBlock[] BlockPrefabs => _blockPrefabs;

    /// <summary>
    /// 指定されたブロックタイプのプレハブを取得する。
    /// </summary>
    /// <param name="blockType">取得するブロックタイプ。</param>
    /// <param name="prefab">取得されたプレハブ。見つからない場合はnull。</param>
    /// <returns>プレハブが見つかった場合はtrue、見つからない場合はfalse。</returns>
    public bool TryGetBlockPrefab(StageBlockType blockType, out StageBlock prefab)
    {
        EnsureDictionaryInitialized();
        return _blockDictionary.TryGetValue(blockType, out prefab);
    }

    /// <summary>
    /// ブロックタイプとプレハブの対応辞書。
    /// </summary>
    private Dictionary<StageBlockType, StageBlock> _blockDictionary;

    /// <summary>
    /// 辞書が初期化されていることを保証する。
    /// </summary>
    private void EnsureDictionaryInitialized()
    {
        if (_blockDictionary == null && _blockPrefabs != null)
        {
            _blockDictionary = _blockPrefabs
                .Where(x => x != null)
                .ToDictionary(x => x.BlockType, x => x);
        }
    }

    /// <summary>
    /// エディター上での検証時に辞書を初期化する。
    /// </summary>
    private void OnValidate()
    {
        _blockDictionary = null; // 次回アクセス時に再初期化されるようにnullに設定
    }
}
