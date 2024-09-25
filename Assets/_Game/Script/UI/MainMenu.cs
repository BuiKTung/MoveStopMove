using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UICanvas
{
    [SerializeField]Button playButton;
    [SerializeField] Button shopButton;
    [SerializeField] Button settingButton;
    private void Start()
    {
        playButton.onClick.AddListener(PlayButton);
        shopButton.onClick.AddListener(ShopButton);
        settingButton.onClick.AddListener(SettingButton);
    }
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        GameManager.Ins.ChangeState(GameState.Gameplay);
        AudioManager.Ins.ChangeMusic(AudioManager.Ins.backgroundboss);
        LevelManager.Ins.OnInit();
        Close(0);
    }
    public void ShopButton()
    {
        UIManager.Ins.OpenUI<ShopUI>();
    }
    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }
    public void ClearAllList()
    {
        DataManager.Ins.userData.idWeapon.Clear();
    }
    
}
