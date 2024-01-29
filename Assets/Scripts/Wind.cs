using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [Tooltip("The minumum force applied , randomised between minimum to maximum")]
    [SerializeField]
    private float minForce = 1f;

    [Tooltip("The maximum force applied , randomised between minimum to maximum")]
    [SerializeField]
    private float maxForce = 5f;

    [Tooltip("How often the wind hits, minimum")]
    [SerializeField]
    private float minInterval = 1f; 

    [Tooltip("How often the wind hits, maximum")]
    [SerializeField]
    private float maxInterval = 5f;

   private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("ApplyRandomWind", Random.Range(minInterval, maxInterval));
    }

    void ApplyRandomWind()
    {
        // Generate random wind force in the x-axis
        float randomForce = Random.Range(minForce, maxForce);
        float xForce = Random.Range(0f, 1f) > 0.5f ? randomForce : -randomForce;

        // Generate random wind force in the z-axis
        float zForce = Random.Range(0f, 1f) > 0.5f ? Random.Range(minForce, maxForce) : 0f;

        Vector3 windForce = new Vector3(xForce, 0f, zForce);

        // Apply force to the Rigidbody
        rb.AddForce(windForce, ForceMode.Impulse);

        // Schedule the next invocation with a new random interval
        Invoke("ApplyRandomWind", Random.Range(minInterval, maxInterval));
    }
}
