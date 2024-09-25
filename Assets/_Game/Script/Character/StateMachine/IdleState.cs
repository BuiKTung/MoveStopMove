using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private float timer = 0;
    private float randomTimer;
    public void OnEnter(Bot bot)
    {
        
        randomTimer = Random.Range(0.5f, bot.randomTime);
        bot.ChangeAnim(ConstanString.anim_Idle);
        bot.StopMoving();
    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer > randomTimer)
        {
            bot.ChangeState(new PatrolState());
        }
    }
    public void OnExit(Bot bot)
    {

    }
}
