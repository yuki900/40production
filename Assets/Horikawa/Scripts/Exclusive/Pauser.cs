using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauser : MonoBehaviour
{
    // ポーズ中か
    public static bool IsPausing { get; private set; } = false;

    // ポーズ中に表示するパネル
    [SerializeField]
    private GameObject pausePanel;

    // ポーズ解除ボタン
    [SerializeField]
    private Button unpauseButton;

    private void Start()
    {
        // イベントに関数を追加
        InputManager.Instance.pauseEvent.AddListener(Pause);
        unpauseButton.onClick.AddListener(Unpause);
    }

    /// <summary>
    /// ポーズ
    /// </summary>
    private void Pause()
    {
        IsPausing = true;

        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    /// <summary>
    /// ポーズ解除
    /// </summary>
    private void Unpause()
    {
        IsPausing = false;

        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }
}
