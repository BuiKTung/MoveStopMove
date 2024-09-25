using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : GameUnit
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private Characters owner;
    [SerializeField] public float speed;
    [SerializeField] public float rotationSpeed = 500;
    [SerializeField] public bool isYRotation;
    [SerializeField] public bool isZRotation;
    [SerializeField] public float maxDistance = 20f;
    public Vector3 startPos;
    public Vector3 direction;
    public bool canMove;
    public bool isBoomerang;
    public virtual void TimeALive()
    {
        if (Vector3.Distance(startPos, transform.position) >= maxDistance)
        {
            OnDesSpawn();
        }
    }
    public virtual void OnInit()
    {
        startPos = transform.position;
        canMove = false;
    }
    public virtual void OnDesSpawn()
    {
        HBPool.Despawn(this);

    }
    public virtual void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    public void SetOwner(Characters owner)
    {
        this.owner = owner;
    }
    public void SetDirection(Vector3 dir)
    {
        this.direction = dir;
        canMove = true;
    }
    public void Trajectory()
    {
        if (isYRotation)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (isZRotation)
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstanString.TAG_CHARACTER) && other.gameObject != owner.gameObject)
        {
            //Debug.Log(other.gameObject);
            Characters character = CacheGetComponent.GetCharacters(other);
            character.onDeath();
            if (!isBoomerang)
                HBPool.Despawn(this);
            owner.LevelUpRange();
            AudioManager.Ins.PlaySFX(AudioManager.Ins.take_coin);
            ParticlePool.Play(ParticleType.SingleThunder, transform.position, Quaternion.identity);
        }
    }

}
