using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    Rigidbody RB;
    bool walkingRight = true;
    Animator anim;
    GameController controller;

    public float speed = 1f;
    public Transform rayStart;
    public GameObject crystalEffect;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        controller = FindObjectOfType<GameController>();
        InvokeRepeating("IncreaseSpeed", 1, 3);
    }

    private void FixedUpdate()
    {
        if (!controller.gameStarted)
            return;
        else
        {
            anim.SetTrigger("GameStarted");
        }
        RB.transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swithch();
        }

        if (transform.position.y < -0)
        {
            anim.SetTrigger("Falling");
        }

        if (transform.position.y < -2)
        {
            controller.EndGame();
        }

    }

    private void Swithch()
    {
        if (!controller.gameStarted)
            return;

        walkingRight = !walkingRight;
        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Crystal")
        {
            controller.IncreaseScore();

            GameObject temp = Instantiate(crystalEffect, other.transform.position, Quaternion.identity);
            Destroy(temp, 1f);
            Destroy(other.gameObject);
        }
    }

    private void IncreaseSpeed()
    {
        if(controller.gameStarted)
        speed+=0.25f;
    }

}
