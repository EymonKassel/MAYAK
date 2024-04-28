using UnityEngine;

public class MagneticGun : MonoBehaviour {
    #region REFERENCES & ATTRIBUTES
    [Header("Scripts")]
    public Magnet Magnet;

    [Header("Layer Settings")]
    [SerializeField] private bool _grappleToAll = false;
    [SerializeField] private int _grappableLayerNumber = 9;
    [SerializeField] private int _enemyLayerNumber = 10;

    [Header("Main Camera")]
    public Camera Camera;
    public Vector3 MousePosition;

    [Header("Transform Refrences")]
    public Transform GunHolder;
    public Transform GunPivot;
    public Transform FirePoint;

    [Header("Rotation")]
    [SerializeField] private bool _rotateOverTime = true;
    [Range(0, 80)][SerializeField] private float _rotationSpeed = 4;

    [Header("Distance")]
    [SerializeField] private bool _hasMaxDistance = true;
    [SerializeField] private float _maxDistance = 4;

    [Header("Launching")]
    [SerializeField] private bool _launchToPoint = true;
    [SerializeField] private LaunchType _LaunchType = LaunchType.TransformLaunch;
    [Range(0, 5)] public float _launchSpeed = 5; //

    [Header("No Launch To Point")]
    [SerializeField] private bool _autoCongifureDistance = false;
    [SerializeField] private float _targetDistance = 3;
    [SerializeField] private float _targetFrequency = 3;

    [Header("My")]
    public PlayerMovement PlayerMovement;
    [SerializeField] private KeyCode ActivationKey = KeyCode.Mouse0;

    //[SerializeField] private bool _touchedEnemy = false;
    //private GameObject _currentEnemy;
    private enum LaunchType {
        TransformLaunch,
        PhysicsLaunch,
    }

    [Header("Component Refrences")]
    public SpringJoint2D SpringJoint2D;

    [HideInInspector] public Vector2 GrapplePoint;
    [HideInInspector] public Vector2 DistanceVector;
    private Vector2 _mouseFirePointDistanceVector;

    public Rigidbody2D PlayerRB2D;
    #endregion

    private void Start() {
        Magnet.enabled = false;
        SpringJoint2D.enabled = false;
        PlayerRB2D.gravityScale = 1;
        PlayerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    private void Update() {
        _mouseFirePointDistanceVector = Camera.ScreenToWorldPoint(Input.mousePosition) - GunPivot.position;

        if ( Input.GetKeyDown(ActivationKey) ) {
            SetGrapplePoint();
            //PlayerMovement.enabled = false;
        } else if ( Input.GetKey(ActivationKey) ) {
            if ( Magnet.enabled ) {
                RotateGun(GrapplePoint, false);
            } else {
                RotateGun(Camera.ScreenToWorldPoint(Input.mousePosition), false);
            }

            if ( _launchToPoint && Magnet.IsGrappling ) {
                if ( _LaunchType == LaunchType.TransformLaunch ) {
                    GunHolder.position = Vector3.Lerp(GunHolder.position, GrapplePoint, Time.deltaTime * _launchSpeed);
                }
            }

        } else if ( Input.GetKeyUp(ActivationKey) ) {
            Magnet.enabled = false;
            SpringJoint2D.enabled = false;
            PlayerRB2D.gravityScale = 1;
            PlayerMovement.enabled = true;
        } else {
            RotateGun(Camera.ScreenToWorldPoint(Input.mousePosition), true);
        }
    }

    private void RotateGun(Vector3 lookPoint, bool allowRotationOverTime) {
        
        
        Vector3 distanceVector = lookPoint - GunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if ( _rotateOverTime && allowRotationOverTime ) {
            Quaternion startRotation = GunPivot.rotation;
            GunPivot.rotation = Quaternion.Lerp(startRotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * _rotationSpeed);
        } else
            GunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //private void RotateGun(Vector3 lookPoint, bool allowRotationOverTime) {
    //    Vector3 distanceVector = lookPoint - GunPivot.position;

    //    float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
    //    if ( _rotateOverTime && allowRotationOverTime ) {
    //        Quaternion startRotation = GunPivot.rotation;
    //        GunPivot.rotation = Quaternion.Lerp(startRotation,
    //            Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * _rotationSpeed);
    //    } else
    //        GunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //}

    private void SetGrapplePoint() {
        if ( Physics2D.Raycast(FirePoint.position, _mouseFirePointDistanceVector.normalized) ) {
            RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, _mouseFirePointDistanceVector.normalized);
            //Debug.Log(hit);
            if ( ( hit.transform.gameObject.layer == _grappableLayerNumber || _grappleToAll )
                && ( ( Vector2.Distance(hit.point, FirePoint.position) <= _maxDistance ) || !_hasMaxDistance ) ) {
                GrapplePoint = hit.point;
                DistanceVector = GrapplePoint - (Vector2)GunPivot.position;
                Magnet.enabled = true;
            }

            //ENEMY FINDER LOGIC
            if ( ( hit.transform.gameObject.layer == _enemyLayerNumber ) && ( ( Vector2.Distance(hit.point, FirePoint.position) <= _maxDistance ) || !_hasMaxDistance ) ) {
                GrapplePoint = hit.point;
                DistanceVector = GrapplePoint - (Vector2)GunPivot.position;
                Magnet.enabled = true;

                //HIT ENEMY
                //_touchedEnemy = true;
                //hit.transform.gameObject.GetComponent<EnemyHealth>().Imhit = true;
            }
        }
    }

    public void Grapple() {
        if ( !_launchToPoint  /*&& !_autoCongifureDistance*/ ) {
            SpringJoint2D.distance = _targetDistance;
            SpringJoint2D.frequency = _targetFrequency;
        }

        if ( !_launchToPoint ) {
            if ( _autoCongifureDistance ) {
                SpringJoint2D.autoConfigureDistance = true;
                SpringJoint2D.frequency = 0;
            }
            SpringJoint2D.connectedAnchor = GrapplePoint;
            SpringJoint2D.enabled = true;
        } else {
            if ( _LaunchType == LaunchType.TransformLaunch ) {
                PlayerRB2D.gravityScale = 0;
                PlayerRB2D.velocity = Vector2.zero;
            }
            if ( _LaunchType == LaunchType.PhysicsLaunch ) {
                SpringJoint2D.connectedAnchor = GrapplePoint;
                SpringJoint2D.distance = 0;
                SpringJoint2D.frequency = _launchSpeed;
                SpringJoint2D.enabled = true;
            }
        }
    }

    //private void OnDrawGizmos() {
    //    if ( _hasMaxDistance ) {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawWireSphere(FirePoint.position, _maxDistance);
    //    }
    //}
}
