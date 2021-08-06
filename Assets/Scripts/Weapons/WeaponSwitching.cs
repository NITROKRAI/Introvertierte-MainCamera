using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int totalWeapons;
    public int currentWeaponIndex;
    public GameObject[] weapons = new GameObject[0];
    public GameObject WeaponHolder;
    public GameObject currentWeapon;
    public Transform[] allchildren;

    void Start()
    {
        WeaponInventory();
        //GameObject[] allchildren = this.transform.GetComponentsInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        totalWeapons = WeaponHolder.transform.childCount;
        SelectWeapon();
        //Transform[] allchildren = this.transform.GetComponentsInChildren<Transform>();
        weapons = GameObject.FindGameObjectsWithTag("Equipped");
        currentWeapon = weapons[currentWeaponIndex].transform.gameObject;
    }
    void WeaponInventory()
    {
        //totalWeapons = WeaponHolder.transform.childCount;
        //totalWeapons = 4;
        //weapons = GameObject.FindGameObjectsWithTag("Equipped");

        for (int i = 0; i < weapons.Length; i++)
        {
            //weapons[i] = WeaponHolder.transform.GetChild(i).gameObject;
            //weapons[i] = GameObject.FindGameObjectsWithTag("Equipped");
           //weapons[i].SetActive(false);

        }
        //weapons[0].SetActive(true);
        //currentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }
    void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentWeaponIndex < weapons.Length - 1)
            {
                //weapons[currentWeaponIndex].SetActive(false);
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
                {
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }
                currentWeaponIndex += 1;
                //weapons[currentWeaponIndex].SetActive(true);
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
                {
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
               {
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }
                currentWeaponIndex = 0;
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
                {
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(true);
                }
            }
        }
    }

}
