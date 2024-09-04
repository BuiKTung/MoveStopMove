using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UICanvas
{
    [SerializeField]Button playButton;
    private void Start()
    {
        playButton.onClick.AddListener(PlayButton);
    }
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        GameManager.Ins.ChangeState(GameState.Gameplay);
        LevelManager.Ins.OnInit();
        Close(0);
    }
}
