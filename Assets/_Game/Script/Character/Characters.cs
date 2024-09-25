using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class Characters : GameUnit
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform lauchPos;
    [SerializeField] public GameObject attackRange;
    [SerializeField] private SOWeapon SOWeaponData;
    [SerializeField] public WeaponType currentWeaponType;
    [SerializeField] public Transform weaponHolder;
    [SerializeField] public Weapon weaponInHand;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private PoolType currentWeaponPoolType;
    [SerializeField] public Vector3 START_SIZE;
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
        ChangeWeapon(currentWeaponType);
        ChangeAnim(ConstanString.anim_Idle);
        attackRange.transform.localScale = START_SIZE;
        canAttack = true;
        
    }
    public virtual void onDeath()
    {
        ChangeAnim(ConstanString.anim_Dead);
        StartCoroutine(Dead_Coroutine());
        
    }
    
    public void Attack()
    {
        
        var bullet = HBPool.Spawn<Bullet> (currentWeaponPoolType,lauchPos.position, Quaternion.identity);
        bullet.OnInit(); 
        bullet.SetOwner(this);
        bullet.SetDirection(lauchPos.forward);
        //GameObject bulletObj = Instantiate(bulletPrefab, lauchPos.position, bulletPrefab.transform.rotation);
        //Bullet bullet = bulletObj.GetComponent<Bullet>();
        ChangeAnim(ConstanString.anim_Attack);
        AudioManager.Ins.PlaySFX(AudioManager.Ins.arrow);
        //bullet.Launch(transform.forward, 300);
    }
    public IEnumerator Attack_Corotine()
    {
            this.transform.LookAt(targetCharacter.transform);
           
            if(this is Bot)
                yield return new WaitForSeconds(1.5f);
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
    //---------------For Skin---------------
    public void ChangeWeapon(WeaponType weaponType)
    {
        if(weaponInHand != null)
            Destroy(weaponInHand);
        this.currentWeaponType = weaponType;

        WeaponItemData weaponItemData = SOWeaponData.GetWeapon(currentWeaponType);
        this.bulletPrefab = weaponItemData.prefabWeaponBullet;
        this.currentWeaponPoolType = bulletPrefab.GetComponent<Bullet>().poolType;
        this.weaponInHand = Instantiate(weaponItemData.prefabWeaponInHand, weaponHolder);
    }
}
