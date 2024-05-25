using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : EnemyEntity {
    [SerializeField][Range(0, 100)] private float _pursuitSpeed = 1.0f;

    [Header("AI logic settings")]
    private bool _isFollowing = false;
    private PlayerEntity _playerEntity;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _playerEntity = Player.GetComponent<PlayerEntity>();
        _isFollowing = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.tag.Contains("Player") ) {
            _playerEntity.CurrentHealthPoints--;
            Destroy(gameObject);
        }
        if ( collision.gameObject.tag.Contains("Trace") ) {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        if ( _isFollowing ) Follow();
    }
    private void Follow() {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, _pursuitSpeed * Time.deltaTime);
    }
}
