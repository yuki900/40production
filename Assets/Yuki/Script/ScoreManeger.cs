using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    [HideInInspector] public int score = 0;//�X�R�A
    [HideInInspector] public int life = 3;//���C�t
    [HideInInspector] public int combo = 0;//�R���{��


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

    [Header("�^�C�}�[")]
    [SerializeField][Tooltip("�ő厞��(1��2���̂悤�Ȍ`���œ���)")] private float maxTime;
    private float time = 60;//���ۂɕ\������p�ϐ�

    //�\�������p�ϐ�
    private float minTime;
    private float secondTime;




    [Header("�\������e�L�X�g")]
    [SerializeField] private Text scoreText;//UI�\���p
   // [SerializeField] private Text lifeText;//UI�\���p
    [SerializeField] private Text comboText;//UI�\���p
    [SerializeField] private Text timeText;//UI�\���p

    [HideInInspector] public int magnification=1;//�R���{���̔{���p�ϐ�




    [Header("�{��")]
    [SerializeField] int[] times = new int[20];//��̓I�Ȕ{��


    // Start is called before the first frame update
    void Start()
    {
        score = 0;//������
        life = 3;


        time = 60 * maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();//�X�R�A�\������
       // lifeText.text = life.ToString();//�~�X�\������
        comboText.text = combo.ToString();//�R���{�\������

       


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



        //�^�C�}�[����

        time-=Time.deltaTime;

        minTime = (int)((time % 3600) / 60);
        secondTime = (int)(time % 60);
        // �b���ꌅ�̎��擪��0�ǉ�(�O�c�ǉ�)
        if (secondTime < 10)
        {
            timeText.text = $"{minTime}:0{secondTime}";
        }
        else
        {
            timeText.text = $"{minTime}:{secondTime}";
        }






        Combo();
      

    }


    private void Combo()
    {

        //�R���{���ɉ������X�R�A�{���̕ω�
        if (combo <= 15)
        {
            magnification = times[0];
        }
        else if (combo >= 16 && combo <= 20)
        {
            magnification = times[1];
        }
        else if (combo >= 21 && combo <= 25)
        {
            magnification = times[2];
        }
        else if (combo >= 26 && combo <= 30)
        {
            magnification = times[3];
        }
        else if (combo >= 31 && combo <= 35)
        {
            magnification = times[4];
        }
        else if (combo >= 36 && combo <= 40)
        {
            magnification = times[5];
        }
        else if (combo >= 41 && combo <= 45)
        {
            magnification = times[6];
        }
        else if (combo >= 46 && combo <= 50)
        {
            magnification = times[7];
        }
        else if (combo >= 51 && combo <= 55)
        {
            magnification = times[8];
        }
        else if (combo >= 56 && combo <= 60)
        {
            magnification = times[9];
        }
        else if (combo >= 60 && combo <= 65)
        {
            magnification = times[10];
        }
        else if (combo >= 66 && combo <= 70)
        {
            magnification = times[11];
        }
        else if (combo >= 71 && combo <= 75)
        {
            magnification = times[12];
        }
        else if (combo >= 75 && combo <= 80)
        {
            magnification = times[13];
        }
        else if (combo >= 81 && combo <= 85)
        {
            magnification = times[14];
        }
        else if (combo >= 86 && combo <= 90)
        {
            magnification = times[15];
        }
        else if (combo >= 91 && combo <= 95)
        {
            magnification = times[16];
        }
        else if (combo >= 96 && combo <= 100)
        {
            magnification = times[17];
        }
        else if (combo >= 101)
        {
            magnification = times[18];
        }


    }

}
