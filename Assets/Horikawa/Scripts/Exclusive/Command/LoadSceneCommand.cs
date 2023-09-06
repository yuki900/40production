using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : CommandBase
{
    // 読み込むシーン名
    [SerializeField]
    private string loadSceneName;

    protected override void OnDecide()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
