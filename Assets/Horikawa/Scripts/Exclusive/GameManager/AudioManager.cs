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

    // セーブキーの共通文字列
    private const string VOLUME_VALUE_SAVE_KEY_BASE = "VolumeValueSave";

    // コンポーネント
    private AudioSource audioSource;

    // オーディオミキサー
    [SerializeField]
    private AudioMixer audioMixer;

    // SEの配列
    [SerializeField]
    private AudioClip[] audioClips;

    private void Start()
    {
        // コンポーネント取得
        audioSource = GetComponent<AudioSource>();

        //audioMixer.SetFloat(AudioVolumeParam.Master.ToString() + "Volume", ValueToDB(GetVolumeValue(AudioVolumeParam.Master)));
        //audioMixer.SetFloat(AudioVolumeParam.BGM.ToString() + "Volume", ValueToDB(GetVolumeValue(AudioVolumeParam.BGM)));
        //audioMixer.SetFloat(AudioVolumeParam.SE.ToString() + "Volume", ValueToDB(GetVolumeValue(AudioVolumeParam.SE)));
    }

    /// <summary>
    /// 値を反映、保存する
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_volumeParam"></param>
    public void SetVolumeValue(float _value, AudioVolumeParam _volumeParam)
    {
        Preference.Save(_value, _volumeParam.ToString() + VOLUME_VALUE_SAVE_KEY_BASE);

        // 値をdBに変換して反映
        float dB = ValueToDB(_value);
        audioMixer.SetFloat(_volumeParam.ToString() + "Volume", dB);
    }

    /// <summary>
    /// 保存した値を取得する
    /// </summary>
    /// <param name="_volumeParam"></param>
    /// <returns></returns>
    public float GetVolumeValue(AudioVolumeParam _volumeParam)
    {
        return Preference.Load(_volumeParam.ToString() + VOLUME_VALUE_SAVE_KEY_BASE, 1.0f);
    }

    /// <summary>
    /// 0.0～1.0の値をdBに変換
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
