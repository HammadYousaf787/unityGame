using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class MouseLookAround : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public Vector2 sensitivity = Vector2.one * 360f;
    public Rigidbody rb;
    float shootForce;// Adjust this as needed
    public GameObject arrowPrefab; // Prefab of the object to shoot
    private Transform shootPoint; // Point from which to instantiate the arrow
    private GameObject currentArrow;
    private float arrowSpawnTimer = 2f;
    bool arrowShot = false;
    float starttime;
    float endtime;

    private void Start()
    {
        shootPoint = transform.Find("ShootPoint");
        CreateArrow();
    
    }

    void Update()
    {
        // Camera rotation
        rotationY += UnityEngine.Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity.x;
        rotationX += UnityEngine.Input.GetAxis("Mouse Y") * Time.deltaTime * -1 * sensitivity.y;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);


        if (currentArrow != null)
        {
            currentArrow.transform.position = shootPoint.position;
            currentArrow.transform.rotation = shootPoint.rotation;
        }

        // Shoot the arrow when left mouse button is clicked
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            if (arrowShot == false)
            {
                starttime = Time.time;

            }
        
           
            

        }
        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            if (arrowShot == false)
            {
                endtime = Time.time;
                if ((endtime - starttime) > 2)
                {
                    shootForce = 25f;
                    Debug.Log(" larger than 2");
                    ShootArrow();
                }
                else if ((endtime - starttime) > 1.5)
                {
                    shootForce = 20f;
                    Debug.Log(" larger than 1.5");
                    ShootArrow();
                }
                else if ((endtime - starttime) > 1)
                {
                    shootForce = 15f;
                    Debug.Log(" larger than 1");
                    ShootArrow();
                }
                else if ((endtime - starttime) < 1)
                {
                    shootForce = 10f;
                    Debug.Log(" smaller than 1");
                    ShootArrow();
                }
                
                
                starttime = 0f;
                endtime = 0f;
            }

        }
        


    }

    void ShootArrow()
    {
        // Instantiate the arrow
        Debug.Log("in ShootArrow");
        Rigidbody arrowRb = currentArrow.GetComponent<Rigidbody>();
        if (arrowRb == null)
        {
            Debug.LogError("Rigidbody not found on the arrow prefab!");
            return;
        }
        // Shoot in the direction the camera is facing
        Vector3 vectorShoot = shootPoint.forward * shootForce;
        arrowRb.AddForce(vectorShoot, ForceMode.Impulse);
        arrowShot = true;
        arrowRb.useGravity = true;
        currentArrow = null;

        StartCoroutine(reload());

    }

    void CreateArrow()
    {
        Debug.Log("in createArrow");
        currentArrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody arrowRb = currentArrow.GetComponent<Rigidbody>();

        arrowRb.useGravity = false;
    }

    private IEnumerator reload()
    {
        Debug.Log("in reload");
        yield return new WaitForSeconds(arrowSpawnTimer);
 
        CreateArrow();
        arrowShot = false;
        Debug.Log("in reload");
    }
}