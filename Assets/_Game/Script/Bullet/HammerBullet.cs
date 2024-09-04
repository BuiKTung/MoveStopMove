using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Bullet
{
    float x, y;
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
        x = 100;
        y = 45;
    }
    private void Trajectory(float x, float y)
    {
        transform.rotation = Quaternion.Euler(x,y,0);
    }
}
