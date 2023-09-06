using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
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
        pauseInputAction.Enable();
        upInputAction.Enable();
        downInputAction.Enable();
        decideInputAction.Enable();

        // コールバックを追加
        pauseInputAction.performed  += PauseInvoke;
        upInputAction.performed     += UpInvoke;
        downInputAction.performed   += DownInvoke;
        decideInputAction.performed += DecideInvoke;
    }

    /// <summary>
    /// 軸取得
    /// </summary>
    public Vector2 GetAxis => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    /// <summary>
    /// 軸取得(平滑化なし)
    /// </summary>
    public Vector2 GetAxisRaw => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

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
