using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pauser : MonoBehaviour
{
    // �R���|�[�l���g
    private AudioSource audioSource;

    // �|�[�Y����
    public static bool IsPausing { get; private set; } = false;

    // �|�[�Y���ɕ\������p�l��
    [SerializeField]
    private GameObject pausePanel;

    // �|�[�YSE
    [SerializeField]
    private AudioClip pauseSE;

    // �|�[�Y�����R�}���h
    [SerializeField]
    private Command unpauseCommand;

    private void Start()
    {
        // �R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        // �C�x���g�Ɋ֐���ǉ�
        InputManager.Instance.pauseEvent.AddListener(Pause);
        unpauseCommand.onDecide.AddListener(Unpause);
    }

    /// <summary>
    /// �|�[�Y
    /// </summary>
    private void Pause()
    {
        IsPausing = true;

        Time.timeScale = 0f;
        pausePanel.SetActive(true);

        // SE�Đ�
        audioSource.PlayOneShot(pauseSE);
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
