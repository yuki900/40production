using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Devil : MonoBehaviour
{
    private GameObject nearObj;         //�ł��߂��I�u�W�F�N�g


    //�C���X�y�N�^�ɕ\��
    [Header("�ړ����x")]
    [SerializeField]float moveSpeed;//���x
    [Header("����H���Ԋu")]
    [SerializeField] private float time;//����H���Ԋu



    private float timeCount=0;//�H�����ԗp�ϐ�
    private bool follFlag = false;//��e�t���O


    private bool moveFlag = false;//�ړ��t���O




    DevilGenerater devilGenerater;
    private Spirit spirite;

    new Rigidbody2D rigidbody;

    Animator animator;

    void Start()
    {


        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        //�W�F�l���[�^���擾
        if (devilGenerater == null)
        {

            GameObject saveObject = GameObject.FindGameObjectWithTag("DevilGenerater");
            devilGenerater = saveObject.GetComponent<DevilGenerater>();


        }




        //�ł��߂������I�u�W�F�N�g���擾
        nearObj = serchTag(gameObject, "Spirit");
        if (nearObj != null)
        {
            
            //�֐����ĂԈׂɃX�N���v�g���擾
            spirite = nearObj.GetComponent<Spirit>();
        }
        animator.SetBool("Ded", false);//�������o




        devilGenerater.existenceFlag = true;//���������łɐ�������Ă���t���O��^����
        moveFlag = true;//�ړ��J�n
    }

    // Update is called once per frame
    void Update()
    {
       

        if (moveFlag)
        {

            Vector2 goalPosition = new Vector2(0, 0);//�����������ʒu��ݒ�

            //�����ʒu���E�̎��͉E�̈ʒu�Ɉړ�
            if (gameObject.transform.position.x >= 0)
            {
                goalPosition = new Vector2(4, 0);//�����������ʒu��ݒ�

            }
            //�����ʒu�����̎��͍��̈ʒu�Ɉړ�
            if (gameObject.transform.position.x < 0)
            {
                goalPosition = new Vector2(-4, 0);//�����������ʒu��ݒ�

            }

            Transform objectTransform = gameObject.GetComponent<Transform>(); // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾
            objectTransform.position = Vector3.Lerp(objectTransform.position, goalPosition, moveSpeed * Time.deltaTime); // �ړI�̈ʒu�Ɉړ�

        }





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
      
        devilGenerater.existenceFlag = false;//�܂��������Ăׂ�悤��
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
