using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStats : MonoBehaviour
{
    public int attack;
    public int defence;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        attack = Random.Range(1,10);
        defence = Random.Range(1, 10);
        health = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
