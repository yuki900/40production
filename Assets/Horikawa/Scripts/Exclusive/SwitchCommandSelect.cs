using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCommandSelect : MonoBehaviour
{
    // �{�^��1
    [SerializeField]
    private Command command1;
    // �{�^��2
    [SerializeField]
    private Command command2;

    private void Start()
    {
        SelectButton1();

        // �C�x���g�Ɋ֐���ǉ�
        InputManager.Instance.upEvent.AddListener(SelectButton1);
        InputManager.Instance.downEvent.AddListener(SelectButton2);
    }

    private void SelectButton1()
    {
        command1.isSelected = true;
        command2.isSelected = false;
    }

    private void SelectButton2()
    {
        command1.isSelected = false;
        command2.isSelected = true;
    }
}
