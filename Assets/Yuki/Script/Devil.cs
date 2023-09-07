using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Devil : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト

    [SerializeField] private float time;//魂を食う間隔



    private float timeCount=0;//食う時間用変数
    private bool follFlag = false;//被弾フラグ



    private Spirit spirite;

    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();


        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Spirit");
        //関数を呼ぶ為にスクリプトも取得
        spirite = nearObj.GetComponent<Spirit>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;//時間を経過させる

        if (timeCount >= time)
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Spirit");
            //関数を呼ぶ為にスクリプトも取得
            spirite = nearObj.GetComponent<Spirit>();

            // 目的の位置の座標を指定
            Vector2 targetPosition = new Vector2(gameObject.transform.position.x, 
                                                 gameObject.transform.position.y ); 

            //魂側のスクリプトから移動させる
            spirite.DevilEat(targetPosition);
            //経過時間を初期化
            timeCount = 0;
        }

        if (follFlag)
        {
            rigidbody.gravityScale = 1;//重力をオンにして落下させる
            transform.localScale = new Vector3(1f, -1f, 1f);//仮落下演出
            spirite.DevilEatReset();
        }





    }

    //悪霊をぶつけられた時
    public void Damege()
    {
        follFlag = true;
        
    }







    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }

}
