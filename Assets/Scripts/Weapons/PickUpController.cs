using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform player;
    public Transform WeaponHolderTra;
    public float pickUpRange;
    public Rigidbody rb;
    public BoxCollider coll;
    public float throwForceForward;
    public float throwForceUpward;
    public WeaponSwitching Inv;
    public Transform WeaponHolderSpecific;

    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
        coll.isTrigger = true;
        if(transform.parent == WeaponHolderSpecific)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
        else
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
        if (Inv.currentWeapon != null && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }

    }
    public void PickUp()
    {
        transform.SetParent(WeaponHolderTra);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.parent.tag = "Equipped";
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    public void Drop()
    {
        transform.parent.tag = "Not Equipped";
        transform.SetParent(null);
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(WeaponHolderTra.forward * throwForceForward, ForceMode.Impulse);
        rb.AddForce(WeaponHolderTra.up * throwForceUpward, ForceMode.Impulse);
        rb.isKinematic = false;
        coll.isTrigger = false;
        if (Inv.currentWeaponIndex < Inv.weapons.Length - 1)
        {
            //weapons[currentWeaponIndex].SetActive(false);
            for (int i = 0; i < Inv.weapons[Inv.currentWeaponIndex].transform.childCount; i++)
            {
                var child = Inv.weapons[Inv.currentWeaponIndex].transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }
            Inv.currentWeaponIndex += 1;
            //weapons[currentWeaponIndex].SetActive(true);
            for (int i = 0; i < Inv.weapons[Inv.currentWeaponIndex].transform.childCount; i++)
            {
                var child = Inv.weapons[Inv.currentWeaponIndex].transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < Inv.weapons[Inv.currentWeaponIndex].transform.childCount; i++)
            {
                var child = Inv.weapons[Inv.currentWeaponIndex].transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }
            Inv.currentWeaponIndex = 0;
            for (int i = 0; i < Inv.weapons[Inv.currentWeaponIndex].transform.childCount; i++)
            {
                var child = Inv.weapons[Inv.currentWeaponIndex].transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(true);
            }
        }
    }
}
