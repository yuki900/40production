using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    // �X�R�A�L�^
    public int score;

    private void Start()
    {
        Resources.UnloadUnusedAssets();
    }

    /// <summary>
    /// �Q�[���I��
    /// </summary>
    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
