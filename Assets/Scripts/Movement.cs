using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float tankSpeed;
    [SerializeField] private float rotationSpeedTank;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward,rotationSpeedTank);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -1*rotationSpeedTank);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * tankSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * tankSpeed*Time.deltaTime);
        }
    }
}
