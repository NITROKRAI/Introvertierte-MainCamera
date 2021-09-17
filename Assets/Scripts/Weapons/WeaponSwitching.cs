using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int TotalWeapons;
    public int CurrentWeaponIndex;
    public GameObject[] Weapons = new GameObject[0];
    public GameObject WeaponHolder;
    public GameObject CurrentWeapon;
    public Transform[] AllChildren;
    public Image ReloadInHud;

    void Start()
    {
        WeaponInventory();
        TotalWeapons = WeaponHolder.transform.childCount;
        Weapons = GameObject.FindGameObjectsWithTag("Equipped");
        CurrentWeapon = Weapons[CurrentWeaponIndex].transform.gameObject;
        //if(CurrentWeapon.transform.childCount == 0)
        //{
        //    CurrentWeapon = WeaponHolder;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        SelectWeapon();
    }
    void WeaponInventory()
    {

        for (int i = 0; i < Weapons.Length; i++)
        {
            //weapons[i] = WeaponHolder.transform.GetChild(i).gameObject;
            //weapons[i] = GameObject.FindGameObjectsWithTag("Equipped");
           //weapons[i].SetActive(false);

        }
        CurrentWeaponIndex = 0;
    }
    void SelectWeapon()
    {
        if(Weapons.Length > 1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ReloadInHud.fillAmount = 0;
                if (CurrentWeaponIndex < Weapons.Length - 1)
                {
                    for (int i = 0; i < Weapons[CurrentWeaponIndex].transform.childCount; i++)
                    {
                        var child = Weapons[CurrentWeaponIndex].transform.GetChild(i).gameObject;
                        if (child != null)
                        child.SetActive(false);
                    }
                    CurrentWeaponIndex += 1;
                    CurrentWeapon = Weapons[CurrentWeaponIndex].transform.gameObject;
                    for (int i = 0; i < Weapons[CurrentWeaponIndex].transform.childCount; i++)
                    {
                        var child = Weapons[CurrentWeaponIndex].transform.GetChild(i).gameObject;
                        if (child != null)
                        child.SetActive(true);
                    }
                }
                else
                {
                    for (int i = 0; i < Weapons[CurrentWeaponIndex].transform.childCount; i++)
                    {
                        var child = Weapons[CurrentWeaponIndex].transform.GetChild(i).gameObject;
                        if (child != null)
                        child.SetActive(false);
                    }
                    CurrentWeaponIndex = 0;
                    CurrentWeapon = Weapons[CurrentWeaponIndex].transform.gameObject;
                    for (int i = 0; i < Weapons[CurrentWeaponIndex].transform.childCount; i++)
                    {
                        var child = Weapons[CurrentWeaponIndex].transform.GetChild(i).gameObject;
                        if (child != null)
                        child.SetActive(true);
                    }
                }
            }
        }
    }
}
