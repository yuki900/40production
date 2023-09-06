using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    // �|�[�Y���̓A�N�V����
    [SerializeField]
    private InputAction pauseInputAction;
    // �|�[�Y���͎��̃C�x���g
    [HideInInspector]
    public UnityEvent pauseEvent;

    // ����̓A�N�V����
    [SerializeField]
    private InputAction upInputAction;
    // �|�[�Y���͎��̃C�x���g
    [HideInInspector]
    public UnityEvent upEvent;

    // �����̓A�N�V����
    [SerializeField]
    private InputAction downInputAction;
    // �|�[�Y���͎��̃C�x���g
    [HideInInspector]
    public UnityEvent downEvent;

    // ������̓A�N�V����
    [SerializeField]
    private InputAction decideInputAction;
    // ������͎��̃C�x���g
    [HideInInspector]
    public UnityEvent decideEvent;

    private void OnEnable()
    {
        // ���̓A�N�V������L����
        pauseInputAction.Enable();
        upInputAction.Enable();
        downInputAction.Enable();
        decideInputAction.Enable();

        // �R�[���o�b�N��ǉ�
        pauseInputAction.performed  += PauseInvoke;
        upInputAction.performed     += UpInvoke;
        downInputAction.performed   += DownInvoke;
        decideInputAction.performed += DecideInvoke;
    }

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
        Vibrate(_duration, 0.0f, 1.0f);
    }

    /// <summary>
    /// �R���g���[���[�U��(�����ݒ�\)
    /// </summary>
    /// <param name="_lowFrequency">����(����g)</param>
    /// <param name="_highFrequency">����(�����g)</param>
    /// <param name="_duration">��������</param>
    public void Vibrate(float _duration, float _lowFrequency, float _highFrequency)
    {
        StartCoroutine(DoVibrate(_duration, _lowFrequency, _highFrequency));
    }

    private IEnumerator DoVibrate(float _duration, float _lowFrequency, float _highFrequency)
    {
        Gamepad gamepad = Gamepad.current;
        gamepad?.SetMotorSpeeds(_lowFrequency, _highFrequency);

        float durationCount = 0f;

        while(durationCount < _duration)
        {
            if(Time.timeScale < float.Epsilon)
            {
                InputSystem.PauseHaptics();
            }
            else
            {
                InputSystem.ResumeHaptics();
            }

            durationCount += Time.deltaTime;
            yield return null;
        }

        InputSystem.ResetHaptics();
    }

    // �|�[�Y���͎��̃R�[���o�b�N
    private void PauseInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        pauseEvent.Invoke();
    }

    // ����͎��̃R�[���o�b�N
    private void UpInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        upEvent.Invoke();
    }

    // �����͎��̃R�[���o�b�N
    private void DownInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        downEvent.Invoke();
    }

    // ������͎��̃R�[���o�b�N
    private void DecideInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        decideEvent.Invoke();
    }
}
