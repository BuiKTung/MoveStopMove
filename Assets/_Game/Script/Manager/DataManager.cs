using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private string playerName;
    public UserData userData = new UserData();

    private void Start()
    {
        userData = LoadPlayerData(playerName);
        //userData.gold = 999;
    }
    public void SetWeapon(WeaponType weaponType)
    {
        userData.currentWeapon = (int)weaponType;
    }
    public void SetGold(int golds)
    {
        userData.gold += golds;
    }
    public void SavePlayerData(string userName)
    {
        string jsonData = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString(userName, jsonData);
        PlayerPrefs.Save();
    }

    public UserData LoadPlayerData(string userName)
    {
        string jsonData = PlayerPrefs.GetString(userName, ""); 
        if (string.IsNullOrEmpty(jsonData))
        {
            return new UserData();
        }
        return JsonUtility.FromJson<UserData>(jsonData); 
    }
    
        //----chua thay hop ly 
    
    //tao user --> su dung cho cac muc dich khac --> load lai khi ket thuc 
}
