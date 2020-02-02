using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misunderstanding : MonoBehaviour
{
    public GameObject Bullet,Trigger,player;
    public float Enemyhealth = 100;
    void Start()
    {
        InvokeRepeating("Shoot", 2.5f, 2.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
       if(Enemyhealth<=0)
        {
            Destroy(gameObject);
        }
    }
    public void DamageTaken(float damage)
    {
        Enemyhealth -= damage;
        Enemyhealth = Mathf.Clamp(Enemyhealth,0,100);
    }
    public void Shoot()
    {
        if (Vector2.Distance(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position, transform.position) < 10)
        {
           GameObject instance= Instantiate(Bullet, Trigger.transform.position,Quaternion.identity);
           Destroy(instance, 5f);
        }
        else
        {
            return;
        }
    }
}
