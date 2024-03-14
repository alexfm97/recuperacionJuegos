using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float velocidadDeMovimiento = 1f;
    public float multiplicador = 1.5f;

    private void Start()
    {
        // Inicia el movimiento hacia abajo al instanciar el PowerUp
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -velocidadDeMovimiento);


    }

    public void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            StartCoroutine(recogerPowerUp(otro));
        }
    }

    IEnumerator recogerPowerUp(Collider2D player)
    {
        player.transform.localScale *= multiplicador;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(5f);
        player.transform.localScale /= multiplicador;
        Destroy(gameObject);
    }
}
