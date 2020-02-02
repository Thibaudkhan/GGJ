using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float speedScaling = 0.2f;
    private bool hitting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitting = true;
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hitting)
        {
            float direction = Input.GetAxis("Vertical");
            //anim.SetBool("isWalking", true);
            //anim.SetBool("isClimbing", true);
            //anim.Play("PlayerLadder");

            if (direction > 0)
            {
                collision.gameObject.GetComponent<Animator>().speed = 1;
                collision.gameObject.SendMessage("play", "isClimbing");
                collision.gameObject.transform.position += Vector3.up * Time.deltaTime * speedScaling;
            }
            else if (direction < 0)
            {
                collision.gameObject.GetComponent<Animator>().speed = 1;
                collision.gameObject.SendMessage("play", "isClimbing");
                collision.gameObject.transform.position += Vector3.down * Time.deltaTime * speedScaling;
            }
            else
            {
                //collision.gameObject.GetComponent<Animator>().speed = 0;
                collision.gameObject.transform.position += Vector3.zero;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        //collision.gameObject.GetComponent<Animator>().SetBool("isClimbing", true);
        //Animator anim = collision.gameObject.GetComponent<Animator>();
        //anim.Play("PlayerIdle");
        collision.gameObject.SendMessage("disableClimbing");
        hitting = false;
    }
}
