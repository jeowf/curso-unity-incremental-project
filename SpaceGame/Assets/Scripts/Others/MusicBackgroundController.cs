using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackgroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = VolumeController.MusicVolume;
        GetComponent<AudioSource>().Play();
    }

    public void setVolume(float volume){
        GetComponent<AudioSource>().volume = volume;
    }
}
