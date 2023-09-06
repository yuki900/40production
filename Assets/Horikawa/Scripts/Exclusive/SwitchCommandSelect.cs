using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCommandSelect : MonoBehaviour
{
    // 軸
    private enum Axis
    {
        Horizontal,
        Vertical,
    }

    // ボタン1
    [SerializeField]
    private Command command1;
    // ボタン2
    [SerializeField]
    private Command command2;

    // 切り替え用の入力軸
    [SerializeField]
    private Axis selectAxis;

    private void Start()
    {
        SelectCommand1();

        // イベントに関数を追加
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
