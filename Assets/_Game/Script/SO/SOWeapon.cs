using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Axe = 0,
    Knive = 1,
    Hammer = 2,
    Boomerang = 3
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SOWeapon", order = 1)]
public class SOWeapon : ScriptableObject
{
    [SerializeField] public WeaponItemData[] weapons;

    public WeaponItemData GetWeapon(WeaponType weaponType)
    {
        WeaponItemData weaponItemData = new WeaponItemData();
        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i].weaponType == weaponType)
            {
                weaponItemData = weapons[i];
                break;
            }
        }
        return weaponItemData;
    }
}
