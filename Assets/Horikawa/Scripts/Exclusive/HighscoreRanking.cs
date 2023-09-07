using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using K_Librarys;

public class HighscoreRanking : MonoBehaviour
{
    // 表示テキスト
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    // 記録表示の書式
    private const string RECORD_TEXT_FORMAT = "{0}位 : {1}点\n";

    // 表示する記録の数
    public static readonly int RECORD_NUM = 3;

    // 記録のセーブキー
    public static readonly string RECORD_SAVE_KEY = "HighscoreRecordSave";

    // セーブデータ
    int[] saveData;

    private void Awake()
    {
        saveData = Preference.LoadArray(RECORD_SAVE_KEY, new int[RECORD_NUM]);

        string rankingText = string.Empty;

        for(int i = 0; i < RECORD_NUM; i++)
        {
            rankingText += string.Format(RECORD_TEXT_FORMAT, i + 1, saveData[i]);
        }

        textMeshPro.text = rankingText;
    }
}
