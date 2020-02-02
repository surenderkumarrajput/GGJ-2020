using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    public float speed;
    Transform Shadow;
    SHadowEnemies shadowEnemies;
    Vector2 Positive, negative;
    Rigidbody2D rb;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        Shadow = animator.GetComponent<Transform>().transform;
        shadowEnemies = animator.GetComponent<SHadowEnemies>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform;
        var playerPos = new Vector2(pos.position.x,rb.position.y);
        var newPos = Vector2.MoveTowards(rb.position, playerPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        if(Vector2.Distance(rb.position, pos.position) <=2)
        {
            animator.SetTrigger("Attack");
            shadowEnemies.Attack(10);
        }
        shadowEnemies.LookAtPlayer();
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
