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
    [SerializeField] private WeaponItemData[] weapons;

    public WeaponItemData GetWeapon(WeaponType weaponType, int id)
    {
        WeaponItemData weaponItemData = new WeaponItemData();
        return weaponItemData;
    }
}
