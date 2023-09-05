using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    private float speed;//���ۂɎg�����x

    private bool eriaFlag = false;//������΂��͈͂ɋ��邩�t���O
  
    
  

    //�C���X�y�N�^�\���ϐ�
    [SerializeField] private float moveSpeed;//���x
    [SerializeField] private float power;//������΂���(��)
    [SerializeField] private float miniPower;//������΂���(��)



    private Angel angel;
    new Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        speed = moveSpeed;//�A�h�t�H�[�X�p�ɑ��x�ϐ�����

        rigidbody = GetComponent<Rigidbody2D>();


        if (angel == null)
        {

            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            angel = Player.GetComponent<Angel>();


        }

    }

    // Update is called once per frame
    void Update()
    {

        rigidbody.AddForce(Vector2.up * speed, ForceMode2D.Force);//�펞��Ɉړ�

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
    }



    private void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {

            eriaFlag = true;
        }




    }

}
