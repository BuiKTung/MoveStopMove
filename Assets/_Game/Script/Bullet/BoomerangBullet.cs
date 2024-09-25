using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoomerangBullet : Bullet
{ 
    private bool isReturn = false;
    private void Update()
    {
        if (canMove)
        {
            Move();
           
        }
        Trajectory();
        TimeALive();  
    }
    public override void OnInit()
    {
        base.OnInit();
    }
    public override void Move()
    {
        if (!isReturn)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
    }
    public override void TimeALive()
    {
        if (Vector3.Distance(startPos, transform.position) >= maxDistance)
        {
            isReturn = true;
        }
        if (isReturn)
        {
            if (Vector3.Distance(startPos, transform.position) < 0.1f)
            {
                HBPool.Despawn(this);
                isReturn = false;   
            }
        }
    }
}
