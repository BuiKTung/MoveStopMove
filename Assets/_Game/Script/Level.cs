using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level;
    public int botCount;
    [SerializeField] public Transform startPos;
    [SerializeField] public List<Transform> spawnPos;
}
