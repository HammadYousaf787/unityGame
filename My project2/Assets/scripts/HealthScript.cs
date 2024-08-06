using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PowerUps;
    private powerupsScript PowerupsScript;
    void Start()
    {
        PowerupsScript = PowerUps.GetComponent<powerupsScript>();
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            PowerupsScript.HealthPowerUp = true;
        }
    }
    void Update()
    {

    }
}
