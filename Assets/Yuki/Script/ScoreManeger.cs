using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    public float score = 0;//�X�R�A
    public float life = 3;//���C�t
    [SerializeField] private Text scoreText;//UI�\���p

    // Start is called before the first frame update
    void Start()
    {
        score = 0;//������
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();//�X�R�A�\������

        //�}�C�i�X�̎���0��
        if (score < 0) { 
            score = 0; }

    }
}
