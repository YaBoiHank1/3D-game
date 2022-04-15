using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjective : MonoBehaviour
{
    public Text pickupText;
    public Text depositText;
    public Text notEnough;
    private bool canPickUp;
    private bool canDeposit;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        pickupText.enabled = false;
        depositText.enabled = false;
        notEnough.enabled = false;
        canPickUp = false;
        canDeposit = false;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp == true && Input.GetKeyDown(KeyCode.E))
        {
            pickupText.enabled = false;
            notEnough.enabled = false;
            FindObjectOfType<ObjectiveTracker>().ObjectiveCollected();
            canPickUp = false;
            active = false;
        }
        if (canDeposit == true && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<ObjectiveTracker>().Deposit();
        }
        if (FindObjectOfType<ObjectiveTracker>().goalDone == true)
        {
            canDeposit = true;
        }
        notEnough.text = "Not enough gas. You need " + (FindObjectOfType<ObjectiveTracker>().goal - FindObjectOfType<ObjectiveTracker>().collected) + " more.";

        if (active == true)
        {
            gameObject.SetActive(true);
        }
        else if (active == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag != "Sedan" && other.gameObject.tag == "Player")
        {
            pickupText.enabled = true;
            canPickUp = true;
        }
        if (gameObject.tag == "Sedan" && other.gameObject.tag == "Player")
        {
            depositText.enabled = true;
            if (canDeposit == true)
            {
                notEnough.enabled = false;
                //FindObjectOfType<ObjectiveTracker>().Deposit();
            }
            else if (canDeposit == false)
            {
                notEnough.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(gameObject.tag != "Sedan" &&  other.gameObject.tag == "Player")
        {
            pickupText.enabled = false;
            canPickUp = false;
        }
        if (gameObject.tag == "Sedan" && other.gameObject.tag == "Player")
        {
            depositText.enabled = false;
            if (notEnough.enabled == true)
            {
                notEnough.enabled = false;
            }
        }
    }
}
