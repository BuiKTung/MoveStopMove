using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponItemData
{
    public static int nextId;
    [SerializeField] private int id;
    public int Id { get => id; private set => id = value; }
    public GameObject prefabWeapon;
    public WeaponType weaponType;
    public int price;
    public WeaponItemData()
    {
        Id = nextId;
        nextId++;
    }

}
