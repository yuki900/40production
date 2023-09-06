using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    private float speed;//実際に使う速度

    private bool eriaFlag = false;//吹っ飛ばし範囲に居るかフラグ
    private bool lightFlag = false;//光範囲に居るかフラグ


    //悪魔関係
    private bool eatStart = false;//悪魔に食われる開始
    private Vector2 devilPosition;//悪魔の座標


    // private bool atackFlag = false;//攻撃フラグ


    //インスペクタ表示変数
    [SerializeField][Tooltip("上昇速度")] private float moveSpeed;//速度
    [SerializeField][Tooltip("吹っ飛ばす力(強)")] private float power;//吹っ飛ばす力(強)
    [SerializeField][Tooltip("吹っ飛ばす力(弱)")] private float miniPower;//吹っ飛ばす力(弱)
    [SerializeField][Tooltip("オンにすると悪霊")] private bool evile = false;//悪人か善人か


    private Angel angel;
    public Devil devil;

    private ScoreManeger scoreManeger;



    new Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        speed = moveSpeed;//アドフォース用に速度変数を代入

        rigidbody = GetComponent<Rigidbody2D>();


        if (angel == null)
        {

            GameObject saveObject = GameObject.FindGameObjectWithTag("Player");
            angel = saveObject.GetComponent<Angel>();


        }
        if (scoreManeger == null)
        {

            GameObject saveObject = GameObject.FindGameObjectWithTag("ScoreManeger");
            scoreManeger = saveObject.GetComponent<ScoreManeger>();


        }
       
    }

    // Update is called once per frame
    void Update()
    {
        //光の範囲に居る時のみ上に上る
        //範囲外に行った場合は落ちる
        if (lightFlag)
        {
            rigidbody.gravityScale = 0;
            rigidbody.AddForce(Vector2.up * speed);//常時上に移動
           // rigidbody.velocity = new Vector2(0, speed);
        }
        else rigidbody.gravityScale = 1;


        //悪魔に引き寄せられる
        if (eatStart)
        {


            float speed = 0.5f; // 移動の速度を指定
            Transform objectTransform = gameObject.GetComponent<Transform>(); // ゲームオブジェクトのTransformコンポーネントを取得
            objectTransform.position = Vector3.Lerp(objectTransform.position, devilPosition, speed * Time.deltaTime); // 目的の位置に移動
        }




        //弱い仮
        if (Input.GetKeyDown("z") && eriaFlag)
        {

            rigidbody.gravityScale = 0;

            if (angel.rightFlag)
            {
                rigidbody.AddForce(Vector2.right * miniPower, ForceMode2D.Force);


            }


            if (angel.leftFlag)
            {
                rigidbody.AddForce(Vector2.left * miniPower, ForceMode2D.Force);

            }
            eriaFlag = false;

        }

        //強い仮
        if (Input.GetKeyDown("x") && eriaFlag)
        {
            //rigidbody. = false;
            // blowAwayFlag = true;
            //rigidbody.AddForce(Vector2.down * power, ForceMode2D.Impulse);
            rigidbody.gravityScale = 1;
            speed = 0;

            if (angel.rightFlag)
            {
                rigidbody.AddForce(Vector2.right * power, ForceMode2D.Force);


            }


            if (angel.leftFlag)
            {
                rigidbody.AddForce(Vector2.left * power, ForceMode2D.Force);

            }
            eriaFlag = false;

        }




    }

    private void FixedUpdate()
    {
        eriaFlag = false;
        lightFlag = false;
    }


    //悪魔に引き寄せられる時の関数
    public void DevilEat(Vector2 targetPosition)
    {

        eatStart = true;//食われる動作開始フラグ
        devilPosition = targetPosition;
   

    }








    private void OnTriggerStay2D(Collider2D collider)
    {
        //プレイヤーの範囲に入ると攻撃可能フラグをオン
        if (collider.tag == "Player")
        {

            eriaFlag = true;
        }
        //光の範囲に居ると、上昇フラグをオン
        if (collider.tag == "GodLight")
        {
            lightFlag = true;

        }
        //スコア範囲に入ったらスコアを加算し、自身を削除
        if (collider.tag == "ScoreEria")
        {
            //善人の時
            if (!evile)
            {

                scoreManeger.score += 100;//スコアを加算
            }
            //悪人の時
            if (evile)
            {

                scoreManeger.score -= 1000;//スコアを減少
            }
            Destroy(gameObject);

        }

       
    }





    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        //悪霊が悪魔にぶつかった時
        if (collider.tag == "Devil" && evile)
        {
            if (devil == null)
            {
                devil = collider.gameObject.GetComponent<Devil>();//悪魔のスクリプト
            }
            if (devil != null)
            {
                scoreManeger.score += 2000;//スコアを加算
                devil.Damege();//落下関数を呼び出し
            }
        }
        //善の魂が悪霊に食われる時
        if (collider.tag == "Devil" && !evile)
        {
            scoreManeger.life--;//ダメージを受ける
            Destroy(gameObject);//消滅させる

        }

    } 





}
