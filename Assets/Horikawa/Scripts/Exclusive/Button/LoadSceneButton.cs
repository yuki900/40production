using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : ButtonBase
{
    // 読み込むシーン名
    [SerializeField]
    private string loadSceneName;

    protected override void OnClick()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
