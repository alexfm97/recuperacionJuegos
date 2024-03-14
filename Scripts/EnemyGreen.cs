using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    [SerializeField] private GameObject limitLeft, limitRight, limitTop, limitBottom;


    private void OnEnable()
    {
        // Set the limits of the enemy's movement
        limitLeft.transform.position = new Vector2(limitLeft.transform.position.x, Random.Range(-5.5f, 5.5f)); // Set the limitLeft position
        limitRight.transform.position = new Vector2(limitRight.transform.position.x, Random.Range(-5.5f, 5.5f)); // Set the limitRight position
        limitTop.transform.position = new Vector2(Random.Range(-3.5f, 3.5f), limitTop.transform.position.y); // Set the limitTop position
        limitBottom.transform.position = new Vector2(Random.Range(-3.5f, 3.5f), limitBottom.transform.position.y); // Set the limitBottom position
        ResetPosition();
    }

    public void ResetPosition()
    {
        // Selects a random limit from the list to start form
        List<Transform> limits = new List<Transform> { limitLeft.transform, limitRight.transform, limitTop.transform, limitBottom.transform };
        int randomLimit = Random.Range(0, limits.Count);
        transform.position = limits[randomLimit].position;
    }

    void Update()
    {
        player = FindObjectOfType<Player>().transform;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
