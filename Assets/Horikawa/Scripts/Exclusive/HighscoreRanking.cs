using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using K_Librarys;

public class HighscoreRanking : MonoBehaviour
{
    // �\���e�L�X�g
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    // �L�^�\���̏���
    private const string RECORD_TEXT_FORMAT = "{0}�� - {1}�_\n";

    // �\������L�^�̐�
    private const int RECORD_NUM = 3;

    // �L�^�̃Z�[�u�L�[
    private const string RECORD_SAVE_KEY = "HighscoreRecordSave";

    // �Z�[�u�f�[�^
    int[] saveData;

    private void Start()
    {
        saveData = Preference.LoadArray(RECORD_SAVE_KEY, new int[RECORD_NUM]);

        string rankingText = string.Empty;

        for(int i = 0; i < RECORD_NUM; i++)
        {
            rankingText += string.Format(RECORD_TEXT_FORMAT, i + 1, saveData[i]);
        }

        textMeshPro.text = rankingText;

        //Preference.SaveArray(new int[RECORD_NUM] { 5071, 3072, 1872 }, RECORD_SAVE_KEY);
    }
}
