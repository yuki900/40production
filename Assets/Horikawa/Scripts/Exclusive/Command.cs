using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Command : MonoBehaviour
{
    // �R���|�[�l���g
    private Image image;

    // ��I�����̐F
    private static readonly Color UNSELECTED_COLOR = new(1f, 1f, 1f, 0.5f);

    // �F�̕�Ԓl
    private const float COLOR_LERP_VALUE = 0.5f;

    // �I������Ă��邩
    public bool isSelected;

    // ���莞�ɌĂяo���C�x���g
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
