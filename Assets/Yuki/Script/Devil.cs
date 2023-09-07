using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Devil : MonoBehaviour
{
    private GameObject nearObj;         //�ł��߂��I�u�W�F�N�g

    [SerializeField] private float time;//����H���Ԋu



    private float timeCount=0;//�H�����ԗp�ϐ�
    private bool follFlag = false;//��e�t���O



    private Spirit spirite;

    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();


        //�ł��߂������I�u�W�F�N�g���擾
        nearObj = serchTag(gameObject, "Spirit");
        //�֐����ĂԈׂɃX�N���v�g���擾
        spirite = nearObj.GetComponent<Spirit>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;//���Ԃ��o�߂�����

        if (timeCount >= time)
        {
            //�ł��߂������I�u�W�F�N�g���擾
            nearObj = serchTag(gameObject, "Spirit");
            //�֐����ĂԈׂɃX�N���v�g���擾
            spirite = nearObj.GetComponent<Spirit>();

            // �ړI�̈ʒu�̍��W���w��
            Vector2 targetPosition = new Vector2(gameObject.transform.position.x, 
                                                 gameObject.transform.position.y ); 

            //�����̃X�N���v�g����ړ�������
            spirite.DevilEat(targetPosition);
            //�o�ߎ��Ԃ�������
            timeCount = 0;
        }

        if (follFlag)
        {
            rigidbody.gravityScale = 1;//�d�͂��I���ɂ��ė���������
            transform.localScale = new Vector3(1f, -1f, 1f);//���������o
            spirite.DevilEatReset();
        }





    }

    //������Ԃ���ꂽ��
    public void Damege()
    {
        follFlag = true;
        
    }







    //�w�肳�ꂽ�^�O�̒��ōł��߂����̂��擾
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���
        //string nearObjName = "";    //�I�u�W�F�N�g����
        GameObject targetObj = null; //�I�u�W�F�N�g

        //�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
            //�ꎞ�ϐ��ɋ������i�[
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //�ł��߂������I�u�W�F�N�g��Ԃ�
        //return GameObject.Find(nearObjName);
        return targetObj;
    }

}
