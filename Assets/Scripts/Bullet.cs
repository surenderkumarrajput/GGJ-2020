using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform player;
    public float Bulletspeed;
    Vector2 direction;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position;
        transform.position = Vector2.MoveTowards(transform.position, direction, Bulletspeed * Time.deltaTime);
        var rotation = player.position - transform.position;
        float angle = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg+90f;
        rb.rotation = angle;
    }
    public void DestroyFunction(GameObject bullet)
    {
        Destroy(bullet);
    }
        
    
}
