using UnityEngine;

/// <summary>
/// テキストアセットからステージを生成するためのステージ生成元クラス。
/// </summary>
public class TextAssetStageSource : StageSource
{
    /// <summary>
    /// ステージ生成元のテキストアセット。
    /// </summary>
    [SerializeField]
    private TextAsset _mapText;

    /// <summary>
    /// ステージ名。
    /// </summary>
    public override string StageName => _mapText ? _mapText.name : "StageBlocks";

    /// <inheritdoc />
    public override StageBlockType[][] Blocks => _mapText ? ParseMapText(_mapText.text) : new StageBlockType[][] { } ;
}
