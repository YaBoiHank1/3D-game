using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjective : MonoBehaviour
{
    public Text pickupText;
    private bool canPickUp;

    // Start is called before the first frame update
    void Start()
    {
        pickupText.enabled = false;
        canPickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp == true && Input.GetKeyDown(KeyCode.E))
        {
            pickupText.enabled = false;
            FindObjectOfType<ObjectiveTracker>().ObjectiveCollected();
            canPickUp = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickupText.enabled = true;
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickupText.enabled = false;
            canPickUp = false;
        }
    }
}
