﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    TrustFactor trustFactor;
    public float Speed,jumpForce;
    Rigidbody2D rb;
    StressSystem stressSystem;
    public PlayerAttack attack;
    public Bullet bullet;
    Animator anim;
    Vector2 flippositive, flipnegative;
    public bool isGrounded = false, attackcompleted = false,iswalking=false;
    public float clickthreshhold = 0.025f;
    double timerclick=0;
    public UImanager uimanager;
    public GameObject bloodeffect;
    HealthSystem healthSystem;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stressSystem = GetComponent<StressSystem>();
        anim = GetComponent<Animator>();
        trustFactor = GetComponent<TrustFactor>();
        flippositive = new Vector2(transform.localScale.x, transform.localScale.y);
        flipnegative = new Vector2(-transform.localScale.x, transform.localScale.y);
        healthSystem = GetComponent<HealthSystem>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EndPoint"))
        {
            uimanager.TransitionSceneChnage("AfterLevel1Story");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("Misunderstanding");
            stressSystem.Stress = stressSystem.stressIncrease(10);
           bullet.DestroyFunction(collision.gameObject);
           Instantiate(bloodeffect,transform.position,Quaternion.identity);
        }
        
        if (collision.gameObject.CompareTag("Collectables"))
        {
            Collectables.instance.PathDestroyonCollectables(Collectables.instance.path);
            Destroy(collision.gameObject);
            trustFactor.TrustFactorAmount = trustFactor.TrustfactorIncrease(10);
            stressSystem.Stress = stressSystem.stressdecrease(5);
        }

    }
   
    void Update()
    {
        if(stressSystem.Stress==100)
        {
            SceneManager.LoadScene("GameEnd");
        }
        if(healthSystem.health<=0)
        {
            SceneManager.LoadScene("GameEnd");
        }
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().Play("Sword");
            if((Time.time-timerclick)>clickthreshhold)
            {
                attack.PlayerAttackFunction(10);
                anim.SetTrigger("Attack");
                attackcompleted = true;
            }
            else
            {
                if(attackcompleted==true)
                {
                    attack.PlayerAttackFunction(20);
                    anim.SetTrigger("DashAttack");
                    attackcompleted = false;
                }
                else
                {
                    return;
                }
            }
            timerclick = Time.time;
        }
        var horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("Jump");
        }
        transform.Translate(new Vector2(horizontal * Speed ,rb.velocity.y) * Time.deltaTime);
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        if(horizontal>0)
        {
            transform.localScale = flippositive;
        }
        else if(horizontal<0)
        {
            transform.localScale = flipnegative;
        }
    }
}
