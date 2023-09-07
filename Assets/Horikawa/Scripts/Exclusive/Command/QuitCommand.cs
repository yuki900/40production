using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCommand : CommandBase
{
    protected override void OnDecide()
    {
        GameManager.Quit();
    }
}
