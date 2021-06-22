using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Pistol", menuName = "Items/Weapons/Pistol")]
public class PistolenTemplate : Items
{
   void Awake() 
   {
       type = EWeaponType.Pistole;
   }
}
