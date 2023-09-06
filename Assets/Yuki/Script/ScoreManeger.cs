using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    public float score = 0;//スコア
    public float life = 3;//ライフ
    [SerializeField] private Text scoreText;//UI表示用

    // Start is called before the first frame update
    void Start()
    {
        score = 0;//初期化
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();//スコア表示部分

        //マイナスの時は0に
        if (score < 0) { 
            score = 0; }

    }
}
