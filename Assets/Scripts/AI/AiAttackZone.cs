using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackZone : MonoBehaviour
{
    private Transform target;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            target = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            target = collision.gameObject.transform;
    }

    public bool TryGetTarget()
    {
        return target != null;
    }
    public Transform GetTarget()
    {
        return target;
    }
}
