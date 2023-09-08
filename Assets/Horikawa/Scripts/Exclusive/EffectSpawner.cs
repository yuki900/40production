using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    private void Start()
    {
        InputManager.Instance.decideEvent.AddListener(Spawn);
    }

    private void Spawn()
    {
        Instantiate(effectPrefab, transform.position, transform.rotation);
    }
}
