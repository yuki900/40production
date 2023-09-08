using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilGenerater : MonoBehaviour
{
    //�C���X�y�N�^�ɕ\���������
    [Header("�������鈫��")]
    [SerializeField][Tooltip("����")] GameObject�@Devil;

    [Header("�����m��")]
    [SerializeField][Range(1, 100)] private int generateProbability;

    [Header("�������ԊԊu")]
    [SerializeField] private float time;


    [Header("������")]
    [SerializeField] private int generateMax;//�����ő吔

    [Header("�X�R�A�}�l�[�W���[")]
    [SerializeField][Tooltip("�X�R�A�}�l�[�W���[")] ScoreManeger scoreManeger;//����


    [HideInInspector] public bool existenceFlag=false;//���łɈ��������邩�̃t���O


    private int generateCount = 0;//�����J�E���g
    private float timeCount = 0;

    private int rlRand;

   // Start is called before the first frame update
   void Start()
    {
        generateCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount+= Time.deltaTime;//���Ԃ��o�߂�����



        //�����𐶐�����ő吔
        if (generateCount < generateMax)
        {
            //���߂�ꂽ���Ԓu�������������Ȃ��Ƃ�
            if (timeCount >= time)
            {

                //�R���{���������o�������𖞂����Ă��鎞
                if (scoreManeger.combo >= scoreManeger.devilGenerate)
                {

                    
                        Generater();
                        
                    
                }
                timeCount = 0;
            }
           
        }
       
    }



    private void Generater() {

        //���łɈ��������Ȃ���
        if (!existenceFlag)
        {
            float rnd = Random.Range(0, 100);//�����_��������������

            //���߂������ȉ��Ȃ琶��
            if (rnd <= generateProbability)
            {

                rlRand = Random.Range(0,2);//���E�������_���Ɍ���
               

                //��������ʒu
                Vector3 posi = new Vector3(0, 0, 0);
                //1�Ȃ�E�ɐ���
                if (rlRand == 1)
                {

                    posi = new Vector3(8, 0, 0.0f);//�����ʒu������

                }

                //0�Ȃ�E�ɐ���
                else if (rlRand != 1)
                {

                    posi = new Vector3(-8, 0, 0.0f);//�����ʒu������

                }
                //����
                Instantiate(Devil, posi, Quaternion.identity);
                generateCount++;//�J�E���g�𑝉�
            }





        }

    }




}
