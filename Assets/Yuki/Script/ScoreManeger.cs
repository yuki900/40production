using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    [HideInInspector] public float score = 0;//スコア
    [HideInInspector] public float miss = 0;//ミス回数
    [HideInInspector] public float combo = 0;//コンボ回数


    //スコア上昇量
    [Header("スコア関係の設定項目")]
    [SerializeField][Tooltip("上がるスコア")] public int scoreUp;
    [SerializeField][Tooltip("下がるスコア")] public int scoreDown;
    [SerializeField][Tooltip("悪魔で上がるスコア")] public int scoreUpDevil;


    [Header("光")]
    [SerializeField][Tooltip("小さい")] private GameObject light_small;
    [SerializeField][Tooltip("普通")] private GameObject light_regular;
    [SerializeField][Tooltip("大きい")] private GameObject light_large;

    [Header("悪魔が出るコンボ数")]
    [SerializeField] public int devilGenerate;


    [Header("コンボに応じた光の切り替え")]
    [SerializeField][Tooltip("普通になるコンボ数")] private int comboRegular;
    [SerializeField][Tooltip("最大になるコンボ数")] private int comboLarge;

    [Header("表示するテキスト")]
    [SerializeField] private Text scoreText;//UI表示用
    [SerializeField] private Text missText;//UI表示用
    [SerializeField] private Text comboText;//UI表示用

    // Start is called before the first frame update
    void Start()
    {
        score = 0;//初期化
        miss = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();//スコア表示部分
        missText.text = miss.ToString();//スコア表示部分
        comboText.text = combo.ToString();//スコア表示部分

       


        //最小サイズの表示
        if(combo< comboRegular)
        {
            light_small.SetActive(true);//小
            light_regular.SetActive(false);//普
            light_large.SetActive(false);//大


        }
        //普通サイズの表示
        else if(combo >= comboRegular&& combo< comboLarge)
        {
            light_small.SetActive(false);//小
            light_regular.SetActive(true);//普
            light_large.SetActive(false);//大
        }
        //最大サイズの表示
        else if (combo >= comboLarge)
        {
            light_small.SetActive(false);//小
            light_regular.SetActive(false);//普
            light_large.SetActive(true);//大
        }







    }
}
