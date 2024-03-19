using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private float power = 50.0f;

    void Update()
    {
        bool fire = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0);

        if (fire)
        {
            GameObject ball = (GameObject)Instantiate(ballPrefab, transform);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * power, ForceMode.Impulse);
        }
    }
}