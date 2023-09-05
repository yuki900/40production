using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSettingSlider : MonoBehaviour
{
    // スライダーの最小値
    private const float SLIDER_MIN_VALUE = 0f;
    // スライダーの最大値
    private const float SLIDER_MAX_VALUE = 100.0f;

    // コンポーネント
    private Slider slider;

    // 操作する数値
    [SerializeField]
    private AudioManager.AudioVolumeParam setParam;

    // ラベル
    [SerializeField]
    private TextMeshProUGUI labelTextMeshPro;

    // 音量表示テキスト
    [SerializeField]
    private TextMeshProUGUI volumeTextMeshPro;

    private void Start()
    {
        // コンポーネント取得
        slider = GetComponent<Slider>();

        // ラベルの設定
        labelTextMeshPro.SetText(setParam.ToString());

        // スライダーの設定
        slider.minValue = SLIDER_MIN_VALUE;
        slider.maxValue = SLIDER_MAX_VALUE;
        slider.wholeNumbers = true;
        slider.onValueChanged.AddListener(OnValueChanged);

        slider.value = AudioManager.Instance.GetVolumeValue(setParam) * SLIDER_MAX_VALUE;
        //Debug.Log(AudioManager.Instance.GetVolumeValue(setParam) * SLIDER_MAX_VALUE);
    }

    private void OnValueChanged(float _value)
    {
        float sliderValue = _value / SLIDER_MAX_VALUE;
        AudioManager.Instance.SetVolumeValue(sliderValue, setParam);

        if(volumeTextMeshPro != null)
        {
            volumeTextMeshPro.SetText((sliderValue * 100).ToString() + "%");
        }
    }
}
