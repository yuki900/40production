using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeControl : MonoBehaviour
{


    [SerializeField] public Sprite damegeSprite;//ダメージを受けた時のライフ

    [SerializeField] private int lifeNumber;//自身が何番目のライフか

 
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
            image.sprite = damegeSprite;//自分のライフが番号未満の時、ダメージを受けたとみなして画像を変更

        }





    }
}
