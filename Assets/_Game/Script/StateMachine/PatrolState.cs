using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private float timer = 0;
    private float randomTimer;
    public void OnEnter(Bot bot)
    {
        bot.MoveToRandomPoint();
        randomTimer = Random.Range(0.5f, bot.randomTime);
    }

    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer > randomTimer)
        {
            bot.ChangeState(new IdleState());
        }
        if (bot.List_target.Count > 0)
        { 
            bot.ChangeState(new AttackState());
        }
    }

    public void OnExit(Bot bot)
    {
        
    }
}
