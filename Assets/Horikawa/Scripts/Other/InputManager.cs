using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    /// <summary>
    /// ���擾
    /// </summary>
    public Vector2 GetAxis => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    /// <summary>
    /// ���擾(�������Ȃ�)
    /// </summary>
    public Vector2 GetAxisRaw => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

}
