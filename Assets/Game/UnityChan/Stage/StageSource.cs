using UnityEngine;

/// <summary>
/// ステージ生成データ。
/// </summary>
public abstract class StageSource : MonoBehaviour
{
    /// <summary>
    /// ステージ名。
    /// </summary>
    public abstract string StageName { get; }

    /// <summary>
    /// 生成するステージのブロック情報を取得する。
    /// </summary>
    public abstract StageBlockType[][] Blocks { get; }

    /// <summary>
    /// テキストをインデックスのジャグ配列にパースする。
    /// </summary>
    /// <param name="text">パース対象のテキスト。</param>
    /// <returns>パースされた <see cref="StageBlockType"/> のジャグ配列。</returns>
    protected static StageBlockType[][] ParseMapText(string text)
    {
        // クロスプラットフォーム対応：Windows（CRLF）、Unix/Mac（LF）、Classic Mac（CR）の改行コードに対応
        var lines = text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        var result = new StageBlockType[lines.Length][];
        for (var r = 0; r < lines.Length; r++)
        {
            var cols = lines[r].Split(',');
            result[r] = new StageBlockType[cols.Length];
            for (var c = 0; c < cols.Length; c++)
            {
                var col = cols[c].Trim();
                if (string.IsNullOrEmpty(col))
                {
                    throw new System.ArgumentException($"空文字列: (行{r + 1}, 列{c + 1})", nameof(text));
                }

                if (!int.TryParse(col, out var index))
                {
                    throw new System.ArgumentException($"不正な文字列: '{col}' (行{r + 1}, 列{c + 1})", nameof(text));
                }
                result[r][c] = (StageBlockType)index;
            }
        }
        return result;
    }
}
