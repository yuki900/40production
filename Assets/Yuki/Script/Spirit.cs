using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    [SerializeField] bool blowAwayFlag = false;//�E������΂��t���O
 

    //�C���X�y�N�^�\���ϐ�
    [SerializeField] float moveSpeed = 0.3f;//���x
    [SerializeField] float power = 1.0f;//������΂���

    private Angel angel;
    new Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
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
        

        rigidbody.AddForce(Vector2.up * moveSpeed, ForceMode2D.Force);//�펞��Ɉړ�


        if (Input.GetKeyDown(KeyCode.Return) && blowAwayFlag)
        {
            if (angel.rightFlag)
            {
                rigidbody.AddForce(Vector2.right * power, ForceMode2D.Force);
              
            }


            if (angel.leftFlag)
            {
                rigidbody.AddForce(Vector2.left * power, ForceMode2D.Force);
              
            }
            blowAwayFlag = false;
          
        }




    }

    private void FixedUpdate()
    {
      blowAwayFlag = false;
    }



    private void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {

            blowAwayFlag = true;
        }




    }

}
