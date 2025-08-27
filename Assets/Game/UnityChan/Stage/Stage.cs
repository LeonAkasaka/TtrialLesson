using System.Linq;
using UnityEngine;

/// <summary>
/// ゲーム内のステージを管理するクラス。
/// ステージ内のブロックを2次元配列として管理し、行・列インデックスによるアクセスを提供する。
/// </summary>
public class Stage : MonoBehaviour
{
    /// <summary>
    /// ステージの行数を取得する。
    /// </summary>
    public int Rows => _blocks.GetLength(0);

    /// <summary>
    /// ステージの列数を取得する。
    /// </summary>
    public int Columns => _blocks.GetLength(1);

    /// <summary>
    /// ステージブロックを格納する2次元配列。
    /// </summary>
    private StageBlock[,] _blocks = new StageBlock[0,0];
    
    /// <summary>
    /// 指定された行・列位置のステージブロックにアクセスするインデクサー。
    /// </summary>
    /// <param name="row">行インデックス（0から開始）。</param>
    /// <param name="column">列インデックス（0から開始）。</param>
    /// <returns>指定位置のステージブロック。</returns>
    /// <exception cref="System.IndexOutOfRangeException">指定されたインデックスが範囲外の場合。</exception>
    public StageBlock this[int row, int column]
    {
        get
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new System.IndexOutOfRangeException($"Invalid index: ({row}, {column})");
            }
            return _blocks[row, column];
        }
        set
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new System.IndexOutOfRangeException($"Invalid index: ({row}, {column})");
            }
            _blocks[row, column] = value;
        }
    }

    /// <summary>
    /// ステージ初期化時に子オブジェクトからブロックテーブルを構築する。
    /// </summary>
    private void Start()
    {
        _blocks = GetBlockTable();
    }

    /// <summary>
    /// 子オブジェクトに含まれるステージブロックから2次元配列を構築する。
    /// 各ブロックのRow・Columnプロパティを基に適切な位置に配置する。
    /// </summary>
    /// <returns>構築されたステージブロックの2次元配列。</returns>
    private StageBlock[,] GetBlockTable()
    {
        var blocks = GetComponentsInChildren<StageBlock>();
        var (rows, columns) = blocks.Length > 0 ? (blocks.Max(b => b.Row), blocks.Max(b => b.Column)) : (0, 0);
        var table = new StageBlock[rows + 1, columns + 1];
        foreach (var block in blocks)
        {
            table[block.Row, block.Column] = block;
        }
        return table;
    }
}
