using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Command : MonoBehaviour
{
    // コンポーネント
    private Image image;

    // 非選択時の色
    private static readonly Color UNSELECTED_COLOR = new(1f, 1f, 1f, 0.5f);

    // 色の補間値
    private const float COLOR_LERP_VALUE = 0.5f;

    // 選択されているか
    public bool isSelected;

    // 決定時に呼び出すイベント
    public UnityEvent onDecide;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if(isSelected)
        {
            if (image.color.a < 1.0f - float.Epsilon)
            {
                image.color = Color.Lerp(image.color, Color.white, COLOR_LERP_VALUE);

                if (image.color.a >= 1.0f - float.Epsilon)
                {
                    image.color = Color.white;
                }
            }
        }
        else
        {
            if (image.color.a > float.Epsilon)
            {
                image.color = Color.Lerp(image.color, UNSELECTED_COLOR, COLOR_LERP_VALUE);

                if (image.color.a <= float.Epsilon)
                {
                    image.color = UNSELECTED_COLOR;
                }
            }
        }
    }
}
