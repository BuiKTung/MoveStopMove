using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : UICanvas
{
    [SerializeField]Button again_Button;
    [SerializeField]Button next_Button;
    private void Start()
    {
        again_Button.onClick.AddListener(ReplayButton);
        next_Button.onClick.AddListener(NextButton);
    }
    public void ReplayButton()
    {
        LevelManager.Ins.Replay();
        Close(0);
    }
    public void NextButton()
    {
        LevelManager.Ins.NextLevel();
        Close(1);
    }
}
