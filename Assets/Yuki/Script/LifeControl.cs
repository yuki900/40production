using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeControl : MonoBehaviour
{


    [SerializeField] public Sprite damegeSprite;//�_���[�W���󂯂����̃��C�t

    [SerializeField] private int lifeNumber;//���g�����Ԗڂ̃��C�t��

 
    [HideInInspector] ScoreManeger scoreManeger;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {

        image = GetComponent<Image>();

        if (scoreManeger == null)
        {

            GameObject saveObject = GameObject.FindGameObjectWithTag("ScoreManeger");
            scoreManeger = saveObject.GetComponent<ScoreManeger>();


        }

    }

    // Update is called once per frame
    void Update()
    {
        if (lifeNumber > scoreManeger.life)
        {
            image.sprite = damegeSprite;//�����̃��C�t���ԍ������̎��A�_���[�W���󂯂��Ƃ݂Ȃ��ĉ摜��ύX

        }





    }
}
