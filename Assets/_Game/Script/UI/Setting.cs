using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Setting : UICanvas
{
    [SerializeField] Button mainMenu_Button;
    [SerializeField] Button x_Button;
    [SerializeField] Button again_Button;

    private void Start()
    {
        mainMenu_Button.onClick.AddListener(MainMenuButton);
        x_Button.onClick.AddListener(XButton);
        again_Button.onClick.AddListener(AgainButton);
    }
    public override void Open()
    {
        Time.timeScale = 0;
        base.Open();
    }

    public override void Close(float delayTime)
    {
        Time.timeScale = 1;
        base.Close(delayTime);
    }
    public void XButton()
    { 
        Close(0);
    }

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        LevelManager.Ins.Reset();
        Close(0);
    }

    public void AgainButton()
    {
        LevelManager.Ins.Replay();
        Close(0);
    }
}
