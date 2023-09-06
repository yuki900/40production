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

    private float speedx;//プレイヤーx移動速度
    private float speedy;//プレイヤーy移動速度

    //魂に渡す方向用フラグ
    public bool rightFlag = false;//右方向吹っ飛ばしフラグ
    public bool leftFlag = false;//左方向吹っ飛ばしフラグ


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


        








    }




    void FixedUpdate()
    {

    }



    void Moveupdate()
    {
        


        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

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
            Moveupdate();
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
            Moveupdate();
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


            Moveupdate();
        }
        else if (y < 0f)
        {
            //下
            direction = Direction.Down;
            //画像の向きを変更
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Moveupdate();
        }
        else
        {
            //止まっている
            speedy = 0;
            //画像の向きを変更
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }



        //アニメ系処理
        //左右どちらかの移動フラグがオンの時、アニメ変更フラグをオンに
        if (x != 0||y!=0)
        {
            animator.SetBool("Move", true);//アニメ変更処理
        }
        else if (x == 0 && y == 0)
        {

            animator.SetBool("Move", false);//アニメ変更処理

        }








        void Moveupdate()
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
        rigidbody.velocity = new Vector2(speedx, speedy);
    }






}
