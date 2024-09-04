using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class Characters : GameUnit
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform lauchPos;
    [SerializeField] public GameObject attackRange;
    [SerializeField] SOWeapon SOWeaponData;
    private string currentAnim = ConstanString.anim_Idle;
    private bool isAttacking;
    public Characters targetCharacter;
    private List<Characters> list_target = new List<Characters>();
    public List<Characters> List_target { get => list_target; set => list_target = value; }
    protected bool canMove = true;
    public bool canAttack = true;
    public float attackCD = 1f;
    public float upSizeParameter = 0f;
    internal bool isDead = false;
   
    public virtual void CheckListTarget()
    {
        if (targetCharacter == null && List_target.Count >= 1)
        {
            targetCharacter = List_target[List_target.Count - 1];

        }
        if /*(targetCharacter != null && targetCharacter.isDead && targetCharacter.enabled == false)*/(!List_target.Contains(targetCharacter))
        {
            targetCharacter = null;
        }
        if (List_target.Count != 0 && !targetCharacter.isActiveAndEnabled)
        {
            List_target.Remove(targetCharacter);
            targetCharacter = null;
        }
    }
    public virtual void OnInnit()
    {
        list_target.Clear();
        ChangeAnim(ConstanString.anim_Idle);
        canAttack = true;
        
    }
    public virtual void onDeath()
    {
        ChangeAnim(ConstanString.anim_Dead);
        StartCoroutine(Dead_Coroutine());
        
    }
    public void OnAnimatorMove()
    {
        
    }
    public void Attack()
    {
        //var bullet = HBPool.Spawn<Hammer>(PoolType.Bullet,lauchPos.position, Quaternion.identity);

        GameObject bulletObj = Instantiate(bulletPrefab, lauchPos.position, bulletPrefab.transform.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.SetOwner(this);
        ChangeAnim(ConstanString.anim_Attack);
        bullet.Launch(transform.forward, 300);
    }
    public IEnumerator Attack_Corotine()
    {
            this.transform.LookAt(targetCharacter.transform);
            
            if(this is Bot)
                yield return new WaitForSeconds(2f);
            Attack();
            yield return new WaitForSeconds(attackCD);
            canAttack = true;
    }
    public IEnumerator Dead_Coroutine()
    {
        yield return new WaitForSeconds(0.6f);
        HBPool.Despawn(this);
        LevelManager.Ins.botDead -= 1;
    }
    public void ChangeAnim(string animName)
    {
        if(currentAnim != animName)
        {
            animator.SetBool(currentAnim,false);
            currentAnim = animName;
            animator.SetBool(currentAnim,true);
        }
    }
   
    public void SetTarget(Characters enemy)
    {
        if (targetCharacter != null) {
            targetCharacter = enemy;
        }

    }
    public void LevelUpRange()
    {
        if(upSizeParameter > 1f)
            return;
        upSizeParameter += 0.2f ;
        attackRange.transform.localScale += new Vector3( upSizeParameter, 0.0f,  upSizeParameter);
    }
}
