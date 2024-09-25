using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<Transform> list_SP;
    [SerializeField] List<Level> list_LV;
    [SerializeField] public DynamicJoystick joystick;
    
    public int botDead;
    private int levelID = 0;
    private Level currentLevel;
    private void Awake()
    {
        PlayerPrefs.SetInt("Level", 0);
        levelID = PlayerPrefs.GetInt("Level", 0);
    }
    private void Start()
    {
        
        UIManager.Ins.OpenUI<MainMenu>();
        LoadLevel(levelID);
        //OnInit();
    }
    private void Update()
    {
        if (currentLevel != null && botDead <= 0 && GameManager.Ins.IsState(GameState.Gameplay))
        {
            GameManager.Ins.ChangeState(GameState.Victory);
            UIManager.Ins.OpenUI<Victory>();
        }
        if (GameManager.Ins.IsState(GameState.Fail))
        {
            UIManager.Ins.OpenUI<Fail>();
        }
    }
    public void OnInit()
    {
        LoadLevel(levelID);
        joystick.gameObject.SetActive(true);    
        list_SP.Clear();
        for ( int i = 0; i < currentLevel.spawnPos.Count; i++)
        {
            list_SP.Add(currentLevel.spawnPos[i]);
        }
        botDead = currentLevel.spawnPos.Count;
        Spawn();
    }
    public void LoadLevel(int level)
    {
        
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        if (level < list_LV.Count) {
            currentLevel = Instantiate(list_LV[level]);
        }
        else
        {
            //todo lon hon tong so level
        }
    }
    public void Spawn()
    {
        Player player = HBPool.Spawn<Player>(PoolType.Player, currentLevel.startPos.position, Quaternion.identity);
        player.joystick = joystick;
        player.OnInnit();
        for (int i = 0; i < list_SP.Count; i++)
        {
            Bot bot = HBPool.Spawn<Bot>(PoolType.Bot, list_SP[i].position, Quaternion.identity);
        }
    }
    public void Reset()
    {
        HBPool.CollectAll();
    }
    public void Replay()
    {
        //replay
        Reset();
        OnInit();
        GameManager.Ins.ChangeState(GameState.Gameplay);
    }
    public void NextLevel()
    {
        levelID++;
        PlayerPrefs.SetInt("Level", levelID);
        Reset();
        LoadLevel(levelID);
        OnInit();
    }
}
