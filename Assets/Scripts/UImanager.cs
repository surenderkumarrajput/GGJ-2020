using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public StressSystem stresssystem;
    public TrustFactor trustfactor;
    public HealthSystem HealthSystem;
    public SHadowEnemies shadowenemies;
    public Image StressBar, TrustFactorBar,healthbar,ShadowHealthBar;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        StressBar.fillAmount = stresssystem.Stress / 100f;
        TrustFactorBar.fillAmount = trustfactor.TrustFactorAmount / 100f;
        healthbar.fillAmount = HealthSystem.health / 100;
        ShadowHealthBar.fillAmount = shadowenemies.ShadowHealth / 100;
    }
    public void TransitionSceneChnage(string index)
    {
        StartCoroutine(AsyncFunction(index));
    }
    IEnumerator AsyncFunction(string sceneindex)
    {
        anim.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneindex);
    }
}
