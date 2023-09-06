using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SwitchButtonSelect : MonoBehaviour
{
    // �{�^��1
    [SerializeField]
    private Button button1;
    // �{�^��2
    [SerializeField]
    private Button button2;

    private void Start()
    {
        SelectButton1();

        // �C�x���g�Ɋ֐���ǉ�
        InputManager.Instance.upEvent.AddListener(SelectButton1);
        InputManager.Instance.downEvent.AddListener(SelectButton2);
    }

    private void SelectButton1()
    {
        button1.interactable = true;
        button2.interactable = false;
    }

    private void SelectButton2()
    {
        button1.interactable = false;
        button2.interactable = true;
    }
}