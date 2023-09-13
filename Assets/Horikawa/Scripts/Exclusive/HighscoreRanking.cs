using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using K_Librarys;

public class HighscoreRanking : MonoBehaviour
{
    // �\���e�L�X�g�̔z��
    [SerializeField]
    private TextMeshProUGUI[] texts = new TextMeshProUGUI[RECORD_NUM];

    // �L�^�\���̏���
    private const string RECORD_TEXT_FORMAT = "{0}�� : {1}�_\n";

    // �\������L�^�̐�
    public static readonly int RECORD_NUM = 3;

    // �L�^�̃Z�[�u�L�[
    public static readonly string RECORD_SAVE_KEY = "HighscoreRecordSave";

    // �V�L�^�̔ԍ�
    public int newRecordIndex = -1;

    // �_�ł̊Ԋu
    private const float BLINK_INTERVAL = 0.5f;

    private void Awake()
    {
        int[] saveData = Preference.LoadArray(RECORD_SAVE_KEY, new int[RECORD_NUM]);

        for(int i = 0; i < RECORD_NUM; i++)
        {
            texts[i].SetText(RECORD_TEXT_FORMAT, i + 1, saveData[i]);
        }
    }

    private void Start()
    {
        if(newRecordIndex != -1)
        {
            StartCoroutine(Blink(newRecordIndex));
        }
    }

    private IEnumerator Blink(int _index)
    {
        while (true)
        {
            yield return new WaitForSeconds(BLINK_INTERVAL);
            texts[_index].enabled = !texts[_index].enabled;
            Debug.Log(texts[_index].enabled);
        }
    }
}
