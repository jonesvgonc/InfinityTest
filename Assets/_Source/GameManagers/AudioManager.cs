using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private AudioSource _soundFXSource;
    [SerializeField]
    private AudioSource _musicSource;

    [SerializeField]
    private AudioClip _buttonClick;
    [SerializeField]
    private AudioClip _elletricSparks;
    [SerializeField]
    private AudioClip _commemoration;

    [SerializeField]
    private AudioClip _mainMenuMusic;
    [SerializeField]
    private AudioClip _inGameMusic;

    public void Awake()
    {
        Instance = this;
    }

    public void PlayButtonClick()
    {
        _soundFXSource.PlayOneShot(_buttonClick);
    }

    public void PlayElletricSparks()
    {
        _soundFXSource.PlayOneShot(_elletricSparks);
    }

    public void PlayCommemorations()
    {
        _soundFXSource.PlayOneShot(_commemoration);
    }

    public void PlayMainMenuMusic()
    {
        _musicSource.Stop();
        _musicSource.clip = _mainMenuMusic;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayInGameMusic()
    {
        _musicSource.Stop();
        _musicSource.clip = _inGameMusic;
        _musicSource.loop = true;
        _musicSource.Play();
    }
}
