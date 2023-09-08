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

    Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //�ł��߂������I�u�W�F�N�g���擾
        nearObj = serchTag(gameObject, "Spirit");
        if (nearObj != null)
        {
            
            //�֐����ĂԈׂɃX�N���v�g���擾
            spirite = nearObj.GetComponent<Spirit>();
        }
        animator.SetBool("Ded", false);//�������o
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;//���Ԃ��o�߂�����
      
        if (timeCount >= time)
        {
            animator.SetBool("Eat", false);//�A�j���ύX����
            //�ł��߂������I�u�W�F�N�g���擾
            nearObj = serchTag(gameObject, "Spirit");
            
            if (nearObj != null)
            {
                
                //�֐����ĂԈׂɃX�N���v�g���擾
                spirite = nearObj.GetComponent<Spirit>();

            
                // �ړI�̈ʒu�̍��W���w��
                Vector2 targetPosition = new Vector2(gameObject.transform.position.x,
                                                     gameObject.transform.position.y);

                //�����̃X�N���v�g����ړ�������
                spirite.DevilEat(targetPosition);
                //�o�ߎ��Ԃ�������
                timeCount = 0;
            }
        }

        if (follFlag)
        {
            rigidbody.gravityScale = 1;//�d�͂��I���ɂ��ė���������
            animator.SetBool("Ded", true);//�������o
            spirite.DevilEatReset();
        }





    }

    //������Ԃ���ꂽ��
    public void Damege()
    {
        follFlag = true;
        
    }

    //������Ԃ���ꂽ��
    public void Eaten()
    {
        //�A�j����ύX���đ��߂�
        animator.SetBool("Eat", true);//�A�j���ύX����
        
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
