using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public static float MusicVolume = PlayerPrefs.GetFloat("music_vol",1f);
    public static float sfxVolume = PlayerPrefs.GetFloat("sfx_vol", 1f);

}
