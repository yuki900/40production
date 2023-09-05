using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    [SerializeField]
    private InputAction inputAction;

    /// <summary>
    /// ���擾
    /// </summary>
    public Vector2 GetAxis => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    /// <summary>
    /// ���擾(�������Ȃ�)
    /// </summary>
    public Vector2 GetAxisRaw => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    /// <summary>
    /// �R���g���[���[�U��
    /// </summary>
    /// <param name="_duration">��������</param>
    public void Vibrate(float _duration)
    {
        Gamepad gamepad = Gamepad.current;

        gamepad?.SetMotorSpeeds(0.0f, 1.0f);
        Invoke(InputSystem.ResetHaptics, _duration);
    }

    /// <summary>
    /// �R���g���[���[�U��(�����ݒ�\)
    /// </summary>
    /// <param name="_lowFrequency">����(����g)</param>
    /// <param name="_highFrequency">����(�����g)</param>
    /// <param name="_duration">��������</param>
    public void Vibrate(float _duration, float _lowFrequency, float _highFrequency)
    {
        Gamepad gamepad = Gamepad.current;

        gamepad?.SetMotorSpeeds(_lowFrequency, _highFrequency);
        Invoke(InputSystem.ResetHaptics, _duration);
    }
}
