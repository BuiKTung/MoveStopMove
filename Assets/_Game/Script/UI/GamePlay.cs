using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : UICanvas
{
    [SerializeField] Button setting_Button;
    private void Start()
    {
        setting_Button.onClick.AddListener(SettingButton);
    }
    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }
}
