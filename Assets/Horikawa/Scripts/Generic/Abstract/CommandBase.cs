using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandBase : MonoBehaviour
{
    // �R���|�[�l���g
    private Command command;

    private void Awake()
    {
        // �R���|�[�l���g�擾
        command = GetComponent<Command>();

        // �C�x���g�Ɋ֐���ǉ�
        command.onDecide.AddListener(OnDecide);
        InputManager.Instance.decideEvent.AddListener(DecideInput);
    }

    // ���莞�ɌĂяo�����֐�
    protected abstract void OnDecide();

    // ������͎��ɌĂяo�����֐�
    private void DecideInput()
    {
        if (command.isSelected)
        {
            command.onDecide.Invoke();
        }
    }
}
