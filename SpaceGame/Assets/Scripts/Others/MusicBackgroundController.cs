using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackgroundController : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        setVolume(VolumeController.MusicVolume);
    }

    public void setVolume(float volume){
        GetComponent<AudioSource>().volume = volume;
    }
    // Update is called once per frame
}
