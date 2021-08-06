using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData Data;
    public abstract void Shoot();

    public abstract void Reload();
}
