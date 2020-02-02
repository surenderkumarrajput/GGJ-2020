using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHadowEnemies : MonoBehaviour
{

    public Transform Player;
    public bool isFipped;
    public float radius;
    public LayerMask layers;
    public Transform Trigger;
    float stress;
    private void Start()
    {
    }
    public void Attack(float damage)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(Trigger.position, radius, layers);
        foreach(var hit in collider)
        {
            if (collider != null)
            {
                 Player.GetComponent<HealthSystem>().healthDecrease(damage);
            }
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Trigger.transform.position, radius);
    }
    public void LookAtPlayer()
    {
        Vector3 Flipped = transform.localScale;

        if(transform.position.x>Player.position.x && isFipped )
        {
            transform.localScale = Flipped;
            transform.Rotate(0, -180, 0);
            isFipped = false;
        }
        else if(transform.position.x<Player.position.x && !isFipped)
        {
            transform.localScale = Flipped;
            transform.Rotate(0, -180, 0);
            isFipped = true;
        }
    }
}
