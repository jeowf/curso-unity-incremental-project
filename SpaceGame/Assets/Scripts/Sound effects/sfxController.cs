using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxController : MonoBehaviour
{
    // Start is called before the first frame update
    public static sfxController SharedInstance;

    void Start()
    {
        GetComponent<AudioSource>().volume = VolumeController.sfxVolume;
        SharedInstance = this;
    }

    public void PlayClip(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    public void setVolume(float volume){
        GetComponent<AudioSource>().volume = volume;
    }
}
