using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Collider myCollider;
    public Canvas gameOverCanvas;
    public Animator canvasAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.enabled = false;
        canvasAnimator = FindObjectOfType<Canvas>(gameOverCanvas).GetComponent<Animator>();
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
        StartCoroutine(LoadGameOver());
    }

    private IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3);
        gameOverCanvas.enabled = true;
        canvasAnimator.SetBool("FadeIn", true);
    }
}
