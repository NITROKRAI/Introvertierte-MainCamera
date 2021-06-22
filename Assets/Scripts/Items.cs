using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EWeaponType
{
    Schwert,
    Hammer,
    Pistole,
    Shotgun,
    Empty
}
public abstract class Items : ScriptableObject
{
    public GameObject prefab;
    public EWeaponType type;
    public string name;
    public string description;
}