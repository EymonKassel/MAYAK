using UnityEngine;

public class LevelCenter : MonoBehaviour {
    [SerializeField] private Transform _playerPos;

    private void Update() {
        FollowPlayer();
    }

    private void FollowPlayer() {
        Vector3 pos = new Vector3(gameObject.transform.position.x, _playerPos.position.y);
        gameObject.transform.position = pos;
    }
}
