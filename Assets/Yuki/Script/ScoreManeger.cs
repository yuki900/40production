using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    public float score = 0;//�X�R�A
    public float miss = 0;//�~�X��
    public float combo = 0;//�R���{��
    [SerializeField] private Text scoreText;//UI�\���p
    [SerializeField] private Text missText;//UI�\���p
    [SerializeField] private Text comboText;//UI�\���p

    // Start is called before the first frame update
    void Start()
    {
        score = 0;//������
        miss = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();//�X�R�A�\������
        missText.text = miss.ToString();//�X�R�A�\������
        comboText.text = combo.ToString();//�X�R�A�\������

       

    }
}
