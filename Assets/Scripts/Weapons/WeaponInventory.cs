using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponInventory : MonoBehaviour 
{
    public WeaponList<Weapon> weaponList = new WeaponList<Weapon>();

    



    void Start()
    {

    }

    
    void Update()
    {
        
    }

    private void TryTakeWeapon()
    {
        //AddWeaponToList(transform);
    }

    private void AddWeaponToList(Transform tra)
    {
        //weaponList.myList.Add(tra.GetComponent<Weapon>());
    }

}

public class WeaponList<T> where T : Weapon
{
    public List<T> myList = new List<T>();
}

