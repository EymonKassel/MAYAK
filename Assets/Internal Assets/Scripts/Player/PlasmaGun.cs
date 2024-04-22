using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaGun : MonoBehaviour {
    public Transform GunPivot;
    public Camera Camera;
    public GameObject Trace;

    [SerializeField] private bool _rotateOverTime = true;
    [Range(0, 80)][SerializeField] private float _rotationSpeed = 4;
    [SerializeField] private KeyCode _activationKey = KeyCode.Mouse0;

    [SerializeField] private float _counterLimit = 50;
    [SerializeField] private float _chargingSpeed = 0.25f;

    public int AmountOfDamage = 1;

    private void Update() {
        RotateGun(Camera.ScreenToWorldPoint(Input.mousePosition), true);
        if ( Input.GetKeyDown(_activationKey) ) {
            StartCoroutine(LaserCharging());
        }
        if ( Input.GetKeyUp(_activationKey) ) {
            StopAllCoroutines();
            Trace.SetActive(false);

        }
    }

    private IEnumerator LaserCharging() {
        for ( int i = 0; i < _counterLimit; i++ ) {
            yield return new WaitForSeconds(_chargingSpeed);
            Debug.Log($"charge {i + 1}");
        }
        Trace.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        Trace.SetActive(false);
        yield break;
    }

    private void RotateGun(Vector3 lookPoint, bool allowRotationOverTime) {
        Vector3 distanceVector = lookPoint - GunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if ( _rotateOverTime && allowRotationOverTime ) {
            Quaternion startRotation = GunPivot.rotation;
            GunPivot.rotation = Quaternion.Lerp(startRotation,
                Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * _rotationSpeed);
        } else
            GunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
