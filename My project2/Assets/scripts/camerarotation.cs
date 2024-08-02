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
    private TrailRenderer tail;
    private float arrowSpawnTimer = 2f;
    bool arrowShot = false;
    float starttime;
    private AudioSource as1;
    private GameObject child;
    private audioWorking childScript;
    float endtime;
    public GameObject quiver1;
    public GameObject quiver2;
    public GameObject quiver3;
    private arrowAudio AudioScript;


    private void Start()
    {
        shootPoint = transform.Find("ShootPoint");
        CreateArrow();
        quiver1.SetActive(true);
        as1 = GetComponent<AudioSource>();
        Transform child = transform.Find("audio");
        AudioScript = child.GetComponent<arrowAudio>();



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
                quiver1.SetActive(false);
                if ((endtime - starttime) > 2)
                {
                    quiver3.SetActive(true);
                    shootForce = 25f;
                    Debug.Log(" larger than 2");
                    AudioScript.playArrowSound(true);
                    ShootArrow();
                }
                else if ((endtime - starttime) > 1.5)
                {
                    quiver3.SetActive(true);
                    shootForce = 20f;
                    Debug.Log(" larger than 1.5");
                    AudioScript.playArrowSound(true);
                    ShootArrow();
                }
                else if ((endtime - starttime) > 1)
                {
                    quiver2.SetActive(true);
                    shootForce = 15f;
                    Debug.Log(" larger than 1");
                    AudioScript.playArrowSound(false);
                    ShootArrow();
                }
                else if ((endtime - starttime) < 1)
                {
                    quiver2.SetActive(true);
                    shootForce = 10f;
                    AudioScript.playArrowSound(false);
                    Debug.Log(" smaller than 1");
                    ShootArrow();
                }
                
                
                starttime = 0f;
                endtime = 0f;
            }

           
            StartCoroutine(ResetQuivers());

        }



    }

    private IEnumerator ResetQuivers()
    {
        yield return new WaitForSeconds(0.4f);
        quiver3.SetActive(false);
        quiver2.SetActive(false);

        quiver1.SetActive(true);
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
        tail.enabled = true;
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
        tail = currentArrow.GetComponent<TrailRenderer>();
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