using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootSystem : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float waitTime;


    private TimerAction timer;
    private bool canShoot = true;

    private void Start()
    {
        timer = new TimerAction(waitTime, HandleTimer);
        TimerController.AddTimer(timer,"PlayerShoot");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
            timer.Start();
            canShoot = false;
        }
    }
    private void Shoot()
    {
        GameObject obj = Instantiate(prefabBullet);
        obj.transform.position = shootPoint.position;
        obj.transform.rotation = shootPoint.rotation;
        BulletMovement movement = obj.GetComponent<BulletMovement>();
        Vector2 direction = shootPoint.up;
        movement.Direction = direction;
    }
    private void HandleTimer()
    {
        canShoot = true;
    }
}
