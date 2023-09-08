using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pauser : MonoBehaviour
{
    // コンポーネント
    private AudioSource audioSource;

    // ポーズ中か
    public static bool IsPausing { get; private set; } = false;

    // ポーズ中に表示するパネル
    [SerializeField]
    private GameObject pausePanel;

    // ポーズSE
    [SerializeField]
    private AudioClip pauseSE;

    // ポーズ解除コマンド
    [SerializeField]
    private Command unpauseCommand;

    private void Start()
    {
        // コンポーネント取得
        audioSource = GetComponent<AudioSource>();

        // イベントに関数を追加
        InputManager.Instance.pauseEvent.AddListener(Pause);
        unpauseCommand.onDecide.AddListener(Unpause);
    }

    /// <summary>
    /// ポーズ
    /// </summary>
    private void Pause()
    {
        IsPausing = true;

        Time.timeScale = 0f;
        pausePanel.SetActive(true);

        // SE再生
        audioSource.PlayOneShot(pauseSE);
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
