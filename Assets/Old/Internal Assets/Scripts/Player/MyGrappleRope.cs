using UnityEngine;

public class MyGrappleRope : MonoBehaviour {
    [Header("General refrences")]
    public MyGrapplingGun GrapplingGun;
    [SerializeField] private LineRenderer _lineRenderer;

    [Header("General Settings")]
    [SerializeField] private int _percision = 20;
    [Range(0, 100)][SerializeField] private float _straightenLineSpeed = 4;

    [Header("Animation")]
    public AnimationCurve RopeAnimationCurve;
    [SerializeField][Range(0.01f, 4)] public float WaveSize = 20;
    private float _waveSize;

    [Header("Rope Speed")]
    public AnimationCurve RopeLaunchSpeedCurve;
    [SerializeField][Range(1, 50)] private float _ropeLaunchSpeedMultiplayer = 4;

    private float _moveTime = 0;

    [SerializeField] public bool IsGrappling = false;

    private bool _drawLine = true;
    private bool _straightLine = true;

    private void Awake() {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _lineRenderer.positionCount = _percision;
        _waveSize = WaveSize;
    }

    private void OnEnable() {
        _moveTime = 0;
        _lineRenderer.enabled = true;
        _lineRenderer.positionCount = _percision;
        _waveSize = WaveSize;
        _straightLine = false;
        LinePointToFirePoint();
    }

    private void OnDisable() {
        _lineRenderer.enabled = false;
        IsGrappling = false;
    }

    private void LinePointToFirePoint() {
        for ( int i = 0; i < _percision; i++ ) {
            _lineRenderer.SetPosition(i, GrapplingGun.FirePoint.position);
        }
    }

    private void Update() {
        _moveTime += Time.deltaTime;

        if ( _drawLine ) {
            DrawRope();
        }
    }

    private void DrawRope() {
        if ( !_straightLine ) {
            if ( _lineRenderer.GetPosition(_percision - 1).x != GrapplingGun.GrapplePoint.x ) {
                DrawRopeWaves();
            } else {
                _straightLine = true;
            }
        } else {
            if ( !IsGrappling ) {
                GrapplingGun.Grapple();
                IsGrappling = true;
            }
            if ( _waveSize > 0 ) {
                _waveSize -= Time.deltaTime * _straightenLineSpeed;
                DrawRopeWaves();
            } else {
                _waveSize = 0;
                DrawRopeNoWaves();
            }
        }
    }

    private void DrawRopeWaves() {
        for ( int i = 0; i < _percision; i++ ) {
            float delta = (float)i / ( (float)_percision - 1f );
            Vector2 offset = Vector2.Perpendicular(GrapplingGun.DistanceVector).normalized * RopeAnimationCurve.Evaluate(delta) * _waveSize;
            Vector2 targetPosition = Vector2.Lerp(GrapplingGun.FirePoint.position, GrapplingGun.GrapplePoint, delta) + offset;
            Vector2 currentPosition = Vector2.Lerp(GrapplingGun.FirePoint.position, targetPosition, RopeLaunchSpeedCurve.Evaluate(_moveTime) * _ropeLaunchSpeedMultiplayer);

            _lineRenderer.SetPosition(i, currentPosition);
        }
    }

    private void DrawRopeNoWaves() {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, GrapplingGun.GrapplePoint);
        _lineRenderer.SetPosition(1, GrapplingGun.FirePoint.position);
    }
}
