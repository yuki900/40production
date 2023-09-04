using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    // �R���|�[�l���g
    private Button button;

    protected virtual void Start()
    {
        // �R���|�[�l���g�擾
        button = GetComponent<Button>();

        // �C�x���g�Ɋ֐���ǉ�
        button.onClick.AddListener(OnClick);
    }

    /// <summary>
    /// �{�^���N���b�N���ɌĂяo�����֐�
    /// </summary>
    protected abstract void OnClick();
}
