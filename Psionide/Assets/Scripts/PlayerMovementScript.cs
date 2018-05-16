using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    [Range(0, 30)] public float Speed = 17;

    private bool _isMoving = false;
    private Vector3 _originalPositon;
    private Vector3 _newPosition;
    private Vector3 _oldDirection;
    private Vector3 _newDirection;

    private bool _canCollide = true;
    private bool _isRotating = false;
    private bool _mobilePressed = false;
    private bool _mousePressed = false;

    private Rigidbody2D _rigidbody2D;
    private CameraShakeScript _cameraShake;
    private Animator _animator;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
    }

    private void Start() {
        _originalPositon = transform.position;
    }

    void Update() {
        // Debug.DrawRay(transform.position, _newPosition, Color.red);
        Debug.DrawRay(new Vector3(0, 0, 0), _newPosition, Color.green);
        // Debug.Log(_isMoving);

        var touches = Input.touches;

        if (!_isMoving) {
            // TODO: Move mouse and touch movement to a single static function in the Util class
            if (touches.Length == 1) {
                _animator.SetTrigger("PlayerJump");
                _mobilePressed = true;
            }
            else if (Input.GetMouseButtonDown(0)) {
                _animator.SetTrigger("PlayerJump");
                _mousePressed = true;
            }
        }

        // Debug.Log(RaycastScript.RayHitTarget(_originalPositon, _newDirection).collider.transform.position);
    }

    private void FixedUpdate() {
        var step = Speed * Time.deltaTime;
        
        if (_mobilePressed) {
            var touches = Input.touches;
            
            var mainFinger = touches[0];

            if (mainFinger.phase == TouchPhase.Began) {
                var fingerPosition = Camera.main.ScreenToWorldPoint(mainFinger.position);
                // _newPosition = RaycastScript.RayHitPoint(mainFinger.position);

                var cameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
                var angle = Vector3.Angle(cameraCenter, fingerPosition);
                _newDirection = new Vector3(Mathf.Sin(angle), 0, 0);

                if (_oldDirection.x >= 0.1 && _newDirection.x >= 0.1 ||
                    _oldDirection.x <= -0.1 && _newDirection.x <= -0.1) {
                    // Debug.Log("Same direction!");
                    _newDirection = new Vector3(-Mathf.Sin(angle), 0, 0);
                }

                _newPosition = Util.RayHitPoint(fingerPosition, _newDirection);

                if (_newPosition != _originalPositon) {
                    _isMoving = true;
                }
                
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }

            _mobilePressed = false;
        }

        if (_mousePressed) {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var cameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
            var angle = Vector3.Angle(cameraCenter, mousePosition);
            _newDirection = new Vector3(Mathf.Sin(angle), 0, 0);

            if (_oldDirection.x >= 0.1 && _newDirection.x >= 0.1 ||
                _oldDirection.x <= -0.1 && _newDirection.x <= -0.1) {
                // Debug.Log("Same direction!");
                _newDirection = new Vector3(-Mathf.Sin(angle), 0, 0);
            }

            // Debug.Log(angle);
            // Debug.Log(_newDirection);

            _newPosition = Util.RayHitPoint(mousePosition, _newDirection);

            if (_newPosition != _originalPositon) {
                _isMoving = true;
            }
                
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            _mousePressed = false;
        }

        if (_isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        _animator.SetTrigger("PlayerLand");
        
        if (_canCollide) {
            if (Util.IsWall(other.gameObject)) {
                Debug.Log("Hit a wall!");

                switch (Util.CollidedSide(other, transform)) {
                    case "right": 
                        Debug.Log("Hit the right side!");
                        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                        break;
                        
                    case "left":
                        Debug.Log("Hit the left side!");
                        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                        break;
                        
                    case "up":
                        Debug.Log("Hit the top side!");
                        transform.rotation = Quaternion.Euler(0f, 0f, -180f);
                        break;
                        
                    case "down":
                        Debug.Log("Hit the bottom side!");
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        break;
                        
                    default:
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        break;
                }

                _cameraShake.Shake(x: 0.2f, y: 0.2f);
            }
        }
        
        _isMoving = false;

        _originalPositon = _newPosition;
        _oldDirection = _newDirection;
        
        _canCollide = false;
    }

    private void OnCollisionExit2D(Collision2D other) {
        _canCollide = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(string.Format("Hit: {0}", other.name));
        
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        
        if (other.gameObject.CompareTag("ContactDamage")) {
            Util.IsDead = true;
            Destroy(gameObject);
            GameObject.Find("Canvas").transform.Find("DeathMenu").gameObject.SetActive(true);
        }
    }
}