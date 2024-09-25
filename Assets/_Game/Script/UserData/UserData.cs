using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserData
{
    public string namePlayer;
    public int currentWeapon;
    public int gold;
    public List<int> idWeapon;

    public UserData()
    {
        this.namePlayer = "player";
        this.currentWeapon = 1;
        this.gold = 999;
        this.idWeapon = new List<int>();
    }  
    public UserData(string namePlayer, int gold, int weapon, List<int> idWeapon)
    {
        this.namePlayer = namePlayer;
        this.gold = gold;
        this.currentWeapon=weapon;
        this.idWeapon = idWeapon;
    }
}
