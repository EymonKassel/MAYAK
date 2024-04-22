//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyDancer : EnemyEntity {
//    [SerializeField] private float _offsetSpeed = 0.25f;

//    [Header("Points (DO NOT CHANGE IN GAME MODE)")]
//    [SerializeField] private Vector3 _startPositon;
//    [SerializeField] private Vector3 _intermediatePosition;
//    [SerializeField] private Vector3 _endPosition;
//    [SerializeField] private bool _gizmoIsActive = true;

//    [Header("AI logic settings")]
//    [SerializeField] private bool _isVertical = false;
//    [SerializeField] private bool _isExlosive = false;
//    [SerializeField] private bool _isTraced = false;
//    private void Awake() {
//        _startPositon = new Vector3(transform.position.x, transform.position.y);
//    }


//    private void Update() {

//    }

//    #region EDITOR METHODS
//    private void OnDrawGizmos() {
//        // Offset
//        if ( _gizmoIsActive ) {
//            // to do left and right offsets
//            Vector3 gizmoStartPosition = new(_startPositon.x, _startPositon.y);
//            Vector3 gizmoIntermediatePosition = new(_startPositon.x - 5f, _startPositon.y);
//            Vector3 gizmoEndPosition = new(_startPositon.x + 5f, _startPositon.y);

//            OnDrawGizmosPositionOffset(gizmoStartPosition, Color.green);
//            OnDrawGizmosPositionOffset(gizmoIntermediatePosition, Color.yellow);
//            OnDrawGizmosPositionOffset(gizmoEndPosition, Color.red);
//        }
//    }
//    private void OnDrawGizmosPositionOffset(Vector3 position, Color color, float radius = 0.25f) {
//        Gizmos.color = color;
//        Gizmos.DrawWireSphere(position, radius);
//    }
//    #endregion
//}
