using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� Ŭ����.
/// BGM�� SFX ���, ���� ����, ���� �ε带 ����մϴ�.
/// </summary>
public class SoundManager
{
    // PlayerPrefs�� ����� Ű ���
    const string BGM_VOLUME_KEY = "BGM_VOLUME";
    const string SFX_VOLUME_KEY = "SFX_VOLUME";
    const string BGM_ON_KEY = "BGM_ON";
    const string SFX_ON_KEY = "SFX_ON";

    // ���ҽ� ��� ����
    const string SOUND_RESOURCE_PATH_FORMAT = "Sounds/{0}";

    ResourceManager _resourceManager; // ���ҽ� �ε带 ���� ResourceManager
    AudioSource _bgmSource; // BGM ����� AudioSource
    List<AudioSource> _sfxSourceList; // SFX ����� AudioSource ����Ʈ
    int _sfxSourceCount = 10; // ���ÿ� ��� ������ SFX AudioSource�� ��

    public float BGMVolume { get; private set; } // BGM ����
    public float SFXVolume { get; private set; } // SFX ����
    public bool BGMOn { get; private set; } // BGM Ȱ��ȭ ����
    public bool SFXOn { get; private set; } // SFX Ȱ��ȭ ����

    /// <summary>
    /// SoundManager ������.
    /// </summary>
    /// <param name="resourceManager">���ҽ� �ε带 ���� ResourceManager</param>
    public SoundManager(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        Init();
    }

    /// <summary>
    /// �ʱ�ȭ �۾��� �����մϴ�.
    /// AudioSource�� �����ϰ� ������ �ε��մϴ�.
    /// </summary>
    void Init()
    {
        // BGM AudioSource ����
        GameObject bgmGo = new GameObject("BGM");
        GameObject.DontDestroyOnLoad(bgmGo);
        _bgmSource = bgmGo.AddComponent<AudioSource>();
        _bgmSource.spatialBlend = 0.0f; // 2D ����� ����

        // SFX AudioSource ����Ʈ �ʱ�ȭ
        _sfxSourceList = new List<AudioSource>();
        for (int i = 0; i < _sfxSourceCount; i++)
        {
            GameObject sfxGo = new GameObject($"SFX_{i}");
            GameObject.DontDestroyOnLoad(sfxGo);
            AudioSource sfxAs = sfxGo.AddComponent<AudioSource>();
            sfxAs.spatialBlend = 0.0f; // �⺻ 2D ����
            _sfxSourceList.Add(sfxAs);
        }

        // ���� �ε�
        LoadSettings();
    }

    /// <summary>
    /// ���� ������ �ε��մϴ�.
    /// </summary>
    private void LoadSettings()
    {
        BGMVolume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1.0f);
        SFXVolume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1.0f);
        BGMOn = PlayerPrefs.GetInt(BGM_ON_KEY, 1) == 1;
        SFXOn = PlayerPrefs.GetInt(SFX_ON_KEY, 1) == 1;

        _bgmSource.mute = !BGMOn;
        foreach (AudioSource sfxSource in _sfxSourceList)
        {
            sfxSource.mute = !SFXOn;
        }
    }

    /// <summary>
    /// BGM ������ �����մϴ�.
    /// </summary>
    /// <param name="volume">������ ���� �� (0.0 ~ 1.0)</param>
    public void SetBGMVolume(float volume)
    {
        BGMVolume = Mathf.Clamp01(volume);
        _bgmSource.volume = BGMVolume;
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, BGMVolume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// SFX ������ �����մϴ�.
    /// </summary>
    /// <param name="volume">������ ���� �� (0.0 ~ 1.0)</param>
    public void SetSFXVolume(float volume)
    {
        SFXVolume = Mathf.Clamp01(volume);
        foreach (AudioSource sfxSource in _sfxSourceList)
        {
            sfxSource.volume = SFXVolume;
        }
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, SFXVolume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// BGM Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    /// <param name="isOn">BGM Ȱ��ȭ ����</param>
    public void ToggleBGM(bool isOn)
    {
        BGMOn = isOn;
        _bgmSource.mute = !BGMOn;
        PlayerPrefs.SetInt(BGM_ON_KEY, BGMOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// SFX Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    /// <param name="isOn">SFX Ȱ��ȭ ����</param>
    public void ToggleSFX(bool isOn)
    {
        SFXOn = isOn;
        foreach (AudioSource sfxSource in _sfxSourceList)
        {
            sfxSource.mute = !SFXOn;
        }
        PlayerPrefs.SetInt(SFX_ON_KEY, SFXOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// ��θ� ���� BGM�� ����մϴ�.
    /// </summary>
    /// <param name="path">BGM ���� ���</param>
    public void PlayBGM(string path)
    {
        AudioClip clip = GetAudioClip(path);
        PlayBGM(clip);
    }

    /// <summary>
    /// �־��� AudioClip���� BGM�� ����մϴ�.
    /// </summary>
    /// <param name="clip">����� AudioClip</param>
    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.clip == clip)
            return;

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    /// <summary>
    /// BGM ����� �����մϴ�.
    /// </summary>
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    /// <summary>
    /// BGM ����� �Ͻ� �����մϴ�.
    /// </summary>
    public void PauseBGM()
    {
        _bgmSource.Pause();
    }

    /// <summary>
    /// BGM ����� �ٽ� �����մϴ�.
    /// </summary>
    public void UnPauseBGM()
    {
        _bgmSource.UnPause();
    }

    /// <summary>
    /// ��θ� ���� SFX�� ����մϴ�.
    /// </summary>
    /// <param name="path">SFX ���� ���</param>
    /// <param name="is3D">3D ���� ����</param>
    /// <param name="position">3D ���� ��ġ</param>
    public void PlaySFX(string path, bool is3D = false, Vector3 position = default)
    {
        AudioClip clip = GetAudioClip(path);
        PlaySFX(clip, is3D, position);
    }

    /// <summary>
    /// �־��� AudioClip���� SFX�� ����մϴ�.
    /// </summary>
    /// <param name="clip">����� AudioClip</param>
    /// <param name="is3D">3D ���� ����</param>
    /// <param name="position">3D ���� ��ġ</param>
    public void PlaySFX(AudioClip clip, bool is3D = false, Vector3 position = default)
    {
        if (!SFXOn) return;

        AudioSource availableSource = GetAvailableSFXSource();
        if (availableSource != null)
        {
            availableSource.clip = clip;
            availableSource.volume = SFXVolume;
            availableSource.spatialBlend = is3D ? 1.0f : 0.0f; // 3D ���� ����
            if (is3D)
            {
                availableSource.transform.position = position;
            }
            availableSource.Play();
        }
    }

    /// <summary>
    /// ��� ������ SFX AudioSource�� �����ɴϴ�.
    /// </summary>
    /// <returns>��� ������ AudioSource</returns>
    AudioSource GetAvailableSFXSource()
    {
        foreach (AudioSource source in _sfxSourceList)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return null;
    }

    /// <summary>
    /// ��θ� ���� AudioClip�� �ε��մϴ�.
    /// </summary>
    /// <param name="path">����� ���� ���</param>
    /// <returns>�ε�� AudioClip</returns>
    AudioClip GetAudioClip(string path)
    {
        return _resourceManager.LoadResource<AudioClip>(string.Format(SOUND_RESOURCE_PATH_FORMAT, path));
    }

    /// <summary>
    /// ��� BGM �� SFX ����� �����մϴ�.
    /// </summary>
    public void Clear()
    {
        _bgmSource.Stop();
        _bgmSource.clip = null;
        foreach (AudioSource audioSource in _sfxSourceList)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
    }
}