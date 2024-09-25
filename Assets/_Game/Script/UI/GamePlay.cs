using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : UICanvas
{
    [SerializeField] Button setting_Button;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        setting_Button.onClick.AddListener(SettingButton);
        textMeshProUGUI.text = DataManager.Ins.userData.gold.ToString();
    }
    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }
}
