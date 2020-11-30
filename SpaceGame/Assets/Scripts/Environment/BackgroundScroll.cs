using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    [Serializable]
    public class BackgroundImageScroll
    {
        public GameObject backgroundImage;
        public float speed;
    }

    public PlayerCharacter player;
    public BackgroundImageScroll[] backgroundImages;
    

    void Start()
    {

        //back = GetComponent<Renderer>();
        //nomeBack = this.gameObject.tag;

    }

    void Update()
    {
        

        foreach(BackgroundImageScroll bg in backgroundImages)
        {
            Vector2 offset = new Vector2(bg.speed * Time.deltaTime * player.GetPlayerVelocity(), 0);
            Renderer back = bg.backgroundImage.GetComponent<Renderer>();
            back.material.mainTextureOffset += offset;
        }


        

        

    }
}