using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : CommandBase
{
    // �ǂݍ��ރV�[����
    [SerializeField]
    private string loadSceneName;

    protected override void OnDecide()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
