using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private float tankSpeed;
    [SerializeField] private float rotationSpeedTank;
    [SerializeField] private float movementPointMaxDistance;
    [SerializeField] private AiAttackZone attackZone;

    private Transform target;
    private Vector2 movementPoint;
    private Vector2 direction;

    private const float rotationOffset = 90;

    private void Start()
    {
        StartCoroutine(UpdatePointMovement());
        
    }

    private void Update()
    {
        if (attackZone.TryGetTarget())
        {
            movementPoint = attackZone.GetTarget().position;
            direction = new Vector3(movementPoint.x - transform.position.x, movementPoint.y - transform.position.y, 0);
            if (direction.sqrMagnitude < movementPointMaxDistance) { return; }

        }
        RotateTo(movementPoint);
        transform.Translate(Vector3.up * tankSpeed * Time.deltaTime);


    }

    private IEnumerator UpdatePointMovement()
    {
        while (true)
        {
            movementPoint = Random.insideUnitCircle * movementPointMaxDistance;
            movementPoint.x += transform.position.x;
            movementPoint.y += transform.position.y;

            yield return new WaitForSeconds(6);
        }

    }
    private void RotateTo(Vector2 point)
    {
        Vector2 direction = new Vector3(point.x, point.y, 0) - transform.position;
        float angle = Vector3.Angle(Vector3.right, direction.normalized);
        if (direction.y < 0) { angle *= -1; }
        Quaternion to = Quaternion.Euler(0, 0, angle - rotationOffset);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, to, rotationSpeedTank);
    }
    private void MoveTo(Vector2 point)
    {

    }
}
