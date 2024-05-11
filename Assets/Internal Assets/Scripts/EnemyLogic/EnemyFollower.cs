using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : EnemyEntity {
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject EnemyBullet;

    [SerializeField][Range(0, 100)] private float _pursuitSpeed = 1.0f;

    [Header("AI logic settings")]
    [SerializeField] private bool _isFollowing = false;
    [SerializeField] private bool _isDetonating = false;
    [SerializeField] private bool _isShooting = false;
    [SerializeField] private bool _isDashing = false;

    private void Awake() {
        _isFollowing = true;
    }

    private void Update() {
        if ( _isFollowing ) Follow();

    }
    private void Follow() {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, _pursuitSpeed * Time.deltaTime);
    }
    private IEnumerator Detonate() {
        yield return null;
    }
    private void Shoot() {
        Instantiate(EnemyBullet);
    }
    private void Dash() {

    }
}
