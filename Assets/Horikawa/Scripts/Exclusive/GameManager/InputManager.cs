using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    [SerializeField]
    private InputAction inputAction;

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
        Gamepad gamepad = Gamepad.current;

        gamepad?.SetMotorSpeeds(0.0f, 1.0f);
        Invoke(InputSystem.ResetHaptics, _duration);
    }

    /// <summary>
    /// コントローラー振動(強さ設定可能)
    /// </summary>
    /// <param name="_lowFrequency">強さ(低周波)</param>
    /// <param name="_highFrequency">強さ(高周波)</param>
    /// <param name="_duration">持続時間</param>
    public void Vibrate(float _duration, float _lowFrequency, float _highFrequency)
    {
        Gamepad gamepad = Gamepad.current;

        gamepad?.SetMotorSpeeds(_lowFrequency, _highFrequency);
        Invoke(InputSystem.ResetHaptics, _duration);
    }
}
