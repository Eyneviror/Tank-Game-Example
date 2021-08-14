using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    [HideInInspector] public Vector2 Direction;

    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Direction * Time.deltaTime * speed,Space.World);
    }
}
