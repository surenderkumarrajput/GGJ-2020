using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressSystem : MonoBehaviour
{
    public float Stress=20;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public float stressdecrease(float stress)
    {
        Stress -= stress;
        Stress = Mathf.Clamp(Stress, 0, 100);
        return Stress;
    }
    public float stressIncrease(float stress)
    {
        Stress += stress;
        Stress = Mathf.Clamp(Stress, 0, 100);
        return Stress;
    }
}
