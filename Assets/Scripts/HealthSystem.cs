using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public float healthincrease(float _health)
    {
        health += _health;
        health = Mathf.Clamp(health, 0, 100);
        return health;
    }
    public float healthDecrease(float _health)
    {
        health -= _health;
        health = Mathf.Clamp(health, 0, 100);
        return health;
    }
}
