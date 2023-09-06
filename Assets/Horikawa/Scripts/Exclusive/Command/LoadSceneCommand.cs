using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : CommandBase
{
    // ì«Ç›çûÇﬁÉVÅ[Éìñº
    [SerializeField]
    private string loadSceneName;

    protected override void OnDecide()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
