using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    [HideInInspector] public int score = 0;//スコア
    [HideInInspector] public int life = 3;//ライフ
    [HideInInspector] public int combo = 0;//コンボ回数


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

    [Header("タイマー")]
    [SerializeField][Tooltip("最大時間(1分2分のような形式で入力)")] private float maxTime;
    private float time = 60;//実際に表示する用変数

    //表示調整用変数
    private float minTime;
    private float secondTime;




    [Header("表示するテキスト")]
    [SerializeField] private Text scoreText;//UI表示用
   // [SerializeField] private Text lifeText;//UI表示用
    [SerializeField] private Text comboText;//UI表示用
    [SerializeField] private Text timeText;//UI表示用

    [HideInInspector] public int magnification=1;//コンボ時の倍率用変数




    [Header("倍率")]
    [SerializeField] int[] times = new int[20];//具体的な倍率


    // Start is called before the first frame update
    void Start()
    {
        score = 0;//初期化
        life = 3;


        time = 60 * maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();//スコア表示部分
       // lifeText.text = life.ToString();//ミス表示部分
        comboText.text = combo.ToString();//コンボ表示部分

       


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



        //タイマー処理

        time-=Time.deltaTime;

        minTime = (int)((time % 3600) / 60);
        secondTime = (int)(time % 60);
        // 秒数一桁の時先頭に0追加(前田追加)
        if (secondTime < 10)
        {
            timeText.text = $"{minTime}:0{secondTime}";
        }
        else
        {
            timeText.text = $"{minTime}:{secondTime}";
        }






        Combo();
      

    }


    private void Combo()
    {

        //コンボ数に応じたスコア倍率の変化
        if (combo <= 15)
        {
            magnification = times[0];
        }
        else if (combo >= 16 && combo <= 20)
        {
            magnification = times[1];
        }
        else if (combo >= 21 && combo <= 25)
        {
            magnification = times[2];
        }
        else if (combo >= 26 && combo <= 30)
        {
            magnification = times[3];
        }
        else if (combo >= 31 && combo <= 35)
        {
            magnification = times[4];
        }
        else if (combo >= 36 && combo <= 40)
        {
            magnification = times[5];
        }
        else if (combo >= 41 && combo <= 45)
        {
            magnification = times[6];
        }
        else if (combo >= 46 && combo <= 50)
        {
            magnification = times[7];
        }
        else if (combo >= 51 && combo <= 55)
        {
            magnification = times[8];
        }
        else if (combo >= 56 && combo <= 60)
        {
            magnification = times[9];
        }
        else if (combo >= 60 && combo <= 65)
        {
            magnification = times[10];
        }
        else if (combo >= 66 && combo <= 70)
        {
            magnification = times[11];
        }
        else if (combo >= 71 && combo <= 75)
        {
            magnification = times[12];
        }
        else if (combo >= 75 && combo <= 80)
        {
            magnification = times[13];
        }
        else if (combo >= 81 && combo <= 85)
        {
            magnification = times[14];
        }
        else if (combo >= 86 && combo <= 90)
        {
            magnification = times[15];
        }
        else if (combo >= 91 && combo <= 95)
        {
            magnification = times[16];
        }
        else if (combo >= 96 && combo <= 100)
        {
            magnification = times[17];
        }
        else if (combo >= 101)
        {
            magnification = times[18];
        }


    }

}
