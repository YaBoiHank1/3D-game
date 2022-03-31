using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public Collider myCollider;
    public Canvas gameOverCanvas;
    public GameObject pauseCanvas;
    public Animator canvasAnimator;
    Rigidbody myRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.enabled = false;
        pauseCanvas.SetActive(true);
        myRigidbody = GetComponent<Rigidbody>();
        GetComponent<RigidbodyFirstPersonController>().enabled = true;
        canvasAnimator = GetComponent<PlayerHealth>().canvasAnimator;
        myCollider = GetComponent<CapsuleCollider>();
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
        transform.LookAt(FindObjectOfType<EnemyNavigation>().transform);
        Invoke("LoadGameOver", 3f);
    }

    private void LoadGameOver()
    {
        pauseCanvas.SetActive(false);
        gameOverCanvas.enabled = true;
        canvasAnimator.SetBool("FadeIn", true);
    }
}
