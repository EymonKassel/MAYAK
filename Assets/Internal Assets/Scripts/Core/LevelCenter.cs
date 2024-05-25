using UnityEngine;

public class LevelCenter : MonoBehaviour {
    [SerializeField] private Transform _playerPos;
    [SerializeField][Range(-100, 100)] private float _pointOffsetY;

    private void FixedUpdate() {
        FollowPlayer();
    }

    private void FollowPlayer() {
        Vector3 pos = new(gameObject.transform.position.x, _playerPos.position.y + _pointOffsetY);
        gameObject.transform.position = pos;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Vector3 gizmoPointPosition = new(gameObject.transform.position.x, gameObject.transform.position.y + _pointOffsetY, gameObject.transform.position.z);
        Gizmos.DrawWireSphere(gizmoPointPosition, 0.25f);
    }
}
