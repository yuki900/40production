using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    // �X�R�A�L�^
    public int score = 74;

    private void Start()
    {
        Resources.UnloadUnusedAssets();
    }

    /// <summary>
    /// �Q�[���I��
    /// </summary>
    public static void Quit()
    {
//#if UNITY_EDITOR
#if false
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
