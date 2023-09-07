using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    private float speed;//実際に使う速度

    private bool eriaFlag = false;//吹っ飛ばし範囲に居るかフラグ
    private bool lightFlag = false;//光範囲に居るかフラグ
    private Vector2 goalPosition;//光の座標


    private int yPosition = 16;//移動位置指定用変数

    private bool destroy = false;//削除用フラグ

    //悪魔関係
    private  bool eatStart = false;//悪魔に食われる開始
    private Vector2 devilPosition;//悪魔の座標

    //スコア
    private int scoreUp;
    private int scoreDown;
    private int scoreUpDevil;


    float scale = 1;//消滅時のスケール

    //インスペクタ表示変数
    [Header("吹っ飛ばす力関係の設定項目")]
    [SerializeField][Tooltip("吹っ飛ばす力(弱)")] private float miniPower;//吹っ飛ばす力(弱)
    [SerializeField][Tooltip("吹っ飛ばす力(弱)")] private float power;//吹っ飛ばす力(強)
    [SerializeField][Tooltip("オンにすると悪霊")] private bool evil = false;//悪人か善人か

    [Header("速度")]
    [SerializeField][Tooltip("最小速度")] private float minSpeed;
    [SerializeField][Tooltip("最大速度")] private float maxSpeed;


    private Angel angel;
    private Devil devil;

    private ScoreManeger scoreManeger;



    new Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {

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

        float rnd = Random.Range(minSpeed, maxSpeed);//速度を最小最大の範囲からランダムに決定
        speed = rnd;//実際の速度を代入
        goalPosition = new Vector2(gameObject.transform.position.x, yPosition);//魂が向かう位置を設定



        //スコアマネージャーからスコア関係の数値を取得
        scoreUp= scoreManeger.scoreUp;
        scoreDown = scoreManeger.scoreDown;
        scoreUpDevil = scoreManeger.scoreUpDevil;


        // イベントに関数を追加
        InputManager.Instance.weakAttackEvent.AddListener(WeakAttackEvent);
        InputManager.Instance.strongAttackEvent.AddListener(StrongAttackEvent);
    }

    // Update is called once per frame
    void Update()
    {
        //光の範囲に居る時のみ上に上る
        //範囲外に行った場合は落ちる
        if (lightFlag && !eatStart)
        {
            rigidbody.gravityScale = 0;//上るために重さなくす

            goalPosition = new Vector2(0, yPosition);//魂が向かう位置を設定
            Transform objectTransform = gameObject.GetComponent<Transform>(); // ゲームオブジェクトのTransformコンポーネントを取得
            objectTransform.position = Vector3.Lerp(objectTransform.position, goalPosition, speed * Time.deltaTime); // 目的の位置に移動


        }
        else if (!lightFlag && !eatStart)
        {
            rigidbody.gravityScale = 1;//重さを操作して落とす
          
        }

        //悪魔に引き寄せられる
        if (eatStart)
        {


            Transform objectTransform = gameObject.GetComponent<Transform>(); // ゲームオブジェクトのTransformコンポーネントを取得
            objectTransform.position = Vector3.Lerp(objectTransform.position, devilPosition, speed*10 * Time.deltaTime); // 目的の位置に移動
        }


        

       

    }

    private void FixedUpdate()
    {
        eriaFlag = false;
        lightFlag = false;
    }

    //弱攻撃
    private void WeakAttackEvent()
    {//はじく動作系
        //悪魔のひきよせ中は出来ない

        //弱い
        if (eriaFlag && !eatStart)
        {
            destroy = true;//消去用フラグ
            rigidbody.gravityScale = 0;

            //向いてる方向に応じてはじかれる方向を変更
            //右
            if (angel.rightFlag)
            {

                rigidbody.AddForce(Vector2.right * miniPower, ForceMode2D.Force);


            }

            //左
            if (angel.leftFlag)
            {
                rigidbody.AddForce(Vector2.left * miniPower, ForceMode2D.Force);

            }
            //上
            if (angel.upFlag)
            {
                rigidbody.AddForce(Vector2.up * miniPower, ForceMode2D.Force);
            }
            //下
            if (angel.downFlag)
            {
                rigidbody.AddForce(Vector2.down * miniPower, ForceMode2D.Force);
            }
            eriaFlag = false;

        }


    }

    //強攻撃処理
     private void StrongAttackEvent()
    {

        //強い仮
        if (eriaFlag && !eatStart)
        {
            destroy = true;//消去用フラグ
            rigidbody.gravityScale = 1;//落下用に重力を操作
            speed = 0;


            //コライダーのサイズを変更
            CircleCollider2D collider = GetComponent<CircleCollider2D>();
            collider.radius = 0.3f;
            //向いてる方向に応じてはじかれる方向を変更
            //右
            if (angel.rightFlag)
            {
                rigidbody.AddForce(Vector2.right * power, ForceMode2D.Force);


            }

            //左
            if (angel.leftFlag)
            {
                rigidbody.AddForce(Vector2.left * power, ForceMode2D.Force);

            }
            //上
            if (angel.upFlag)
            {
                rigidbody.AddForce(Vector2.up * power, ForceMode2D.Force);

            }
            //下
            if (angel.downFlag)
            {
                rigidbody.AddForce(Vector2.down * power, ForceMode2D.Force);

            }
            eriaFlag = false;

        }




    }









    //悪魔に引き寄せられる時の関数
    public void DevilEat(Vector2 targetPosition)
    {

        eatStart = true;//食われる
        devilPosition = targetPosition;
   

    }
    //悪魔が倒された時の関数
    public void DevilEatReset()
    {

        eatStart = false;//食われる動作終了


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
            //サイズの変更
             scale += 0.005f;
            transform.localScale = new Vector3(scale, scale, scale);

            //透明度を減少させていく
            
            GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.01f);

            Invoke("Buddhahood", 1.0f);//時間差で削除

        }
        //一度でも飛ばされたフラグがオンの時、スコアを変動させて自身を消去
        if(collider.tag == "DestroyEria" && destroy)
        {
            //悪人の時
            if (evil)
            {

                scoreManeger.score += scoreUp;//スコアを加算
                scoreManeger.combo++;//コンボ＋
            }
            
            //善人の時
            if (!evil)
            {

                scoreManeger.score -= scoreDown;//スコアを減少
                scoreManeger.miss++;//ダメージを受ける
                scoreManeger.combo = 0;//コンボリセット
                //マイナスの時は0に
                if (scoreManeger.score < 0)
                {
                    scoreManeger.score = 0;
                }
            }
            Destroy (gameObject);
           
        }

    }





    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        //悪霊が悪魔にぶつかった時
        if (collider.tag == "Devil" && evil&&destroy)
        {
            if (devil == null)
            {
                devil = collider.gameObject.GetComponent<Devil>();//悪魔のスクリプト
            }
            if (devil != null)
            {
                scoreManeger.score += scoreUpDevil* scoreManeger.magnification;//スコアを加算
                devil.Damege();//落下関数を呼び出し
            }
        }
        //善の魂が悪霊に食われる時
        if (collider.tag == "Devil" && !evil)
        {
            
                devil = collider.gameObject.GetComponent<Devil>();//悪魔のスクリプト
            
           
              

                    devil.Eaten();

                    scoreManeger.miss++;//ダメージを受ける
                    scoreManeger.combo = 0;//コンボリセット

                    Destroy(gameObject);//消滅させる
                
            
            

        }


    

        //ぶつかった側も消去フラグをオン
        if (collider.tag == "Spirit"|| collider.tag == "EvilSpirit")
        {
            destroy = true;
        }






    } 


    //時間差で削除
    private void Buddhahood()
    {
        //善人の時
        if (!evil)
        {

            scoreManeger.score += scoreUp;//スコアを加算
        }
        //悪人の時
        if (evil)
        {

            scoreManeger.score -= scoreDown;//スコアを減少
            scoreManeger.miss++;//ダメージを受ける
            scoreManeger.combo = 0;//コンボリセット
                                   //マイナスの時は0に
            if (scoreManeger.score < 0)
            {
                scoreManeger.score = 0;
            }
        }
        Destroy(gameObject);
    }


}
