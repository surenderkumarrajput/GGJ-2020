using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public bool isGrounded = false, attackcompleted = false;
    public float clickthreshhold = 0.025f;
    double timerclick=0;
    public UImanager uimanager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stressSystem = GetComponent<StressSystem>();
        anim = GetComponent<Animator>();
        trustFactor = GetComponent<TrustFactor>();
        flippositive = new Vector2(transform.localScale.x, transform.localScale.y);
        flipnegative = new Vector2(-transform.localScale.x, transform.localScale.y);
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
            uimanager.TransitionSceneChnage("Level1ShadowFight");
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
           stressSystem.Stress = stressSystem.stressIncrease(10);
           bullet.DestroyFunction(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("TrustFactorOrb"))
        {
            trustFactor.TrustFactorAmount=trustFactor.TrustfactorIncrease(10);
            Destroy(collision.gameObject);
            stressSystem.Stress = stressSystem.stressdecrease(5);
        }
        if (collision.gameObject.CompareTag("Collectables"))
        {
            Collectables.instance.PathDestroyonCollectables(Collectables.instance.path);
            trustFactor.TrustFactorAmount = trustFactor.TrustfactorIncrease(10);
            stressSystem.Stress = stressSystem.stressdecrease(5);
        }

    }
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
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
