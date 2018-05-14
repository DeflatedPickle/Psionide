using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAt : MonoBehaviour {
    public Transform Target;
    public Transform Shooter;
    public Transform Bullet;
    public Animation ShootAnimation;

    public float BulletSpeed = 0f;
    public float Inaccuracy;
    public float Interval;

    private Counter _intervalCounter;

    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    private void Start() {
        _intervalCounter = new Counter(Interval);
    }

    private void Update() {
        if (!Util.IsDead) {
            _intervalCounter.Update();
        }

        if (_intervalCounter.Value <= 0) {
            Debug.Log("Shooting");

            if (Target != null) {
                _animator.SetTrigger("MegaShoot");
            }
            
            _intervalCounter.Reset();
        }
    }

    public void Shoot() {
        var angle = Vector3.Angle(transform.position, Target.position);
        // var direction = new Vector3(Mathf.Sin(angle), 0, 0);
        var rotation = Quaternion.Euler(0, 0, angle);
            
        var bullet = Instantiate(Bullet, transform.position, rotation);
            
        var direction = Target.position - transform.position;
        direction.Normalize();
            
        bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;
    }
}
