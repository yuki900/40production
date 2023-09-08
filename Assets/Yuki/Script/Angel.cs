using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{

    public enum Direction
    {

        Stopx,//停止
        Stopy,//停止
        Right,//右
        Left,//左
        Up,//上
        Down//下
    }
    //非公開変数
    Direction direction = Direction.Stopx;//プレイヤー方向
    
    float x;//プレイヤー移動用変数
    float y;//プレイヤー移動用変数


    private float speedx;//プレイヤーx移動速度
    private float speedy;//プレイヤーy移動速度

    //魂に渡す方向用フラグ
    [HideInInspector] public bool rightFlag = false;//右方向吹っ飛ばしフラグ
    [HideInInspector] public bool leftFlag = false;//左方向吹っ飛ばしフラグ
    [HideInInspector] public bool upFlag = false;//上方向吹っ飛ばしフラグ
    [HideInInspector] public bool downFlag = false;//下方向吹っ飛ばしフラグ

    private bool atackFlag=false;//攻撃フラグ
    private bool keyBlock=false;//連打防止用


    //インスペクタ表示変数
    [SerializeField][Tooltip("移動速度")] float moveSpeed = 8;//速度
 

    new Rigidbody2D rigidbody;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
            Moveupdate();
        


        //攻撃アニメを表示
        if (Input.GetKeyDown("z")&&!keyBlock)
        {
            if (!atackFlag)
            {
                animator.SetBool("MiniAtack", true);//アニメ変更処理
                animator.SetBool("Move", false);//アニメ変更処理
                atackFlag = true;
                keyBlock = true;
            }
        }

        if (Input.GetKeyDown("x")&&!keyBlock)
        {
            if (!atackFlag)
            {
                animator.SetBool("Atack", true);//アニメ変更処理
                animator.SetBool("Move", false);//アニメ変更処理
                atackFlag = true;
                keyBlock = true;
            }
            
        }


        if (atackFlag)
        {
            animator.SetBool("Move", false);//アニメ変更処理
            atackFlag = false;
            Invoke("animeReset", 0.3f);
        }

    }

    //攻撃時アニメリセット用関数
    void animeReset()
    {
        //フラグをリセット
        
        animator.SetBool("Atack", false);
        animator.SetBool("MiniAtack", false);

        keyBlock = false;
    }

    void FixedUpdate()
    {

    }



    void Moveupdate()
    {
        if (!atackFlag&&!keyBlock)
        {
            // 右・左
            x = Input.GetAxisRaw("Horizontal");

            // 上・下
            y = Input.GetAxisRaw("Vertical");



            //エネミーの向きに応じて移動処理

            if (x > 0f)
            {
                //右
                direction = Direction.Right;
                //画像の向きを変更
                transform.localScale = new Vector3(-1f, 1f, 1f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

                //魂に渡す方向用フラグを変更
                rightFlag = true;
                leftFlag = false;
                Move();
            }
            else if (x < 0f)
            {
                //左
                direction = Direction.Left;
                //画像の向きを変更
                transform.localScale = new Vector3(1f, 1f, 1f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

                //魂に渡す方向用フラグを変更
                rightFlag = false;
                leftFlag = true;
                Move();
            }
            else
            {
                //止まっている
                speedx = 0;
            }


            if (y > 0f)
            {
                //上
                direction = Direction.Up;
                //画像の向きを変更
                //左右移動の反転で角度を修正
                //左向きの時
                if (transform.localScale.x >= 1.0f)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, -55);


                }
                //左
                else if (transform.localScale.x <= -1.0f)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 55);


                }
                //魂に渡す方向用フラグを変更
                upFlag = true;
                downFlag = false;
                Move();
            }
            else if (y < 0f)
            {
                //下
                direction = Direction.Down;
                //画像の向きを変更
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                //魂に渡す方向用フラグを変更
                upFlag = false;
                downFlag = true;
                Move();
            }
            else
            {
                //止まっている
                speedy = 0;
                //魂に渡す方向用フラグを変更
                upFlag = false;
                downFlag = false;
                //画像の向きを変更
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }



            //アニメ系処理
            //左右どちらかの移動フラグがオンの時、アニメ変更フラグをオンに
            if (!atackFlag && (x != 0 || y != 0))
            {
                animator.SetBool("Move", true);//アニメ変更処理
            }
            else if (x == 0 && y == 0)
            {

                animator.SetBool("Move", false);//アニメ変更処理

            }




        }


        void Move()
        {



            switch (direction)
            {

                case Direction.Right:

                    speedx = moveSpeed;

                    break;
                case Direction.Left:


                    speedx = -moveSpeed;

                    break;


                case Direction.Up:


                    speedy = moveSpeed;

                    break;

                case Direction.Down:


                    speedy = -moveSpeed;

                    break;


                case Direction.Stopx:
                    speedx = 0;
                    break;
                case Direction.Stopy:
                    speedy = 0;
                    break;

            }
        }
        

        //攻撃がオンの時は移動しない
        if (atackFlag|| keyBlock)
        {
            rigidbody.velocity = Vector2.zero;


        }
        else rigidbody.velocity = new Vector2(speedx, speedy);
    }






}
