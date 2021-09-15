using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageParticle : MonoBehaviour
{
    public MobData Data;
    private void OnParticleCollision(GameObject other)
    {
        if (Data.IsInvincible == false)
        {
            other.GetComponent<PlayerStats>().TakeDamage();
        }
    }
}
