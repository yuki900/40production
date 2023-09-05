using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    /// <summary>
    /// Ž²Žæ“¾
    /// </summary>
    public Vector2 GetAxis => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    /// <summary>
    /// Ž²Žæ“¾(•½ŠŠ‰»‚È‚µ)
    /// </summary>
    public Vector2 GetAxisRaw => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

}
