using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    private float speed;//���ۂɎg�����x

    private bool eriaFlag = false;//������΂��͈͂ɋ��邩�t���O
    private bool lightFlag = false;//���͈͂ɋ��邩�t���O
  
    
  

    //�C���X�y�N�^�\���ϐ�
    [SerializeField][Tooltip("�㏸���x")] private float moveSpeed;//���x
    [SerializeField][Tooltip("������΂���(��)")] private float power;//������΂���(��)
    [SerializeField][Tooltip("������΂���(��)")] private float miniPower;//������΂���(��)
    [SerializeField][Tooltip("�I���ɂ���ƈ���")] private bool evile = false;//���l���P�l��


    private Angel angel;

    private ScoreManeger scoreManeger;



    new Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        speed = moveSpeed;//�A�h�t�H�[�X�p�ɑ��x�ϐ�����

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
        //���͈̔͂ɋ��鎞�̂ݏ�ɏ��
        //�͈͊O�ɍs�����ꍇ�͗�����
        if (lightFlag)
        {
            rigidbody.gravityScale = 0;
            rigidbody.AddForce(Vector2.up * speed);//�펞��Ɉړ�
           // rigidbody.velocity = new Vector2(0, speed);
        }
        else rigidbody.gravityScale = 1;



        //�ア��
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

        //������
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

                scoreManeger.score += 100;
            }
            //���l�̎�
            if (evile)
            {

                scoreManeger.score -= 1000;
            }
            Destroy(gameObject);

        }



        
    }

}
