using UnityEngine;

/// <summary>
/// ステージブロックの種類。
/// </summary>
public enum StageBlockType
{
    /// <summary>
    /// なし。
    /// </summary>
    None = 0,

    /// <summary>
    /// 地面。
    /// </summary>
    Ground = 1,

    /// <summary>
    /// 道。
    /// </summary>
    Road = 2,

    /// <summary>
    /// 開始地点。
    /// </summary>
    Start = 3,

    /// <summary>
    /// 目的地。
    /// </summary>
    Goal = 4,
}

public class StageBlock : MonoBehaviour
{
    /// <summary>
    /// ステージブロックの種類。
    /// </summary>
    public StageBlockType BlockType => _blockType;
    [SerializeField]
    private StageBlockType _blockType = StageBlockType.None;

    /// <summary>
    /// 行番号。
    /// </summary>
    public int Row { get; set; }

    /// <summary>
    /// 列番号。
    /// </summary>
    public int Column { get; set; }
}
