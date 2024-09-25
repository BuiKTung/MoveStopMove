using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private float timer;
    public void OnEnter(Bot bot)
    {
        bot.StopMoving();
        if(bot.canAttack)
            bot.StartAttack();
    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer > bot.attackCD)
        {
            bot.ChangeState(new IdleState());
        }
    }
    public void OnExit(Bot bot)
    {
        
    }
}
