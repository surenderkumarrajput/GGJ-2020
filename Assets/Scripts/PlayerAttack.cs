using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask layers;
    public Misunderstanding misunderstanding;
    public float radius;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void PlayerAttackFunction(float damage)
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius, layers);
        foreach (var obj in hit)
        {
            misunderstanding.DamageTaken(damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
