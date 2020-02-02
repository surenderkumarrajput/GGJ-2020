using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorialbackground : MonoBehaviour
{
    public Animator anim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(waittime());
        }
    }
    IEnumerator waittime()
    {
        anim.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level1");
    }
    
}
