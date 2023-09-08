using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using K_Librarys;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public enum AudioVolumeParam
    {
        Master,
        BGM,
        SE,
    }

    public enum SE
    {
        CommandDecide,
    }

    // �Z�[�u�L�[�̋��ʕ�����
    private const string VOLUME_VALUE_SAVE_KEY_BASE = "VolumeValueSave";

    // �R���|�[�l���g
    private AudioSource audioSource;

    // �I�[�f�B�I�~�L�T�[
    [SerializeField]
    private AudioMixer audioMixer;

    // SE�̔z��
    [SerializeField]
    private AudioClip[] audioClips;

    private void Start()
    {
        // �R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        //audioMixer.SetFloat(AudioVolumeParam.Master.ToString() + "Volume", ValueToDB(GetVolumeValue(AudioVolumeParam.Master)));
        //audioMixer.SetFloat(AudioVolumeParam.BGM.ToString() + "Volume", ValueToDB(GetVolumeValue(AudioVolumeParam.BGM)));
        //audioMixer.SetFloat(AudioVolumeParam.SE.ToString() + "Volume", ValueToDB(GetVolumeValue(AudioVolumeParam.SE)));
    }

    /// <summary>
    /// �l�𔽉f�A�ۑ�����
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_volumeParam"></param>
    public void SetVolumeValue(float _value, AudioVolumeParam _volumeParam)
    {
        Preference.Save(_value, _volumeParam.ToString() + VOLUME_VALUE_SAVE_KEY_BASE);

        // �l��dB�ɕϊ����Ĕ��f
        float dB = ValueToDB(_value);
        audioMixer.SetFloat(_volumeParam.ToString() + "Volume", dB);
    }

    /// <summary>
    /// �ۑ������l���擾����
    /// </summary>
    /// <param name="_volumeParam"></param>
    /// <returns></returns>
    public float GetVolumeValue(AudioVolumeParam _volumeParam)
    {
        return Preference.Load(_volumeParam.ToString() + VOLUME_VALUE_SAVE_KEY_BASE, 1.0f);
    }

    /// <summary>
    /// 0.0�`1.0�̒l��dB�ɕϊ�
    /// </summary>
    /// <param name="_value"></param>
    /// <returns></returns>
    private static float ValueToDB(float _value)
    {
        return Mathf.Clamp(Mathf.Log10(_value) * 20f, -80f, 0f);
    }

    public void PlayOneShot(SE _se)
    {
        audioSource.PlayOneShot(audioClips[(int)_se]);
    }
}
