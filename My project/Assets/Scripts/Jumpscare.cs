using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            gameObject.GetComponent<EnemyNavigation>().enabled = false;
            myAnimator.SetBool("Jumpscare", true);
            myAnimator.SetBool("Walk", false);
            myAnimator.SetBool("Run", false);
            myAnimator.SetBool("Idle", false);
        }
    }
}
