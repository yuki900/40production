using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using K_Librarys;

public class HighscoreRanking : MonoBehaviour
{
    // 表示テキストの配列
    [SerializeField]
    private TextMeshProUGUI[] texts = new TextMeshProUGUI[RECORD_NUM];

    // 記録表示の書式
    private const string RECORD_TEXT_FORMAT = "{0}位 : {1}点\n";

    // 表示する記録の数
    public static readonly int RECORD_NUM = 3;

    // 記録のセーブキー
    public static readonly string RECORD_SAVE_KEY = "HighscoreRecordSave";

    // 新記録の番号
    public int newRecordIndex = -1;

    // 点滅の間隔
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
