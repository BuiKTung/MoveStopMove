using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Hammer : Bullet
{
    private void Update()
    {
        if (canMove)
            Move();
        
        Trajectory();
        TimeALive();
    }
    public override void OnInit()
    {
        base.OnInit();
    }  
}
