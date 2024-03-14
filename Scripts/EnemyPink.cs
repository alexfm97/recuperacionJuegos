using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPink : MonoBehaviour
{
    [SerializeField] private GameObject laserEnemyPrefab;
    [SerializeField] private float speed, delay;
    [SerializeField] private GameObject wayPointA, wayPointB, objective;
    private Animator animator;
    private Vector3 shootPosition;



    void OnEnable()
    {
        StartCoroutine(Shoot());
        ResetPosition();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, objective.transform.position) < 0.2f)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        // Selects a random limit from A or B to start form depending on a Random number
        if (Random.Range(0, 2) == 0)
        {
            transform.position = wayPointA.transform.position;
            objective = wayPointB;
        }
        else
        {
            transform.position = wayPointB.transform.position;
            objective = wayPointA;
        }        
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            shootPosition = transform.GetChild(0).transform.position; // Get the position of the shoot point
            Instantiate(laserEnemyPrefab, shootPosition, Quaternion.identity);
            animator.SetTrigger("Shooting");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser" || collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
