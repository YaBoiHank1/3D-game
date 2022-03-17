using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 5;
    public Image healthBar;

    private void Start()
    {
        healthBar.fillAmount = hp * .2f;
    }
    // Update is called once per frame
    void Update()
    {
        if(hp <=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        healthBar.fillAmount = hp * .2f;
    }
}
