using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSettingSlider : MonoBehaviour
{
    // �X���C�_�[�̍ŏ��l
    private const float SLIDER_MIN_VALUE = 0f;
    // �X���C�_�[�̍ő�l
    private const float SLIDER_MAX_VALUE = 100.0f;

    // �R���|�[�l���g
    private Slider slider;

    // ���삷�鐔�l
    [SerializeField]
    private AudioManager.AudioVolumeParam setParam;

    // ���x��
    [SerializeField]
    private TextMeshProUGUI labelTextMeshPro;

    // ���ʕ\���e�L�X�g
    [SerializeField]
    private TextMeshProUGUI volumeTextMeshPro;

    private void Start()
    {
        // �R���|�[�l���g�擾
        slider = GetComponent<Slider>();

        // ���x���̐ݒ�
        labelTextMeshPro.SetText(setParam.ToString());

        // �X���C�_�[�̐ݒ�
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
