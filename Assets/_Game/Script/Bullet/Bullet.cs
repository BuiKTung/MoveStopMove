using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : GameUnit
{
    [SerializeField] Rigidbody rb;
    public Vector3 startPos;
    [SerializeField]private Characters owner;
    
    public virtual void TimeALive()
    {
        if (Vector3.Distance(startPos, transform.position) > 5f)
        {
            HBPool.Despawn(this);
        }
    }
    public virtual void OnInit()
    {
        startPos = transform.position;
    }
    public void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force);
    }
    public void SetOwner(Characters owner)
    {
        this.owner = owner;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstanString.TAG_CHARACTER) && other.gameObject != owner) 
        {
            //Debug.Log(other.gameObject);
            Characters character = CacheGetComponent.GetCharacters(other);
            character.onDeath();
            HBPool.Despawn(this);
            owner.LevelUpRange();
           
            ParticlePool.Play(ParticleType.SingleThunder,transform.position,Quaternion.identity);  
        }
    }
}
