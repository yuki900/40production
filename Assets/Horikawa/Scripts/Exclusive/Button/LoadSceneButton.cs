using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : ButtonBase
{
    // �ǂݍ��ރV�[����
    [SerializeField]
    private string loadSceneName;

    protected override void OnClick()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
