using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public void iniciar()
        {
            SceneManager.LoadScene("Juego");
        }

    public void cargarRecord()
    {
        SceneManager.LoadScene("Records");
    }

    public void cargarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }


}


