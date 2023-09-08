using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilGenerater : MonoBehaviour
{
    //インスペクタに表示するもの
    [Header("生成する悪魔")]
    [SerializeField][Tooltip("悪魔")] GameObject　Devil;

    [Header("生成確率")]
    [SerializeField][Range(1, 100)] private int generateProbability;

    [Header("生成時間間隔")]
    [SerializeField] private float time;


    [Header("生成数")]
    [SerializeField] private int generateMax;//生成最大数

    [Header("スコアマネージャー")]
    [SerializeField][Tooltip("スコアマネージャー")] ScoreManeger scoreManeger;//悪魂


    [HideInInspector] public bool existenceFlag=false;//すでに悪魔が居るかのフラグ


    private int generateCount = 0;//生成カウント
    private float timeCount = 0;

    private int rlRand;

   // Start is called before the first frame update
   void Start()
    {
        generateCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount+= Time.deltaTime;//時間を経過させる



        //悪魔を生成する最大数
        if (generateCount < generateMax)
        {
            //決められた時間置きかつ悪魔が居ないとき
            if (timeCount >= time)
            {

                //コンボ数が悪魔出現条件を満たしている時
                if (scoreManeger.combo >= scoreManeger.devilGenerate)
                {

                    
                        Generater();
                        
                    
                }
                timeCount = 0;
            }
           
        }
       
    }



    private void Generater() {

        //すでに悪魔が居ない時
        if (!existenceFlag)
        {
            float rnd = Random.Range(0, 100);//ランダム性を持たせる

            //決めた数字以下なら生成
            if (rnd <= generateProbability)
            {

                rlRand = Random.Range(0,2);//左右をランダムに決定
               

                //生成する位置
                Vector3 posi = new Vector3(0, 0, 0);
                //1なら右に生成
                if (rlRand == 1)
                {

                    posi = new Vector3(8, 0, 0.0f);//生成位置を決定

                }

                //0なら右に生成
                else if (rlRand != 1)
                {

                    posi = new Vector3(-8, 0, 0.0f);//生成位置を決定

                }
                //生成
                Instantiate(Devil, posi, Quaternion.identity);
                generateCount++;//カウントを増加
            }





        }

    }




}
