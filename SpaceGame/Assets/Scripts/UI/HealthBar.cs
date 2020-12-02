using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public PlayerShip player;

    void Awake()
    {
        slider.maxValue = player.health;
        slider.value = player.health;
    }

    private void OnEnable()
    {
        player.updateHPBar += SetHealth;
    }


    private void OnDisable()
    {
        player.updateHPBar -= SetHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
