using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask layers;
    public Misunderstanding misunderstanding;
    public SHadowEnemies shadowenemies;
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
            if(obj.gameObject.CompareTag("Collectables"))
            {
                misunderstanding.DamageTaken(damage);
            }
            if(obj.gameObject.CompareTag("Shadow"))
            {
                shadowenemies.TakeDamage(damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
