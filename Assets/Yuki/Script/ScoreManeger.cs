using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    public float score = 0;//�X�R�A
    [SerializeField] private Text scoreText;//UI�\���p

    // Start is called before the first frame update
    void Start()
    {
        score = 0;//������
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();//�X�R�A�\������
    }
}
