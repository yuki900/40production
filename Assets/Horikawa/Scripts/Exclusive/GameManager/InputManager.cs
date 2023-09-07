using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    // �������̓A�N�V����
    [SerializeField]
    private InputAction directionInputAction;
    // �������͎��̃C�x���g
    [HideInInspector]
    public UnityEvent<Vector2> directionEvent;

    // �|�[�Y���̓A�N�V����
    [SerializeField]
    private InputAction pauseInputAction;
    // �|�[�Y���͎��̃C�x���g
    [HideInInspector]
    public UnityEvent pauseEvent;

    // ������̓A�N�V����
    [SerializeField]
    private InputAction decideInputAction;
    // ������͎��̃C�x���g
    [HideInInspector]
    public UnityEvent decideEvent;

    // ��U�����̓A�N�V����
    [SerializeField]
    private InputAction weakAttackInputAction;
    // ��U�����͎��̃C�x���g
    [HideInInspector]
    public UnityEvent weakAttackEvent;


    // ���U�����̓A�N�V����
    [SerializeField]
    private InputAction strongAttackInputAction;
    // ���U�����͎��̃C�x���g
    [HideInInspector]
    public UnityEvent strongAttackEvent;

    private void OnEnable()
    {
        // ���̓A�N�V������L����
        directionInputAction.Enable();
        pauseInputAction.Enable();
        decideInputAction.Enable();
        weakAttackInputAction.Enable();
        strongAttackInputAction.Enable();

        // �R�[���o�b�N��ǉ�
        directionInputAction.performed      += DirectionInvoke;
        pauseInputAction.performed          += PauseInvoke;
        decideInputAction.performed         += DecideInvoke;
        weakAttackInputAction.performed     += WeakAttackInvoke;
        strongAttackInputAction.performed   += StrongAttackInvoke;

    }

    private void OnDisable()
    {
        // ���̓A�N�V�����𖳌���
        directionInputAction.Disable();
        pauseInputAction.Disable();
        decideInputAction.Disable();
        weakAttackInputAction.Disable();
        strongAttackInputAction.Disable();

        // �R�[���o�b�N���폜
        directionInputAction.performed      -= DirectionInvoke;
        pauseInputAction.performed          -= PauseInvoke;
        decideInputAction.performed         -= DecideInvoke;
        weakAttackInputAction.performed     -= WeakAttackInvoke;
        strongAttackInputAction.performed   -= StrongAttackInvoke;
    }

    /// <summary>
    /// ���擾(�������Ȃ��A���K������)
    /// </summary>
    public Vector2 GetAxis => getAxis;
    // �t�B�[���h
    private Vector2 getAxis = new();

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

    // �������͎��̃R�[���o�b�N
    private void DirectionInvoke(InputAction.CallbackContext _context)
    {
        Vector2 readVector = _context.ReadValue<Vector2>();

        // ���X�V
        getAxis = readVector;
        // �C�x���g���s
        directionEvent.Invoke(readVector);
    }

    // �|�[�Y���͎��̃R�[���o�b�N
    private void PauseInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        pauseEvent.Invoke();
    }

    // ������͎��̃R�[���o�b�N
    private void DecideInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        decideEvent.Invoke();
    }

    // ��U�����͎��̃R�[���o�b�N
    private void WeakAttackInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        weakAttackEvent.Invoke();
    }

    // ���U�����͎��̃R�[���o�b�N
    private void StrongAttackInvoke(InputAction.CallbackContext _context)
    {
        // �C�x���g���s
        strongAttackEvent.Invoke();
    }
}
