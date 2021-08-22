using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private MobData playerData;
    private PlayerStats playerStats;
    public Slider slider;

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
        slider.value = health;
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
}
