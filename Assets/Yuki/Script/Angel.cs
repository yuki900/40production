using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{

    public enum Direction
    {

        Stopx,//��~
        Stopy,//��~
        Right,//�E
        Left,//��
        Up,//��
        Down//��
    }
    //����J�ϐ�
    Direction direction = Direction.Stopx;//�v���C���[����

    float speedx;//�v���C���[x�ړ����x
    float speedy;//�v���C���[y�ړ����x

    //���ɓn�������p�t���O
    public bool rightFlag = false;//�E����������΂��t���O
    public bool leftFlag = false;//������������΂��t���O


    //�C���X�y�N�^�\���ϐ�
    [SerializeField] float moveSpeed = 8;//���x
                                        

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
        


        // �E�E��
        float x = Input.GetAxisRaw("Horizontal");

        // ��E��
        float y = Input.GetAxisRaw("Vertical");

        //�G�l�~�[�̌����ɉ����Ĉړ�����

        if (x > 0f)
        {
            //�E
            direction = Direction.Right;
            //���ɓn�������p�t���O��ύX
            rightFlag = true;
            leftFlag = false;
            Moveupdate();
        }
        else if (x < 0f)
        {
            //��
            direction = Direction.Left;
            //���ɓn�������p�t���O��ύX
            rightFlag = false;
            leftFlag = true;
            Moveupdate();
        }
        else
        {
            //�~�܂��Ă���
            speedx = 0;
        }


        if (y > 0f)
        {
            //��
            direction = Direction.Up;
            Moveupdate();
        }
        else if (y < 0f)
        {
            //��
            direction = Direction.Down;
            Moveupdate();
        }
        else
        {
            //�~�܂��Ă���
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
