using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Gauge : MonoBehaviour
{
    private float value = 0f;
    public float Value
    {
        get 
        { 
            return value; 
        }
        set 
        {
            this.value = Mathf.Clamp01(value);
        }
    }

    // ÉQÅ[ÉWó Çï\Ç∑âÊëú
    [SerializeField]
    private Image fillImage;

    private void Update()
    {
        fillImage.fillAmount = value;
    }
}
