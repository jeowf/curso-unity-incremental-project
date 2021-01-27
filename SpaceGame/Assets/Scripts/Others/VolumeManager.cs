using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider musicSlider;

    void OnEnable()
    {
        LoadAudioPrefs();
    }

    void OnDisable()
    {
        SaveAudioPrefs();
    }

    public void SaveAudioPrefs()
    {
        VolumeController.MusicVolume = musicSlider.value;

        PlayerPrefs.SetFloat("music_vol", VolumeController.MusicVolume);
        PlayerPrefs.SetFloat("sfx_vol", VolumeController.sfxVolume);

        Debug.Log("Save" + VolumeController.MusicVolume);
    }

    public void LoadAudioPrefs()
    {
        VolumeController.MusicVolume = PlayerPrefs.GetFloat("music_vol");
        VolumeController.sfxVolume = PlayerPrefs.GetFloat("sfx_vol");

        musicSlider.value = VolumeController.MusicVolume;

        Debug.Log("Load" + VolumeController.MusicVolume);
    }
}
