using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAttack : MonoBehaviour
{
    private Animator enemyAnimator;

    private float speed;
    private bool attack;
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnimator.SetBool("Attack", attack);
        speed = Random.Range(-1f,1f);
      this.transform.Translate(new Vector3(-0.5f,0.5f,0.0f)* (speed * Time.deltaTime));   
        attack = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            attack = true;
        }
    }
}
