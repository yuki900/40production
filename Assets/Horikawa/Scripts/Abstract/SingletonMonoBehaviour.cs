using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : AdvancedMonoBehaviour
    where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    Debug.LogError("Component \"" + typeof(T).Name + "\" is not found.");
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        // 他のGameObjectにアタッチされているか調べる
        if (this != Instance)
        {
            // アタッチされている場合は破棄する
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
