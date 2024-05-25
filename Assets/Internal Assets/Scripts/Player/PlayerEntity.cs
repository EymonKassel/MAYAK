using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerEntity : MonoBehaviour {
    public int MaxHealthPoints = 1;
    public int CurrentHealthPoints;
    public int HealthRegenRateInSeconds = 5;

    [SerializeField] private GameObject _currentSavePoint;

    private void Awake() {
        CurrentHealthPoints = MaxHealthPoints;
    }

    private void FixedUpdate() {
        if ( CurrentHealthPoints <= 0 ) {
            StopAllCoroutines();
            Debug.Log("Player dead");
            //gameObject.transform.position = _currentSavePoint.transform.position;
            //CurrentHealthPoints = MaxHealthPoints;
            SceneManager.LoadScene("Level_1");
        }
        if ( CurrentHealthPoints < MaxHealthPoints ) {
            StartCoroutine(HealthRegen());
        }
        if ( CurrentHealthPoints >= MaxHealthPoints ) {
            StopCoroutine(HealthRegen());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.gameObject.tag.Contains("Enemy") ) {
            CurrentHealthPoints--;
            Debug.Log("Player on hit");
        }
    }

    private IEnumerator HealthRegen() {

        yield return new WaitForSeconds(HealthRegenRateInSeconds);

        yield return null;
    }
}
