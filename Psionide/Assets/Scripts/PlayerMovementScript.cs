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

    private Rigidbody2D _rigidbody2D;
    private CameraShakeScript _cameraShake;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
    }

    private void Start() {
        _originalPositon = transform.position;
    }

    void Update() {
        // Debug.DrawRay(transform.position, _newPosition, Color.red);
        Debug.DrawRay(new Vector3(0, 0, 0), _newPosition, Color.green);
        // Debug.Log(_isMoving);

        var step = Speed * Time.deltaTime;
        var touches = Input.touches;

        if (!_isMoving) {
            if (touches.Length == 1) {
                _isMoving = true;
                var mainFinger = touches[0];

                if (mainFinger.phase == TouchPhase.Began) {
                    // _newPosition = mainFinger.position;
                    // _newPosition = RaycastScript.RayHitPoint(mainFinger.position);
                }
            }
            else if (Input.GetMouseButtonDown(0)) {
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

                if (_newPosition != new Vector3(0, 0, 0)) {
                    _isMoving = true;
                }
                
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }

        if (_isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);
        }

        // Debug.Log(RaycastScript.RayHitTarget(_originalPositon, _newDirection).collider.transform.position);
    }

    void OnCollisionEnter2D(Collision2D other) {
        var direction = transform.InverseTransformDirection(other.transform.position);
        
        if (_canCollide) {
            if (other.gameObject.CompareTag("Wall")) {
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
                        break;
                        
                    case "down":
                        Debug.Log("Hit the bottom side!");
                        break;
                        
                    default:
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        break;
                }

                _cameraShake.Shake(x: 0.2f, y: 0.2f);
            }
            else if (other.gameObject.CompareTag("WallTrigger")) {
                
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
}