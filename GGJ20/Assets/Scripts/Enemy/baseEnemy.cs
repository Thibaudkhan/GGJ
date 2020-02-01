using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class BasicEnemy : MonoBehaviour {
    public Transform target;
    private Enemy basicEnemy;

    private void OnEnable() {
        basicEnemy = new Enemy("Peon", 1, 1, 0.6f, 2, "trash", 2, true);
    }


    // Use this for initialization
    void Start() {
        Rest();
        }

    // Update is called once per frame
    void Update() {

        }

    public void MoveToPlayer() {
        //rotate to look at player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        //move towards player
        if (Vector3.Distance(transform.position, target.position) > basicEnemy._range) {
            transform.Translate(new Vector3(basicEnemy._speed * Time.deltaTime, 0, 0));
            }
        }

    public void Rest() {
        }
    }