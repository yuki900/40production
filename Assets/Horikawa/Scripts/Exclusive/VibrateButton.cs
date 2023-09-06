using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateButton : ButtonBase
{
    protected override void OnClick()
    {
        InputManager.Instance.Vibrate(1.0f);
    }
}