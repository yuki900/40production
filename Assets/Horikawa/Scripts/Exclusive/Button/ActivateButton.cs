using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : ButtonBase
{
    // 有効化するオブジェクト
    [SerializeField]
    private GameObject[] activateObjects;

    // 無効化するオブジェクト
    [SerializeField]
    private GameObject[] inactivateObjects;

    protected override void OnClick()
    {
        // 要素が0ならreturn
        if(activateObjects.Length <= 0
            && inactivateObjects.Length <= 0)
        {
            return;
        }

        foreach(GameObject targetObject in activateObjects)
        {
            targetObject.SetActive(true);
        }
        
        foreach (GameObject targetObject in inactivateObjects)
        {
            targetObject.SetActive(false);
        }
    }
}
