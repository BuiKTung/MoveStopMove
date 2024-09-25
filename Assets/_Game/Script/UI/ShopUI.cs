using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : UICanvas
{
    [SerializeField] public GameObject[] pageWeapon;
    [SerializeField] public Button nextButton;
    [SerializeField] public Button backButton;
    [SerializeField] public TextMeshProUGUI goldOfPlayer;
    [SerializeField] public TextMeshProUGUI priceWeapon;
    [SerializeField] public TextMeshProUGUI nameWeapon;
    [SerializeField] public TextMeshProUGUI used;
    [SerializeField] public SOWeapon weaponData;
    [SerializeField] public Transform boxShow;
    private bool fisrtBuy;
    private Weapon weapon;

    private int thisImage = 0;
    

    private void Start()
    {
        nextButton.onClick.AddListener(NextButton);
        backButton.onClick.AddListener(BackButton);
        goldOfPlayer.text = DataManager.Ins.userData.gold.ToString();
        fisrtBuy = true;
        used.gameObject.SetActive(false);
        weapon = HBPool.Spawn<Weapon>((PoolType)weaponData.weapons[thisImage + 1].WeaponShowType, boxShow.position, Quaternion.Euler(0,0,142));
        weapon.transform.SetParent(boxShow.transform,false);
    }
    public void ChangeImage(int nextStep)
    {
        //if (weapon != null)
        //{
        //    HBPool.Despawn(weapon);
        //}
        ////pageWeapon[thisImage].SetActive(false);
        //thisImage += nextStep;
        //if(thisImage >= 0 && thisImage < weaponData.weapons.Length - 1)
        //{
        //    //pageWeapon[thisImage].SetActive(true);
        //    weapon = HBPool.Spawn<Weapon>((PoolType)weaponData.weapons[thisImage + 1].WeaponShowType, boxShow.position, Quaternion.Euler(0, 0, 142));
        //    weapon.transform.SetParent(boxShow.transform,false);
        //}
        //else
        //{
        //    thisImage -= nextStep;
        //    //pageWeapon[thisImage].SetActive(true);
        //    weapon = HBPool.Spawn<Weapon>((PoolType)weaponData.weapons[thisImage + 1].WeaponShowType, boxShow.position, Quaternion.Euler(0, 0, 142));
        //    weapon.transform.SetParent(boxShow.transform, false);
        //}
        if (weapon != null)
        {
            HBPool.Despawn(weapon);
        }
        if (nextStep > 0)
        {
            thisImage = thisImage + nextStep >= weaponData.weapons.Length - 1 ? 0 : thisImage += nextStep;
        }
        else
        {
            thisImage = thisImage + nextStep < 0 ? weaponData.weapons.Length - 1 -1 : thisImage += nextStep;
        }
        weapon = HBPool.Spawn<Weapon>((PoolType)weaponData.weapons[thisImage + 1].WeaponShowType, boxShow.position, Quaternion.Euler(0, 0, 142));
        weapon.transform.SetParent(boxShow.transform, false);
    }
    private void Update()
    {
        
        if(weaponData.weapons[thisImage + 1].Id == DataManager.Ins.userData.currentWeapon && !fisrtBuy)
            used.gameObject.SetActive(true);
        else
            used.gameObject.SetActive(false);
        if (DataManager.Ins.userData.idWeapon.Contains(weaponData.weapons[thisImage + 1].Id))
        {
            priceWeapon.text = "0";
        }
        else
            priceWeapon.text = weaponData.weapons[thisImage + 1].price.ToString();
        nameWeapon.text = weaponData.weapons[thisImage + 1].Name;
    }
    public void BuyButton()
    {
        if (DataManager.Ins.userData.gold >= weaponData.weapons[thisImage + 1].price && !DataManager.Ins.userData.idWeapon.Contains(weaponData.weapons[thisImage + 1].Id))
        {
            DataManager.Ins.SetGold(-weaponData.weapons[thisImage + 1].price);
            DataManager.Ins.SetWeapon(weaponData.weapons[thisImage + 1].weaponType);
            DataManager.Ins.userData.idWeapon.Add(weaponData.weapons[thisImage + 1].Id);
            DataManager.Ins.userData.currentWeapon = weaponData.weapons[thisImage + 1].Id;
            weaponData.weapons[thisImage + 1].price = 0;
            goldOfPlayer.text = DataManager.Ins.userData.gold.ToString();
            used.gameObject.SetActive(true);
            fisrtBuy = false;
        }
        else 
        {
            DataManager.Ins.SetWeapon(weaponData.weapons[thisImage + 1].weaponType);
            DataManager.Ins.userData.currentWeapon = weaponData.weapons[thisImage + 1].Id; 
            used.gameObject.SetActive(true);
        }
    }
    public void NextButton()
    {
        ChangeImage(1);
    }
    public void BackButton()
    {
        ChangeImage(-1);
    }
    
}
