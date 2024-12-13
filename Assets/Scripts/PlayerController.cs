using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] float horsePower;
    [SerializeField] float turnSpeed;
    float horizontalInput;
    float forwardInput;
    Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        Speed();
        rpm = (speed % 30) * 40;
        rpmText.SetText("RPM: " + rpm);
    }

    private void Speed()
    {
        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f); // for mph use 2.237f
        speedometerText.SetText("Speed: " + speed + "km/h");
    }
}
