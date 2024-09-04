using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fail : UICanvas
{
    [SerializeField] Button mainMenu_Button;
    [SerializeField] Button again_Button;
    private void Start()
    {
        mainMenu_Button.onClick.AddListener(MainMenuButton);
        again_Button.onClick.AddListener(ReplayButton);
    }
    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        GameManager.Ins.ChangeState(GameState.MainMenu);
        LevelManager.Ins.Reset();
        Close(0);
    }
    public void ReplayButton()
    {
        LevelManager.Ins.Replay();
        Close(0);
    }
}
