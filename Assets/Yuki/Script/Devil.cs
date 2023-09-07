using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Devil : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト


    //インスペクタに表示
    [Header("移動速度")]
    [SerializeField]float moveSpeed;//速度
    [Header("魂を食う間隔")]
    [SerializeField] private float time;//魂を食う間隔



    private float timeCount=0;//食う時間用変数
    private bool follFlag = false;//被弾フラグ


    private bool moveFlag = false;//移動フラグ




    DevilGenerater devilGenerater;
    private Spirit spirite;

    new Rigidbody2D rigidbody;

    Animator animator;

    void Start()
    {


        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        //ジェネレータを取得
        if (devilGenerater == null)
        {

            GameObject saveObject = GameObject.FindGameObjectWithTag("DevilGenerater");
            devilGenerater = saveObject.GetComponent<DevilGenerater>();


        }




        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Spirit");
        if (nearObj != null)
        {
            
            //関数を呼ぶ為にスクリプトも取得
            spirite = nearObj.GetComponent<Spirit>();
        }
        animator.SetBool("Ded", false);//落下演出




        devilGenerater.existenceFlag = true;//悪魔がすでに生成されているフラグを与える
        moveFlag = true;//移動開始
    }

    // Update is called once per frame
    void Update()
    {
       

        if (moveFlag)
        {

            Vector2 goalPosition = new Vector2(0, 0);//魂が向かう位置を設定

            //生成位置が右の時は右の位置に移動
            if (gameObject.transform.position.x >= 0)
            {
                goalPosition = new Vector2(4, 0);//魂が向かう位置を設定

            }
            //生成位置が左の時は左の位置に移動
            if (gameObject.transform.position.x < 0)
            {
                goalPosition = new Vector2(-4, 0);//魂が向かう位置を設定

            }

            Transform objectTransform = gameObject.GetComponent<Transform>(); // ゲームオブジェクトのTransformコンポーネントを取得
            objectTransform.position = Vector3.Lerp(objectTransform.position, goalPosition, moveSpeed * Time.deltaTime); // 目的の位置に移動

        }





        timeCount += Time.deltaTime;//時間を経過させる
      
        if (timeCount >= time)
        {
            animator.SetBool("Eat", false);//アニメ変更処理
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Spirit");
            
            if (nearObj != null)
            {
                
                //関数を呼ぶ為にスクリプトも取得
                spirite = nearObj.GetComponent<Spirit>();

            
                // 目的の位置の座標を指定
                Vector2 targetPosition = new Vector2(gameObject.transform.position.x,
                                                     gameObject.transform.position.y);

                //魂側のスクリプトから移動させる
                spirite.DevilEat(targetPosition);
                //経過時間を初期化
                timeCount = 0;
            }
        }

        if (follFlag)
        {
            rigidbody.gravityScale = 1;//重力をオンにして落下させる
            animator.SetBool("Ded", true);//落下演出
            spirite.DevilEatReset();
        }





    }

    //悪霊をぶつけられた時
    public void Damege()
    {
      
        devilGenerater.existenceFlag = false;//また悪魔を呼べるように
        follFlag = true;
        
    }

    //悪霊をぶつけられた時
    public void Eaten()
    {
      
        //アニメを変更して即戻す
        animator.SetBool("Eat", true);//アニメ変更処理
       
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
