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

    float speedx;//プレイヤーx移動速度
    float speedy;//プレイヤーy移動速度

    //魂に渡す方向用フラグ
    public bool rightFlag = false;//右方向吹っ飛ばしフラグ
    public bool leftFlag = false;//左方向吹っ飛ばしフラグ


    //インスペクタ表示変数
    [SerializeField] float moveSpeed = 8;//速度
                                        

    Rigidbody2D rigid2D;



    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
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
            //魂に渡す方向用フラグを変更
            rightFlag = true;
            leftFlag = false;
            Moveupdate();
        }
        else if (x < 0f)
        {
            //左
            direction = Direction.Left;
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
            Moveupdate();
        }
        else if (y < 0f)
        {
            //下
            direction = Direction.Down;
            Moveupdate();
        }
        else
        {
            //止まっている
            speedy = 0;
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
        rigid2D.velocity = new Vector2(speedx, speedy);
    }






}
