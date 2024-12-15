using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager
{
    const string BGM_VOLUME_KEY = "BGM_VOLUME";
    const string SFX_VOLUME_KEY = "SFX_VOLUME";
    const string BGM_ON_KEY = "BGM_ON";
    const string SFX_ON_KEY = "SFX_ON";

    const string SOUND_RESOURCE_PATH_FORMAT = "Sounds/{0}";

    ResourceManager _resourceManager;

    AudioSource _bgmSource;
    List<AudioSource> _sfxSourceList;
    int _sfxSourceCount = 10; // 동시 재생 가능한 SFX AudioSource의 수

    public float BGMVolume { get; private set; }
    public float SFXVolume { get; private set; }
    public bool BGMOn { get; private set; }
    public bool SFXOn { get; private set; }

    public SoundManager(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;

        Init();
    }
    void Init()
    {
        GameObject bgmGo = new GameObject("BGM");
        GameObject.DontDestroyOnLoad(bgmGo);

        _bgmSource = bgmGo.AddComponent<AudioSource>();
        _bgmSource.spatialBlend = 0.0f; // 2D 사운드로 설정

        _sfxSourceList = new List<AudioSource>();

        GameObject sfxGo = null;
        AudioSource sfxAs = null;
        for (int i = 0; i < _sfxSourceCount; i++)
        {
            sfxGo = new GameObject($"SFX_{i}");
            GameObject.DontDestroyOnLoad(sfxGo);
            sfxAs = sfxGo.AddComponent<AudioSource>();
            sfxAs.spatialBlend = 0.0f; // 기본 2D 사운드로 설정
            _sfxSourceList.Add(sfxAs);
        }
        LoadSettings();
    }

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

    public void SetBGMVolume(float volume)
    {
        BGMVolume = Mathf.Clamp01(volume);
        _bgmSource.volume = BGMVolume;
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, BGMVolume);
        PlayerPrefs.Save();
    }

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

    public void ToggleBGM(bool isOn)
    {
        BGMOn = isOn;
        _bgmSource.mute = !BGMOn;
        PlayerPrefs.SetInt(BGM_ON_KEY, BGMOn ? 1 : 0);
        PlayerPrefs.Save();
    }

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

    public void PlayBGM(string path)
    {
        AudioClip clip = GetAudioClip(path);
        PlayBGM(clip);
    }
    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.clip == clip)
            return;

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
    }
    public void PauseBGM()
    {
        _bgmSource.Pause();
    }
    public void UnPauseBGM()
    {
        _bgmSource.UnPause();
    }

    public void PlaySFX(string path, bool is3D = false, Vector3 position = default)
    {
        AudioClip clip = GetAudioClip(path);
        PlaySFX(clip, is3D, position);
    }
    public void PlaySFX(AudioClip clip, bool is3D = false, Vector3 position = default)
    {
        if (!SFXOn) return;

        AudioSource availableSource = GetAvailableSFXSource();
        if (availableSource != null)
        {
            availableSource.clip = clip;
            availableSource.volume = SFXVolume;
            availableSource.spatialBlend = is3D ? 1.0f : 0.0f; // 3D 사운드 여부에 따라 설정
            if (is3D)
            {
                availableSource.transform.position = position;
            }
            availableSource.Play();
        }
    }

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
    AudioClip GetAudioClip(string path)
    {
        return _resourceManager.LoadResource<AudioClip>(string.Format(SOUND_RESOURCE_PATH_FORMAT, path));
    }

    public void Clear()
    {
        _bgmSource.Stop();
        _bgmSource.clip = null;
        foreach(AudioSource audioSource in _sfxSourceList)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
    }
}
