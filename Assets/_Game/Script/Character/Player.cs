using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Player : Characters
{
    [SerializeField] public DynamicJoystick joystick;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    public float timer;
    public static Action<Transform> OnSpawn;
    private void Update()
    {
        CheckListTarget();
        
        if (targetCharacter != null && canAttack)
        {
            StartCoroutine(Attack_Corotine());
            canAttack = false;
        }

        if (!canAttack)
        {
            timer += Time.deltaTime;
            if (timer >= attackCD)
            {
                canAttack = true;
                timer = 0;
            }  
        }
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y, 0);
    }
    private void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (canMove)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
        if ((joystick.Horizontal != 0 || joystick.Vertical != 0) && canMove == true)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            ChangeAnim(ConstanString.anim_Run);
        }
        else
        {
            ChangeAnim(ConstanString.anim_Idle);
        }
    }
    private void OnEnable()
    {
        OnSpawn.Invoke(this.transform);
    }
    public override void OnInnit()
    {
        OnSpawn.Invoke(this.transform);
        canAttack = true;
        currentWeaponType = (WeaponType)DataManager.Ins.userData.currentWeapon;
        base.OnInnit();
    }
    public override void onDeath()
    {
        base.onDeath();
        AudioManager.Ins.PlaySFX(AudioManager.Ins.death);
        GameManager.Ins.ChangeState(GameState.Fail);
    }
}
