using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAt : MonoBehaviour {
    public Transform Target;
    public Transform Shooter;
    public Transform Bullet;

    public float BulletSpeed = 0f;
    public float Inaccuracy;
    public float Interval;

    private Counter _intervalCounter;

    private void Start() {
        _intervalCounter = new Counter(Interval);
    }

    private void Update() {
        _intervalCounter.Update();

        if (_intervalCounter.Value <= 0) {
            Debug.Log("Shooting");

            var angle = Vector3.Angle(transform.position, Target.position);
            // var direction = new Vector3(Mathf.Sin(angle), 0, 0);
            var rotation = Quaternion.Euler(0, 0, angle);
            
            var bullet = Instantiate(Bullet, transform.position, rotation);
            var bulletShoot = bullet.gameObject.GetComponent<BulletScript>();
            bulletShoot.Target = Target;
            bulletShoot.Shooter = Shooter;
            bulletShoot.BulletSpeed = BulletSpeed;
            
            _intervalCounter.Reset();
        }
    }
}
