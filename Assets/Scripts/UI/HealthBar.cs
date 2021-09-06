using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private MobData playerData;
    private PlayerStats playerStats;
    public Slider Slider;

    private void Start()
    {
        //playerData = FindObjectOfType<MobData>();
        playerStats = FindObjectOfType<PlayerStats>();
        SetMaxHealth(playerData.Health);
    }

    private void Update()
    {
        SetHealth(playerStats.CurrentHealth);
    }

    public void SetHealth(float health)
    {
        Slider.value = health;
    }

    public void SetMaxHealth(float maxHealth)
    {
        Slider.maxValue = maxHealth;
        Slider.value = maxHealth;
    }
}
