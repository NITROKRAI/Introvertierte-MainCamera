using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int totalWeapons;
    public int currentWeaponIndex;
    public GameObject[] weapons = new GameObject[0];
    public GameObject WeaponHolder;
    public GameObject currentWeapon;
    public Transform[] allchildren;
    public Image ReloadInHud;

    void Start()
    {
        WeaponInventory();
    }

    // Update is called once per frame
    void Update()
    {
        totalWeapons = WeaponHolder.transform.childCount;
        SelectWeapon();
        weapons = GameObject.FindGameObjectsWithTag("Equipped");
        currentWeapon = weapons[currentWeaponIndex].transform.gameObject;
    }
    void WeaponInventory()
    {

        for (int i = 0; i < weapons.Length; i++)
        {
            //weapons[i] = WeaponHolder.transform.GetChild(i).gameObject;
            //weapons[i] = GameObject.FindGameObjectsWithTag("Equipped");
           //weapons[i].SetActive(false);

        }
        currentWeaponIndex = 0;
    }
    void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentWeaponIndex < weapons.Length - 1)
            {
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
                {
                    ReloadInHud.fillAmount = 0;
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }
                currentWeaponIndex += 1;
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
                {
                    ReloadInHud.fillAmount = 0;
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(true);
                }

            }
            else
                {
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
                {
                    ReloadInHud.fillAmount = 0;
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                    child.SetActive(false);
                }
                currentWeaponIndex = 0;
                for (int i = 0; i < weapons[currentWeaponIndex].transform.childCount; i++)
                {
                    ReloadInHud.fillAmount = 0;
                    var child = weapons[currentWeaponIndex].transform.GetChild(i).gameObject;
                    if (child != null)
                    child.SetActive(true);
                }
            }
        }
    }

}
