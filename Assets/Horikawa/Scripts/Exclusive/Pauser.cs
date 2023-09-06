using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauser : MonoBehaviour
{
    // �|�[�Y����
    public static bool IsPausing { get; private set; } = false;

    // �|�[�Y���ɕ\������p�l��
    [SerializeField]
    private GameObject pausePanel;

    // �|�[�Y�����{�^��
    [SerializeField]
    private Button unpauseButton;

    private void Start()
    {
        // �C�x���g�Ɋ֐���ǉ�
        InputManager.Instance.pauseEvent.AddListener(Pause);
        unpauseButton.onClick.AddListener(Unpause);
    }

    /// <summary>
    /// �|�[�Y
    /// </summary>
    private void Pause()
    {
        IsPausing = true;

        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    /// <summary>
    /// �|�[�Y����
    /// </summary>
    private void Unpause()
    {
        IsPausing = false;

        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }
}
