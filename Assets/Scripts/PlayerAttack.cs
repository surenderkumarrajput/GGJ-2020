using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask layers;
    public float radius;
    public GameObject MisunderstandingEffect;
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
                Instantiate(MisunderstandingEffect, transform.position, Quaternion.identity);
                obj.gameObject.GetComponent<Misunderstanding>().DamageTaken(damage);
            }
            if(obj.gameObject.CompareTag("Shadow"))
            {
                obj.gameObject.GetComponent<SHadowEnemies>().TakeDamage(damage);
                Instantiate(MisunderstandingEffect, transform.position, Quaternion.identity);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
