using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool HealthPowerUp = false;
    public bool MusicPowerUp = false;
    public bool ReloadSpeedPowerUp = false;
    public GameObject LevelController1;
    private LevelControllerScript LevelControllerScript1;
    

    void Start()
    {
        LevelControllerScript1 = LevelController1.GetComponent<LevelControllerScript>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(HealthPowerUp)
        {
            Debug.Log("H power UP");
            LevelControllerScript1.HealthPowerUp = true;
            HealthPowerUp = false;
        }
        else if(MusicPowerUp)
        {
            Debug.Log("Mpower UP");
            LevelControllerScript1.MusicPowerUp = true;
            MusicPowerUp = false;
        }
        else if(ReloadSpeedPowerUp)
        {
            Debug.Log("Rpower UP");
            LevelControllerScript1.ReloadSpeedPowerUp = true;
            ReloadSpeedPowerUp = false;
        }
    }
}
