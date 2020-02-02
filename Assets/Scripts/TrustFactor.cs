using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrustFactor : MonoBehaviour
{
    public float TrustFactorAmount = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public float TrustfactorIncrease(float TrustFactor)
    {
        TrustFactorAmount += TrustFactor;
        TrustFactorAmount = Mathf.Clamp(TrustFactorAmount, 0, 100f);
        return TrustFactorAmount;
    }
}
