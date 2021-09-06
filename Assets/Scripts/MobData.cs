using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MobData : ScriptableObject
{
    public int Health;
    public float MovementSpeed;
    public float InvincibilityTimer;
    public bool IsInvincible;
    public bool DealsContactDamage;
    public float ContactDamage;
}
