using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    [HideInInspector] public float score = 0;//�X�R�A
    [HideInInspector] public float miss = 0;//�~�X��
    [HideInInspector] public float combo = 0;//�R���{��


    //�X�R�A�㏸��
    [Header("�X�R�A�֌W�̐ݒ荀��")]
    [SerializeField][Tooltip("�オ��X�R�A")] public int scoreUp;
    [SerializeField][Tooltip("������X�R�A")] public int scoreDown;
    [SerializeField][Tooltip("�����ŏオ��X�R�A")] public int scoreUpDevil;


    [Header("��")]
    [SerializeField][Tooltip("������")] private GameObject light_small;
    [SerializeField][Tooltip("����")] private GameObject light_regular;
    [SerializeField][Tooltip("�傫��")] private GameObject light_large;

    [Header("�������o��R���{��")]
    [SerializeField] public int devilGenerate;


    [Header("�R���{�ɉ��������̐؂�ւ�")]
    [SerializeField][Tooltip("���ʂɂȂ�R���{��")] private int comboRegular;
    [SerializeField][Tooltip("�ő�ɂȂ�R���{��")] private int comboLarge;

    [Header("�\������e�L�X�g")]
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

       


        //�ŏ��T�C�Y�̕\��
        if(combo< comboRegular)
        {
            light_small.SetActive(true);//��
            light_regular.SetActive(false);//��
            light_large.SetActive(false);//��


        }
        //���ʃT�C�Y�̕\��
        else if(combo >= comboRegular&& combo< comboLarge)
        {
            light_small.SetActive(false);//��
            light_regular.SetActive(true);//��
            light_large.SetActive(false);//��
        }
        //�ő�T�C�Y�̕\��
        else if (combo >= comboLarge)
        {
            light_small.SetActive(false);//��
            light_regular.SetActive(false);//��
            light_large.SetActive(true);//��
        }







    }
}
