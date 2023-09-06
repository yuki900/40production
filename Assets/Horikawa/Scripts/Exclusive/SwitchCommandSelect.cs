using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCommandSelect : MonoBehaviour
{
    // ��
    private enum Axis
    {
        Horizontal,
        Vertical,
    }

    // �{�^��1
    [SerializeField]
    private Command command1;
    // �{�^��2
    [SerializeField]
    private Command command2;

    // �؂�ւ��p�̓��͎�
    [SerializeField]
    private Axis selectAxis;

    private void Start()
    {
        SelectCommand1();

        // �C�x���g�Ɋ֐���ǉ�
        InputManager.Instance.directionEvent.AddListener(AxisPerformed);
    }

    private void AxisPerformed(Vector2 _direction)
    {
        switch (selectAxis)
        {
            case Axis.Horizontal:
                if(_direction.x < 0)
                {
                    SelectCommand1();
                }
                else
                {
                    SelectCommand2();
                }
                break;

            case Axis.Vertical:
                if (_direction.y > 0)
                {
                    SelectCommand1();
                }
                else
                {
                    SelectCommand2();
                }
                break;

            default:
                break;
        }
    }

    private void SelectCommand1()
    {
        command1.isSelected = true;
        command2.isSelected = false;
    }

    private void SelectCommand2()
    {
        command1.isSelected = false;
        command2.isSelected = true;
    }
}
