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

    private float speedx;//�v���C���[x�ړ����x
    private float speedy;//�v���C���[y�ړ����x

    //���ɓn�������p�t���O
    public bool rightFlag = false;//�E����������΂��t���O
    public bool leftFlag = false;//������������΂��t���O


    //�C���X�y�N�^�\���ϐ�
    [SerializeField][Tooltip("�ړ����x")] float moveSpeed = 8;//���x
 

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
        


        // �E�E��
        float x = Input.GetAxisRaw("Horizontal");

        // ��E��
        float y = Input.GetAxisRaw("Vertical");

        //�G�l�~�[�̌����ɉ����Ĉړ�����

        if (x > 0f)
        {
            //�E
            direction = Direction.Right;
            //�摜�̌�����ύX
            transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            //���ɓn�������p�t���O��ύX
            rightFlag = true;
            leftFlag = false;
            Moveupdate();
        }
        else if (x < 0f)
        {
            //��
            direction = Direction.Left;
            //�摜�̌�����ύX
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

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
            //�摜�̌�����ύX
            //���E�ړ��̔��]�Ŋp�x���C��
            //�������̎�
            if (transform.localScale.x >= 1.0f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, -55);


            }
            //��
            else if (transform.localScale.x <= -1.0f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 55);


            }


            Moveupdate();
        }
        else if (y < 0f)
        {
            //��
            direction = Direction.Down;
            //�摜�̌�����ύX
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Moveupdate();
        }
        else
        {
            //�~�܂��Ă���
            speedy = 0;
            //�摜�̌�����ύX
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }



        //�A�j���n����
        //���E�ǂ��炩�̈ړ��t���O���I���̎��A�A�j���ύX�t���O���I����
        if (x != 0||y!=0)
        {
            animator.SetBool("Move", true);//�A�j���ύX����
        }
        else if (x == 0 && y == 0)
        {

            animator.SetBool("Move", false);//�A�j���ύX����

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
