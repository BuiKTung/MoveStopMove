using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CacheGetComponent 
{
    private static Dictionary<Collider, Characters> characters = new Dictionary<Collider, Characters>();
    public static Characters GetCharacters(Collider collider)
    {
        if (!characters.ContainsKey(collider))
        {
            characters.Add(collider, collider.GetComponent<Characters>());
        }
        return characters[collider]; 
    } 
    private static Dictionary<Collider, Bullet> bullets = new Dictionary<Collider, Bullet>();
    public static Bullet GetBullets(Collider collider)
    {
        if (!bullets.ContainsKey(collider))
        {
            bullets.Add(collider, collider.GetComponent<Bullet>());
        }
        return bullets[collider]; 
    }    
}
