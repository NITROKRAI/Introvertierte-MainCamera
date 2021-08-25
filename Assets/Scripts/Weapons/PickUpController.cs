using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform player;
    public Transform WeaponHolderTra;
    public float pickUpRange;
    public float throwForceForward;
    public float throwForceUpward;
    public WeaponSwitching Inv;
    public BasicWeapon WeaponScript;
    public GameObject Mesh;
    // Start is called before the first frame update
    void Start()
    {
        if (Inv.currentWeapon == WeaponHolderTra.gameObject)
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
        if(Inv.currentWeapon == WeaponHolderTra.gameObject)
        {
            WeaponScript.enabled = true;
            Mesh.SetActive(true);
        }
        else
        {
            WeaponScript.enabled = false;
        }
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
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
    }
}
