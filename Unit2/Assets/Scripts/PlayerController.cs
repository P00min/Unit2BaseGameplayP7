using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float speed = 15;
    private float xRange = 18f;
    private float zTopRange = 15f;
    private float zLowerRange = 0;


    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setupBoundaries();
        setupController();
    }

    private void setupBoundaries()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zTopRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopRange);
        }
        if (transform.position.z < -zLowerRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLowerRange);
        }

    }

    private void setupController()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 newPosition = new Vector3(horizontalInput, transform.position.y, verticalInput);
        transform.Translate(Vector3.ClampMagnitude(newPosition, 1) * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
