using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{





    //�C���X�y�N�^�\���ϐ�
    [SerializeField] float moveSpeed = 0.3f;//���x
    [SerializeField] float power = 1.0f;//������΂���

    new Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(Vector2.up * moveSpeed, ForceMode2D.Force);//�펞��Ɉړ�



    }



    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "RightAtackEria")
        {
            Debug.Log("������");

            if (Input.GetKeyDown("z"))
            {

                rigidbody.AddForce(Vector2.right * power, ForceMode2D.Force);


            }

        }

        if (collider.tag == "LeftAtackEria")
        {

            if (Input.GetKeyDown("z"))
            {

                rigidbody.AddForce(Vector2.left * power, ForceMode2D.Force);


            }

        }



    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "RightAtackEria")
        {
            Debug.Log("������");

            if (Input.GetKeyDown("z"))
            {

                rigidbody.AddForce(Vector2.right * power, ForceMode2D.Force);


            }

        }

        if (other.gameObject.tag == "LeftAtackEria")
        {

            if (Input.GetKeyDown("z"))
            {

                rigidbody.AddForce(Vector2.left * power, ForceMode2D.Force);


            }

        }



    }

}
