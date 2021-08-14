using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiBarrelMovement : MonoBehaviour
{
    [HideInInspector] public float TargetOfAngle;


    [SerializeField] AiAttackZone attackZone;
    [SerializeField] float rotationOffset;
    [SerializeField] float speed;

    private Transform target;

    private void Update()
    {
        if (attackZone.TryGetTarget())
        {
            target = attackZone.GetTarget();

            Vector2 point = target.position;
            Vector2 direction = new Vector3(point.x, point.y, 0) - transform.position;
            float angle = Vector3.Angle(Vector3.right, direction.normalized);
            if (direction.y < 0) { angle *= -1; }
            Quaternion to = Quaternion.Euler(0, 0, angle - rotationOffset);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, to, speed);
            TargetOfAngle = Vector3.Angle(transform.up, direction);
        }


    }
}
