using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    private float speed;//���ۂɎg�����x

    private bool eriaFlag = false;//������΂��͈͂ɋ��邩�t���O
    private bool lightFlag = false;//���͈͂ɋ��邩�t���O
    private Vector2 goalPosition;//���̍��W


    private int yPosition = 16;//�ړ��ʒu�w��p�ϐ�

    private bool destroy = false;//�폜�p�t���O

    //�����֌W
    private  bool eatStart = false;//�����ɐH����J�n
    private Vector2 devilPosition;//�����̍��W

    //�X�R�A
    private int scoreUp;
    private int scoreDown;
    private int scoreUpDevil;

    //�C���X�y�N�^�\���ϐ�
    [Header("������΂��͊֌W�̐ݒ荀��")]
    [SerializeField][Tooltip("������΂���(��)")] private float miniPower;//������΂���(��)
    [SerializeField][Tooltip("������΂���(��)")] private float power;//������΂���(��)
    [SerializeField][Tooltip("�I���ɂ���ƈ���")] private bool evile = false;//���l���P�l��

    [Header("���x")]
    [SerializeField][Tooltip("�ŏ����x")] private float minSpede;
    [SerializeField][Tooltip("�ő呬�x")] private float maxSpede;


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

        float rnd = Random.Range(minSpede, maxSpede);//���x���ŏ��ő�͈̔͂��烉���_���Ɍ���
        speed = rnd;//���ۂ̑��x����
        goalPosition = new Vector2(gameObject.transform.position.x, yPosition);//�����������ʒu��ݒ�



        //�X�R�A�}�l�[�W���[����X�R�A�֌W�̐��l���擾
        scoreUp= scoreManeger.scoreUp;
        scoreDown = scoreManeger.scoreDown;
        scoreUpDevil = scoreManeger.scoreUpDevil;

}

    // Update is called once per frame
    void Update()
    {
        //���͈̔͂ɋ��鎞�̂ݏ�ɏ��
        //�͈͊O�ɍs�����ꍇ�͗�����
        if (lightFlag && !eatStart)
        {
            rigidbody.gravityScale = 0;//��邽�߂ɏd���Ȃ���

            goalPosition = new Vector2(0, yPosition);//�����������ʒu��ݒ�
            Transform objectTransform = gameObject.GetComponent<Transform>(); // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾
            objectTransform.position = Vector3.Lerp(objectTransform.position, goalPosition, speed * Time.deltaTime); // �ړI�̈ʒu�Ɉړ�


        }
        else if (!lightFlag && !eatStart)
        {
            rigidbody.gravityScale = 1;//�d���𑀍삵�ė��Ƃ�
          
        }

        //�����Ɉ����񂹂���
        if (eatStart)
        {


            Transform objectTransform = gameObject.GetComponent<Transform>(); // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾
            objectTransform.position = Vector3.Lerp(objectTransform.position, devilPosition, speed*2 * Time.deltaTime); // �ړI�̈ʒu�Ɉړ�
        }


        //�͂�������n
        //�����̂Ђ��悹���͏o���Ȃ�

        //�ア
        if (Input.GetKeyDown("z") && eriaFlag&&!eatStart)
        {
            destroy=true;//�����p�t���O
            rigidbody.gravityScale = 0;

            //�����Ă�����ɉ����Ă͂�����������ύX
            //�E
            if (angel.rightFlag)
            {
             
                rigidbody.AddForce(Vector2.right * miniPower, ForceMode2D.Force);
               

            }

            //��
            if (angel.leftFlag)
            {
                rigidbody.AddForce(Vector2.left * miniPower, ForceMode2D.Force);

            }
            //��
            if (angel.upFlag)
            {
                rigidbody.AddForce(Vector2.up * miniPower, ForceMode2D.Force);
            }
            //��
            if (angel.downFlag)
            {
                rigidbody.AddForce(Vector2.down * miniPower, ForceMode2D.Force);
            }
            eriaFlag = false;

        }

        //������
        if (Input.GetKeyDown("x") && eriaFlag&&!eatStart)
        {
            destroy = true;//�����p�t���O
            rigidbody.gravityScale = 1;//�����p�ɏd�͂𑀍�
            speed = 0;

            //�����Ă�����ɉ����Ă͂�����������ύX
            //�E
            if (angel.rightFlag)
            {
                rigidbody.AddForce(Vector2.right * power, ForceMode2D.Force);


            }

            //��
            if (angel.leftFlag)
            {
                rigidbody.AddForce(Vector2.left * power, ForceMode2D.Force);

            }
            //��
            if (angel.upFlag)
            {
                rigidbody.AddForce(Vector2.up * power, ForceMode2D.Force);

            }
            //��
            if (angel.downFlag)
            {
                rigidbody.AddForce(Vector2.down * power, ForceMode2D.Force);

            }
            eriaFlag = false;

        }




    }

    private void FixedUpdate()
    {
        eriaFlag = false;
        lightFlag = false;
    }


    //�����Ɉ����񂹂��鎞�̊֐�
    public void DevilEat(Vector2 targetPosition)
    {

        eatStart = true;//�H����
        devilPosition = targetPosition;
   

    }
    //�������|���ꂽ���̊֐�
    public void DevilEatReset()
    {

        eatStart = false;//�H���铮��I��


    }







    private void OnTriggerStay2D(Collider2D collider)
    {
        //�v���C���[�͈̔͂ɓ���ƍU���\�t���O���I��
        if (collider.tag == "Player")
        {

            eriaFlag = true;
        }
        //���͈̔͂ɋ���ƁA�㏸�t���O���I��
        if (collider.tag == "GodLight")
        {
            lightFlag = true;

        }
        //�X�R�A�͈͂ɓ�������X�R�A�����Z���A���g���폜
        if (collider.tag == "ScoreEria")
        {
            //�P�l�̎�
            if (!evile)
            {

                scoreManeger.score += scoreUp;//�X�R�A�����Z
            }
            //���l�̎�
            if (evile)
            {

                scoreManeger.score -= scoreDown;//�X�R�A������
                scoreManeger.miss++;//�_���[�W���󂯂�
                scoreManeger.combo = 0;//�R���{���Z�b�g
                //�}�C�i�X�̎���0��
                if (scoreManeger.score < 0)
                {
                    scoreManeger.score = 0;
                }
            }
            Destroy(gameObject);

        }
        //��x�ł���΂��ꂽ�t���O���I���̎��A�X�R�A��ϓ������Ď��g������
        if(collider.tag == "DestroyEria" && destroy)
        {
            //���l�̎�
            if (evile)
            {

                scoreManeger.score += scoreUp;//�X�R�A�����Z
                scoreManeger.combo++;//�R���{�{
            }
            
            //�P�l�̎�
            if (!evile)
            {

                scoreManeger.score -= scoreDown;//�X�R�A������
                scoreManeger.miss++;//�_���[�W���󂯂�
                scoreManeger.combo = 0;//�R���{���Z�b�g
                //�}�C�i�X�̎���0��
                if (scoreManeger.score < 0)
                {
                    scoreManeger.score = 0;
                }
            }
            Destroy(gameObject);
        }

    }





    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        //���삪�����ɂԂ�������
        if (collider.tag == "Devil" && evile&&destroy)
        {
            if (devil == null)
            {
                devil = collider.gameObject.GetComponent<Devil>();//�����̃X�N���v�g
            }
            if (devil != null)
            {
                scoreManeger.score += scoreUpDevil;//�X�R�A�����Z
                devil.Damege();//�����֐����Ăяo��
            }
        }
        //�P�̍�������ɐH���鎞
        if (collider.tag == "Devil" && !evile)
        {
            if (devil == null)
            {
                devil = collider.gameObject.GetComponent<Devil>();//�����̃X�N���v�g
            }
            if (devil != null)
            {
                devil.Eaten();
            }

            scoreManeger.miss++;//�_���[�W���󂯂�
            scoreManeger.combo=0;//�R���{���Z�b�g
          
            Destroy(gameObject);//���ł�����

        }


    

        //�Ԃ��������������t���O���I��
        if (collider.tag == "Spirit"|| collider.tag == "EvilSpirit")
        {
            destroy = true;
        }






    } 





}
