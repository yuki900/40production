using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : AdvancedMonoBehaviour
{
    [SerializeField]
    private float destroyTime = 1.0f;

    private void Start()
    {
        Invoke(Destroy, gameObject, destroyTime);
    }
}
