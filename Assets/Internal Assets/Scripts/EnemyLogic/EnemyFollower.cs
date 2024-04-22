//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyFollower : EnemyEntity {
//    [SerializeField][Range(0, 100)] private float _pursuitSpeed = 1.0f;

//    [Header("AI logic settings")]
//    private bool _isFollowing = false;
//    [SerializeField] private bool _isGlitched = false;
//    [SerializeField] private bool _isShooter = false;
//    [SerializeField] private bool _isCareful = false;

//    [Header("Shooter")]
//    [SerializeField] private float _fireRate = 1.0f;
//    [SerializeField] private float _bulletSpeed = 1.0f;


//    private void Awake() {
//        //_isFollowing = true;
//    }

//    private void Update() {
//        //if (_isFollowing) Follow();
//        //BeCareful();


//        // This can be replaced with a state machine or something like that, but I haven’t figured out how
//        if ( _isGlitched ) BeGlitched();
//        if ( _isShooter ) BeShooter();
//        if ( _isCareful ) BeCareful();
//    }
//    private void Follow() {
//        transform.position = Vector3.MoveTowards(transform.position, Player.position, _pursuitSpeed * Time.deltaTime);
//    }
//    private void BeCareful() {
//        int i = 0;


//        bool isCompletedCircle = false;
//        while ( !isCompletedCircle && i != 1000 ) {
//            transform.position = Vector2.Lerp(Vector2.zero, Vector2.one, 5f);




//            i++;
//        }
//    }
//    private void BeShooter() {

//    }
//    private void BeGlitched() {

//    }
//}
