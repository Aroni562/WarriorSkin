using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider sliderPlayer;
    public Text txtPlayer;

    public float energy = 100;
    public bool stargame;
    private static Vector3 left = new Vector3(-0.1f, 0.1f, 0.1f);
    private static Vector3 right = new Vector3(0.1f, 0.1f, 0.1f);

    // Global Variables
    public float speed = 1.0f;

    // Privates variables but view in the inspector
    [SerializeField]
    private float horizontal;
    [SerializeField]
    private float vertical;

    [SerializeField] private bool attack;
    [SerializeField] private bool walking;

    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderPlayer.value = energy;
        txtPlayer.text = "Jargart :  " + energy.ToString();
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        // Save movement
        walking = MovementPlayer(horizontal, vertical);
        // Evaluate the attack
        attack = (Input.GetKey(KeyCode.Space)) ? true : false;

        Attack(attack);
        Walking(walking);
    }

    private void Attack(bool actionAttack)
    {
        playerAnimator.SetBool("Attack", actionAttack);
    }

    private void Walking(bool playerWalking)
    {
        playerAnimator.SetBool("Walking", playerWalking);
        walking = false;
    }

    private bool MovementPlayer(float axisX, float axisY)
    {
        this.transform.localScale = (horizontal > 0)? right : (horizontal < 0)? left : this.transform.localScale;
    
        this.transform.Translate(Vector3.right * (axisX * speed * Time.deltaTime));
        
        this.transform.Translate(Vector3.up * (axisY * speed * Time.deltaTime));
        
        return (axisX != 0 || axisY != 0) ? true : false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        energy -= 10;
        if (energy == 0)
        {
            playerAnimator.SetBool("Die", true);
            energy = 0;
        }
    }

    public void PressPlay()
    {
        stargame = true;
    }
}
