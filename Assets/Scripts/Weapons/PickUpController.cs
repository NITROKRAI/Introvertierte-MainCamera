using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    public Transform Player;
    public Transform WeaponHolderTra;
    public float PickUpRange;
    public WeaponSwitching Inv;
    public BasicWeapon WeaponScript;
    public GameObject Mesh;
    public WeaponData Data;
    public GameObject UI;
    public Text WeaponName;
    public Text WeaponDescription;
    public RawImage WeaponInfoBG;
    public bool PickedUpOnce = false;
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
        if (PickedUpOnce == false)
        {
            DisplayWeaponInfo();
        }
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
    private void DisplayWeaponInfo()
    {
        WeaponName.text = Data.WeaponName;
        WeaponDescription.text = Data.WeaponDescription;
        WeaponName.gameObject.SetActive(true); WeaponDescription.gameObject.SetActive(true);
        //LeanTween.scale(WeaponName.gameObject, new Vector3(1, 1, 1), 0.5f);
        //LeanTween.scale(WeaponDescription.gameObject, new Vector3(1, 1, 1), 0.5f);
        //LeanTween.scale(WeaponInfoBG.gameObject, new Vector3(4f, 2f, 1f), 0.5f);
        WeaponName.transform.LeanMoveLocal(new Vector2(0, -361), 2).setEaseOutQuart().setLoopPingPong(1);
        WeaponDescription.transform.LeanMoveLocal(new Vector2(0, -431), 2).setEaseOutQuart().setLoopPingPong(1);
        WeaponInfoBG.transform.LeanMoveLocal(new Vector2(0, -403), 2).setEaseOutQuart().setLoopPingPong(1);
        Invoke("DeactivateWeaponInfo", 3f);
        PickedUpOnce = true;     
    }
    private void DeactivateWeaponInfo()
    {
        //LeanTween.scale(WeaponName.gameObject, new Vector3(0, 0, 0), 0.5f);
        //LeanTween.scale(WeaponDescription.gameObject, new Vector3(0, 0, 0), 0.5f);
        //LeanTween.scale(WeaponInfoBG.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
    }
}
