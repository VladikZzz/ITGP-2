using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float pointOfView = 120f;
    public float coolDown = 1.5f;
    public float speed = 1.2f;
    private Vector2 _cannon2D;
    private Vector3 _initialVelocity;
    public float counter;

    private Camera _cam;

    void Start() {
        counter = Time.time;
    }

    // Update is called once per frame
    void Update()
    {   
        var targets = GameObject.FindGameObjectsWithTag("Target");
         _cannon2D = new Vector2(transform.position.x, transform.position.y);
         foreach(var target in targets) {
            if((Time.time - counter) >= coolDown) {
                if(checkView(target)) {
                    _Fire(target);
                }
                counter = Time.time;
            }
        }
    }

    public bool checkView(GameObject target) {
        Vector3 v = target.transform.position;
        Vector3 tgDirection = v - transform.position;
        float angle = Vector3.Angle(tgDirection, Vector3.forward);
        if(angle <= pointOfView) {
            return true;
        }
        return false;
    }

    private void _Fire(GameObject target) {
        Vector3 v = target.transform.position;
        transform.LookAt(v);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        var direction = v - transform.position;
        rb.AddForce(direction, ForceMode.Impulse);
    }
}
