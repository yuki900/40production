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
    public UnityEvent directionEvent;

    // ポーズ入力アクション
    [SerializeField]
    private InputAction pauseInputAction;
    // ポーズ入力時のイベント
    [HideInInspector]
    public UnityEvent pauseEvent;

    // 上入力アクション
    [SerializeField]
    private InputAction upInputAction;
    // ポーズ入力時のイベント
    [HideInInspector]
    public UnityEvent upEvent;

    // 下入力アクション
    [SerializeField]
    private InputAction downInputAction;
    // ポーズ入力時のイベント
    [HideInInspector]
    public UnityEvent downEvent;

    // 決定入力アクション
    [SerializeField]
    private InputAction decideInputAction;
    // 決定入力時のイベント
    [HideInInspector]
    public UnityEvent decideEvent;

    private void OnEnable()
    {
        // 入力アクションを有効化
        directionInputAction.Enable();
        pauseInputAction.Enable();
        upInputAction.Enable();
        downInputAction.Enable();
        decideInputAction.Enable();

        // コールバックを追加
        directionInputAction.performed += DirectionInvoke;
        pauseInputAction.performed  += PauseInvoke;
        upInputAction.performed     += UpInvoke;
        downInputAction.performed   += DownInvoke;
        decideInputAction.performed += DecideInvoke;
    }

    private void OnDisable()
    {
        // 入力アクションを無効化
        directionInputAction.Disable();
        pauseInputAction.Disable();
        upInputAction.Disable();
        downInputAction.Disable();
        decideInputAction.Disable();

        // コールバックを削除
        pauseInputAction.performed  -= PauseInvoke;
        upInputAction.performed     -= UpInvoke;
        downInputAction.performed   -= DownInvoke;
        decideInputAction.performed -= DecideInvoke;
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// 軸取得(平滑化なし)
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

    private void DirectionInvoke(InputAction.CallbackContext _context)
    {
        // 軸更新
        getAxis = _context.ReadValue<Vector2>();
    }

    // ポーズ入力時のコールバック
    private void PauseInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        pauseEvent.Invoke();
    }

    // 上入力時のコールバック
    private void UpInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        upEvent.Invoke();
    }

    // 下入力時のコールバック
    private void DownInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        downEvent.Invoke();
    }

    // 決定入力時のコールバック
    private void DecideInvoke(InputAction.CallbackContext _context)
    {
        // イベント実行
        decideEvent.Invoke();
    }
}
