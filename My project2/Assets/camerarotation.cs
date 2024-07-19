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
    public float shootForce = 500f; // Adjust this as needed
    public GameObject arrowPrefab; // Prefab of the object to shoot
    private Transform shootPoint; // Point from which to instantiate the arrow
    private GameObject currentArrow;
    private float arrowSpawnTimer = 0f;
    bool arrowShot = false;
    private void Start()
    {
        shootPoint = transform.Find("ShootPoint");
        CreateArrow();
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on child cube!");
        }
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
            ShootArrow();

            CreateArrow();
        }


    }

    void ShootArrow()
    {
        // Instantiate the arrow
        Rigidbody arrowRb = currentArrow.GetComponent<Rigidbody>();
        if (arrowRb == null)
        {
            Debug.LogError("Rigidbody not found on the arrow prefab!");
            return;
        }
        // Shoot in the direction the camera is facing
        Vector3 vectorShoot = shootPoint.forward * shootForce;
        arrowRb.AddForce(vectorShoot);
        arrowRb.useGravity =true;
    }

    void CreateArrow()
    {
        currentArrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody arrowRb = currentArrow.GetComponent<Rigidbody>();

        arrowRb.useGravity = false;
    }
}