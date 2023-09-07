using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    // 方向入力アクション
    [SerializeField]
    private InputAction directionInputAction;
    // 方向入力時のイベント
    [HideInInspector]
    public UnityEvent<Vector2> directionEvent;

    // ポーズ入力アクション
    [SerializeField]
    private InputAction pauseInputAction;
    // ポーズ入力時のイベント
    [HideInInspector]
    public UnityEvent pauseEvent;

    // 決定入力アクション
    [SerializeField]
    private InputAction decideInputAction;
    // 決定入力時のイベント
    [HideInInspector]
    public UnityEvent decideEvent;

    // 弱攻撃入力アクション
    [SerializeField]
    private InputAction weakAttackInputAction;
    // 弱攻撃入力時のイベント
    [HideInInspector]
    public UnityEvent weakAttackEvent;


    // 強攻撃入力アクション
    [SerializeField]
    private InputAction strongAttackInputAction;
    // 強攻撃入力時のイベント
    [HideInInspector]
    public UnityEvent strongAttackEvent;

    private void OnEnable()
    {
        // 入力アクションを有効化
        directionInputAction.Enable();
        pauseInputAction.Enable();
        decideInputAction.Enable();
        weakAttackInputAction.Enable();
        strongAttackInputAction.Enable();

        // コールバックを追加
        directionInputAction.performed      += DirectionInvoke;
        pauseInputAction.performed          += PauseInvoke;
        decideInputAction.performed         += DecideInvoke;
        weakAttackInputAction.performed     += WeakAttackInvoke;
        strongAttackInputAction.performed   += StrongAttackInvoke;

    }

    private void OnDisable()
    {
        // 入力アクションを無効化
        directionInputAction.Disable();
        pauseInputAction.Disable();
        decideInputAction.Disable();
        weakAttackInputAction.Disable();
        strongAttackInputAction.Disable();

        // コールバックを削除
        directionInputAction.performed      -= DirectionInvoke;
        pauseInputAction.performed          -= PauseInvoke;
        decideInputAction.performed         -= DecideInvoke;
        weakAttackInputAction.performed     -= WeakAttackInvoke;
        strongAttackInputAction.performed   -= StrongAttackInvoke;
    }

    /// <summary>
    /// 軸取得(平滑化なし、正規化あり)
    /// </summary>
    public Vector2 GetAxis => getAxis;
    // フィールド
    private Vector2 getAxis = new();

    /// <summary>
    /// コントローラー振動
    /// </summary>
    /// <param name="_duration">持続時間</param>
    public void Vibrate(float _duration)
    {
        Vibrate(_duration, 0.0f, 1.0f);
    }

    /// <summary>
    /// コントローラー振動(強さ設定可能)
    /// </summary>
    /// <param name="_lowFrequency">強さ(低周波)</param>
    /// <param name="_highFrequency">強さ(高周波)</param>
    /// <param name="_duration">持続時間</param>
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

    // 方向入力時のコールバック
    private void DirectionInvoke(InputAction.CallbackContext _context)
    {
        Vector2 readVector = _context.ReadValue<Vector2>();

        // 軸更新
        getAxis = readVector;
        // イベント実行
        directionEvent.Invoke(readVector);
    }

    // ポーズ入力時のコールバック
    private void PauseInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        pauseEvent.Invoke();
    }

    // 決定入力時のコールバック
    private void DecideInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        decideEvent.Invoke();
    }

    // 弱攻撃入力時のコールバック
    private void WeakAttackInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        weakAttackEvent.Invoke();
    }

    // 強攻撃入力時のコールバック
    private void StrongAttackInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        strongAttackEvent.Invoke();
    }
}
