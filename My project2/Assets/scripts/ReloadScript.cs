using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PowerUps;
    private powerupsScript PowerupsScript;
    void Start()
    {
        PowerupsScript = PowerUps.GetComponent<powerupsScript>();
        if(PowerUps == null)
        {
            Debug.Log("powerup notfound");

        }
        if(PowerupsScript==null )
        {
            Debug.Log("powerup script not found");
        }
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("arrow"))
        {
            PowerupsScript.ReloadSpeedPowerUp = true;
        }
    }
    void Update()
    {
        
    }
}
