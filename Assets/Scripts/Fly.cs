using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fly : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity = 1;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        //anim.Play("Tails_Fly_Animation");
        if(Input.GetMouseButtonDown(0))
        {
            //Fly
            rb.velocity = Vector2.up * velocity;
            //Play Grunt animation
            //anim.Play("Tails_Grunt_Animation");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
        GetComponent<AudioSource>().Play();
        anim.Play("Tails_Death_Animation");
    }
}
