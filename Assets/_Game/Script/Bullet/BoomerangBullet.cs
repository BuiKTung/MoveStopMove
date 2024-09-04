using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : Bullet
{
    float x, y;
    private bool again = false; 
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        y += 20;
        Trajectory(x, y);
        TimeALive();
    }
    public override void OnInit()
    {
        base.OnInit();
        x = 0;
        y = 0;
    }
    private void Trajectory(float x, float y)
    {
        transform.rotation = Quaternion.Euler(x, y, 0);
    }
    public override void TimeALive()
    {
        if (Vector3.Distance(startPos, transform.position) > 5f)
        {
            again = true;
        }
        if (again) {
            if(Vector3.Distance(startPos,transform.position) < -0.1f)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
