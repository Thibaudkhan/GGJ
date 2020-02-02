using UnityEngine;
using System.Collections;

public class GunShot : MonoBehaviour {
    private float projectionSpeed = 40f * 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("sfsdsfs");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * projectionSpeed);
            }
        }
    }
