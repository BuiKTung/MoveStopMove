using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField]Characters owner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstanString.TAG_CHARACTER)) {
            
            Characters characters = CacheGetComponent.GetCharacters(other);
            owner.List_target.Add(characters);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Characters character = other.GetComponent<Characters>();
        if( other.CompareTag(ConstanString.TAG_CHARACTER))
        {
            owner.List_target.Remove(character);
            if(owner.targetCharacter == character)
                owner.targetCharacter = null;
        }
    }
}
