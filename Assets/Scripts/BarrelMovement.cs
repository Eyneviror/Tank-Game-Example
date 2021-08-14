using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationOffset;
    [SerializeField] private bool inversyRotation;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 point = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector3(point.x, point.y, 0) - transform.position;
        float angle = Vector3.Angle(Vector3.right, direction.normalized);
        if (direction.y < 0 && !inversyRotation) { angle *= -1; }
        Quaternion to = Quaternion.Euler(0, 0, angle-rotationOffset);

        transform.rotation = Quaternion.RotateTowards(transform.rotation,to,speed);

    }
}
