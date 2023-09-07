using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using K_Librarys;

public class ResultManager : MonoBehaviour
{
    // �X�R�A�\���e�L�X�g
    [SerializeField]
    private TextMeshProUGUI scoreTextMeshPro;

    // �n�C�X�R�A�����L���OUI
    [SerializeField]
    private GameObject highScoreRanking;

    private void Start()
    {
        int score = GameManager.Instance.score;
        // �X�R�A�\��
        scoreTextMeshPro.text = $"�X�R�A : {score}�_";

        // �����L���O�X�V
        RankingUpdate(score);

        // �����L���O��\��
        //highScoreRanking.SetActive(true);
    }

    // �����L���O�X�V����
    private void RankingUpdate(int _score)
    {
        int[] scoreRecords = Preference.LoadArray(HighscoreRanking.RECORD_SAVE_KEY,new int[HighscoreRanking.RECORD_NUM]);

        for(int rank = 0; rank < scoreRecords.Length; rank++)
        {
            // �����L���O�X�V
            if(_score > scoreRecords[rank])
            {
                // ���݂̃X�R�A�ȉ��̋L�^��1���ɂ��炷
                for (int i = scoreRecords.Length - 1; i > rank; i--)
                {
                    if(i > 0)
                    {
                        scoreRecords[i] = scoreRecords[i - 1];
                    }
                }

                // ���݂̃X�R�A�𔽉f�A�ۑ����ďI��
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
