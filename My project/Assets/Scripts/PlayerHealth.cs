using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public Collider myCollider;
    public Canvas gameOverCanvas;
    public GameObject[] canvases;
    public Animator canvasAnimator;
    Rigidbody myRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.enabled = false;
        myRigidbody = GetComponent<Rigidbody>();
        GetComponent<RigidbodyFirstPersonController>().enabled = true;
        canvasAnimator = GetComponent<PlayerHealth>().canvasAnimator;
        myCollider = GetComponent<CapsuleCollider>();
        foreach (GameObject i in canvases)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyNavigation>() != null)
        {
            Die();
        }
        else if (collision.gameObject.GetComponent<EnemyNavigation>() == null)
        {
            return;
        }
    }

    private void Die()
    {
        GetComponent<RigidbodyFirstPersonController>().enabled = false;
        transform.LookAt(FindObjectOfType<LookAt>().transform);
        Invoke("LoadGameOver", 3f);
    }

    private void LoadGameOver()
    {
        foreach (GameObject i in canvases)
        {
            gameObject.SetActive(false);
        }
        gameOverCanvas.enabled = true;
        canvasAnimator.SetBool("FadeIn", true);
    }

    
}
