using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenuController : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        setVolume(1f);
    }
    
    public void setVolume(float volume){
        GetComponent<AudioSource>().volume = volume;
        VolumeController.MusicVolume = volume;
    }
}
