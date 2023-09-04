using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    // コンポーネント
    private Button button;

    protected virtual void Start()
    {
        // コンポーネント取得
        button = GetComponent<Button>();

        // イベントに関数を追加
        button.onClick.AddListener(OnClick);
    }

    /// <summary>
    /// ボタンクリック時に呼び出される関数
    /// </summary>
    protected abstract void OnClick();
}
