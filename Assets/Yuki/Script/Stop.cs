using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    private ScoreManeger scoreManeger;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        if (scoreManeger == null)
        {

            GameObject saveObject = GameObject.FindGameObjectWithTag("ScoreManeger");
            scoreManeger = saveObject.GetComponent<ScoreManeger>();


        }
    }

    // Update is called once per frame
    void Update()
    {


        if (scoreManeger.endStopFlag)
        {

          Destroy(gameObject);
        }

    }
}
