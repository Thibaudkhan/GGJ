using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private float projectionSpeed = 500f * 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("sfsdsfs");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * projectionSpeed);
        }
    }
}
