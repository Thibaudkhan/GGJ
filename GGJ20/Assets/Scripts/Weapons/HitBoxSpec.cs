using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxSpec : MonoBehaviour
{

    public playerScript playerscript;

    private BoxCollider2D[] hitBoxList;
    private bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        hitBoxList = GetComponents<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0) {

            right = true;
            Debug.Log(right);
            }

        else if (Input.GetAxis("Horizontal") < 0) {
            right = false;

            Debug.Log(right);
            }

        if (Input.GetButton("Fire1") && right) {


            hitBoxList[0].enabled = true;
            hitBoxList[1].enabled = false;
            StartCoroutine(disableHitBox());

            Debug.Log(right);

            }

        else if (Input.GetButton("Fire1") && !right) {

        
            hitBoxList[0].enabled = false;
            hitBoxList[1].enabled = true;
            StartCoroutine(disableHitBox());

            Debug.Log("must be left " + right);

            }

    }

    IEnumerator disableHitBox() {
        yield return new WaitForSeconds(playerscript.currentWeapon._frame_active);
        hitBoxList[0].enabled = false;
        hitBoxList[1].enabled = false;
        }

    }
