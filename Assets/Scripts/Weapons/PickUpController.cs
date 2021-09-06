using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform Player;
    public Transform WeaponHolderTra;
    public float PickUpRange;
    public WeaponSwitching Inv;
    public BasicWeapon WeaponScript;
    public GameObject Mesh;
    // Start is called before the first frame update
    void Start()
    {
        if (Inv.CurrentWeapon == WeaponHolderTra.gameObject)
        {
            WeaponScript.enabled = true;
            Mesh.SetActive(true);
        }
        else
        {
            WeaponScript.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Inv.CurrentWeapon == WeaponHolderTra.gameObject)
        {
            WeaponScript.enabled = true;
            Mesh.SetActive(true);
        }
        else
        {
            WeaponScript.enabled = false;
        }
        Vector3 distanceToPlayer = Player.position - transform.position;
        if (distanceToPlayer.magnitude <= PickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }
    public void PickUp()
    {
        transform.SetParent(WeaponHolderTra);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.parent.tag = "Equipped";
        Mesh.SetActive(false);
        Inv.Weapons = GameObject.FindGameObjectsWithTag("Equipped");
        for (int i = 0; i < Inv.Weapons[Inv.CurrentWeaponIndex].transform.childCount; i++)
        {
            Inv.ReloadInHud.fillAmount = 0;
            var child = Inv.Weapons[Inv.CurrentWeaponIndex].transform.GetChild(i).gameObject;
            if (child != null)
            child.SetActive(false);
        }
        Inv.CurrentWeaponIndex = Inv.Weapons.Length - 1;
        Inv.CurrentWeapon = Inv.Weapons[Inv.CurrentWeaponIndex].transform.gameObject;
        for (int i = 0; i < Inv.Weapons[Inv.CurrentWeaponIndex].transform.childCount; i++)
        {
            var child = Inv.Weapons[Inv.CurrentWeaponIndex].transform.GetChild(i).gameObject;
            if (child != null)
            child.SetActive(true);

        }
    }
}
