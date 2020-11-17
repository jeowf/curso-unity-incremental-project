using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    public Vector2 speed;
    Renderer back;
    void Start()
    {
        back = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = speed * Time.deltaTime;

        back.material.mainTextureOffset += offset;
    }
}
