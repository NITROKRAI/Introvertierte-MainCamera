using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponData : ScriptableObject
{
    public float FireRate;
    float TimeTillNextShot;
    public float Damage;
    public float Ammo;
    public float ReloadTime;
    public float Spread;
    public bool NeedsToBeCharged;
    public bool InfiniteAmmo;
}
