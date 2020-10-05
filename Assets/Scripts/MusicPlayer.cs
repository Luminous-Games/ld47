using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public Button muteButton;
    public Button musicButton;
    public Sprite soundMute;
    public Sprite soundUnmute;
    public Sprite musicMute;
    public Sprite musicUnmute;
    AudioSource audio;

    float volume;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ToggleSound()
    {
        if (AudioListener.volume > 0)
        {
            volume = AudioListener.volume;
            AudioListener.volume = 0;
            muteButton.image.sprite = soundUnmute;
        }
        else
        {
            AudioListener.volume = volume;
            muteButton.image.sprite = soundMute;
        }
    }

    public void ToggleMusic()
    {
        if (audio.isPlaying)
        {
            audio.Pause();
            musicButton.image.sprite = musicUnmute;
        }
        else
        {
            audio.UnPause();
            musicButton.image.sprite = musicMute;
        }

    }
}
