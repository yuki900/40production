using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritGenerater : MonoBehaviour
{
    private float timeCount=0;//�����p�J�E���g


    //�C���X�y�N�^�ɕ\��
    [Header("�������鍰")]
    [SerializeField][Tooltip("�P�̍��̃v���n�u������")] GameObject Sprit;//�P��
    [SerializeField][Tooltip("���̍��̃v���n�u������")] GameObject EvileSprit;//����

    [Header("����")]
    [SerializeField][Tooltip("���𐶐����鎞�ԊԊu")] float generateTime;

    [Header("�m��")]
    [SerializeField][Range(1, 100)][Tooltip("�P�̍��𐶐�����m��")] private int ratio;//�P�̐�����������

    [Header("���W�֌W")]
    [SerializeField][Tooltip("��������͈�")] float interval;//�W�F�l���[�^�𒆐S�Ƃ������E�̐����͈�
    [SerializeField][Tooltip("��������y���W")] float y;//�������鍂��

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;//������
    }

    // Update is called once per frame
    void Update()
    {
        timeCount+=Time.deltaTime;//���Ԃ����Z

        //���߂�ꂽ���Ԓu���ɐ���
        if (timeCount > generateTime)
        {
            Generate();//�֐����Ă�Ő���
            Generate();//�֐����Ă�Ő���
            Generate();//�֐����Ă�Ő���

            timeCount = 0;//�J�E���^�[�̓��Z�b�g

        }


    }

    //���𐶐�����֐�
    public void Generate()
    {
        float rnd = Random.Range(-interval, interval);//�ʒu�Ƀ����_��������������
        

      
        Vector3 posi = new Vector3(rnd,y, 0.0f);//�����ʒu������

        //���̐���
        int typeRnd = Random.Range(0, 100);//�P���ǂ���𐶐����邩����

        //�������P�̍��������l�ȉ��Ȃ�A�P�̍��𐶐�
        //���l�𒴂��Ă���ꍇ�͈��̍��𐶐�
        if (typeRnd <= ratio)
        {
            Instantiate(Sprit, posi, Quaternion.identity);
        }
        else {
            Instantiate(EvileSprit, posi, Quaternion.identity);
        }
    }
}
