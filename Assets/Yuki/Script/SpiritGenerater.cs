using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritGenerater : MonoBehaviour
{
    private float timeCount=0;//生成用カウント


    //インスペクタに表示
    [Header("生成する魂")]
    [SerializeField][Tooltip("善の魂のプレハブを入れる")] GameObject Sprit;//善魂
    [SerializeField][Tooltip("悪の魂のプレハブを入れる")] GameObject EvileSprit;//悪魂

    [Header("時間")]
    [SerializeField][Tooltip("魂を生成する時間間隔")] float generateTime;

    [Header("確率")]
    [SerializeField][Range(1, 100)][Tooltip("善の魂を生成する確率")] private int ratio;//善の生成率を決定

    [Header("座標関係")]
    [SerializeField][Tooltip("生成する範囲")] float interval;//ジェネレータを中心とした左右の生成範囲
    [SerializeField][Tooltip("生成するy座標")] float y;//生成する高さ

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;//初期化
    }

    // Update is called once per frame
    void Update()
    {
        timeCount+=Time.deltaTime;//時間を加算

        //決められた時間置きに生成
        if (timeCount > generateTime)
        {
            Generate();//関数を呼んで生成
            Generate();//関数を呼んで生成
            Generate();//関数を呼んで生成

            timeCount = 0;//カウンターはリセット

        }


    }

    //魂を生成する関数
    public void Generate()
    {
        float rnd = Random.Range(-interval, interval);//位置にランダム性を持たせる
        

      
        Vector3 posi = new Vector3(rnd,y, 0.0f);//生成位置を決定

        //魂の生成
        int typeRnd = Random.Range(0, 100);//善悪どちらを生成するか決定

        //乱数が善の魂生成数値以下なら、善の魂を生成
        //数値を超えている場合は悪の魂を生成
        if (typeRnd <= ratio)
        {
            Instantiate(Sprit, posi, Quaternion.identity);
        }
        else {
            Instantiate(EvileSprit, posi, Quaternion.identity);
        }
    }
}
