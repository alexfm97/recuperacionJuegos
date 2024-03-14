using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int enemiesLeft; // Bloques restantes en la escena

    public int vidas = 3;

    [SerializeField] private int pointsEnemyGreenYellow = 10; // Puntos por enemigo Verde o Amarillo
    [SerializeField] private int pointsEnemyPink = 15; // Puntos por enemigo Rosa
    public int points = 0; // Puntos actuales


    private void Awake()
    {
        // Patrón Singleton
        if (Instance != null && Instance != this) // Si ya existe una instancia de GameManager
        {
            Destroy(gameObject); // Destruimos el objeto
        }
        else // Si no existe una instancia de GameManager
        {
            Instance = this; // La creamos
            DontDestroyOnLoad(gameObject); // No se destruirá al cargar una nueva escena
        }
    }

    

    public void EnemyDestroyed()
    {
        enemiesLeft--; // Restamos un enemigo
        if (GameObject.FindGameObjectWithTag("EnemyGreen"))
        {
            FindObjectOfType<UIManager>().AddScore(pointsEnemyGreenYellow); // Añadimos puntos
            points += pointsEnemyGreenYellow; // Añadimos puntos
        }else if(GameObject.FindGameObjectWithTag("EnemyYellow"))
        {
            FindObjectOfType<UIManager>().AddScore(pointsEnemyGreenYellow); // Añadimos puntos
            points += pointsEnemyGreenYellow; // Añadimos puntos
        }
        else if (GameObject.FindGameObjectWithTag("EnemyPink"))
        {
            FindObjectOfType<UIManager>().AddScore(pointsEnemyPink); // Añadimos puntos
            points += pointsEnemyPink; // Añadimos puntos
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recargamos la escena actual
    }

    public void LoseLife(Boolean est)
    {

        vidas--; // Restamos una vida
        FindObjectOfType<UIManager>().LoseLife();
        if (vidas <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOver");

        }
        

    }

    public void AddLife()
    {
        vidas++; // Añadimos una vida
        FindObjectOfType<UIManager>().AddLife();
    }

    

    public void ResetGame()
    {
        points = 0; // Reseteamos los puntos
        vidas = 3; // Reseteamos las vidas
    }
}
