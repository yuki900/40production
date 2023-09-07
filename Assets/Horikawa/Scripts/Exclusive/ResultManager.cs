using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using K_Librarys;

public class ResultManager : MonoBehaviour
{
    // スコア表示テキスト
    [SerializeField]
    private TextMeshProUGUI scoreTextMeshPro;

    // ハイスコアランキングUI
    [SerializeField]
    private GameObject highScoreRanking;

    private void Start()
    {
        int score = GameManager.Instance.score;
        // スコア表示
        scoreTextMeshPro.text = $"スコア : {score}点";

        // ランキング更新
        RankingUpdate(score);

        // ランキングを表示
        //highScoreRanking.SetActive(true);
    }

    // ランキング更新処理
    private void RankingUpdate(int _score)
    {
        int[] scoreRecords = Preference.LoadArray(HighscoreRanking.RECORD_SAVE_KEY,new int[HighscoreRanking.RECORD_NUM]);

        for(int rank = 0; rank < scoreRecords.Length; rank++)
        {
            // ランキング更新
            if(_score > scoreRecords[rank])
            {
                // 現在のスコア以下の記録を1つ下にずらす
                for (int i = scoreRecords.Length - 1; i > rank; i--)
                {
                    if(i > 0)
                    {
                        scoreRecords[i] = scoreRecords[i - 1];
                    }
                }

                // 現在のスコアを反映、保存して終了
                scoreRecords[rank] = _score;
                Preference.SaveArray(scoreRecords, HighscoreRanking.RECORD_SAVE_KEY);
                break;
            }
            else if(_score == scoreRecords[rank])
            {
                break;
            }
        }
    }
}
