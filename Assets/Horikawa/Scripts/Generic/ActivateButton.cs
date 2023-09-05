using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : ButtonBase
{
    // �L��������I�u�W�F�N�g
    [SerializeField]
    private GameObject[] activateObjects;

    // ����������I�u�W�F�N�g
    [SerializeField]
    private GameObject[] inactivateObjects;

    protected override void OnClick()
    {
        // �v�f��0�Ȃ�return
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
