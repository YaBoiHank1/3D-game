using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CapsuleCollider>();
        GetComponent<RigidbodyFirstPersonController>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyNavigation>() != null)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<RigidbodyFirstPersonController>().enabled = false;
        transform.LookAt(FindObjectOfType <EnemyNavigation>().transform);
    }
}
