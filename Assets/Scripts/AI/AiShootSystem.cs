using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootSystem : MonoBehaviour
{

    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float waitTime;

    [SerializeField] private AiAttackZone aiAttackZone;
    [SerializeField] private AiBarrelMovement barrelMovement;

    private Transform target;
    private TimerAction timer;
    private bool canShoot = true;
    private string shootTimerName;

    private void Start()
    {
        timer = new TimerAction(waitTime, HandleTimer);
        shootTimerName = gameObject.name + "ShootTimer";
        TimerController.AddTimer(timer,shootTimerName);
    }

    void Update()
    {
        if (aiAttackZone.TryGetTarget())
        {
            if (canShoot && Mathf.Abs(barrelMovement.TargetOfAngle)<=5)
            {
                Shoot();
                timer.Start();
                canShoot = false;
            }
        }

    }


    private void OnDestroy()
    {
        TimerController.RemoveTimer(shootTimerName);
    }

    private void Shoot()
    {
        GameObject obj = Instantiate(prefabBullet);
        obj.transform.position = shootPoint.position;
        obj.transform.rotation = shootPoint.rotation;
        BulletMovement movement = obj.GetComponent<BulletMovement>();
        movement.Direction = shootPoint.up;
    }
    private void HandleTimer()
    {
        canShoot = true;
    }
}
