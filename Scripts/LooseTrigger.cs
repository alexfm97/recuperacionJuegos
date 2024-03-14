using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyGreen") || collision.CompareTag("EnemyPink") || collision.CompareTag("EnemyYellow") || collision.CompareTag("LaserEnemy"))
        {
            // GameManager.Instance.ReloadScene(); // Recargamos la escena
            GameManager.Instance.LoseLife(true);
            
            
        }

        if (collision.CompareTag("powerUp")) // Si colisionamos con un powerUp lo destruimos
        {
            Destroy(collision.gameObject);
        }
    }
}
