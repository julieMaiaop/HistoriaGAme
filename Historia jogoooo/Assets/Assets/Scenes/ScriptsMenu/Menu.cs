using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayJogo()
    {
        SceneManager.LoadScene("cena");
    }

    public void ExitJogo()
    {
        Application.Quit();
        Debug.Log("Fechou o jogo ");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
