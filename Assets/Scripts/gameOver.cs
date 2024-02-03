using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    [SerializeField]

    public static bool isGameOver = false;
    // public static gameOver instance;


    private void Awake() {
        // if(instance == null)
        //     instance = this;

        Debug.Log("isgamver = false");
        gameObject.SetActive(false);
        isGameOver = false;
    }
 
    public void checkIfGameOver()
    {
        if(isGameOver == true)    
            gameObject.SetActive(true);
    }

    private void Update() {
        if(isGameOver == true)
        {
            Debug.Log("isgamver = true2");
            gameObject.SetActive(true);
            Debug.Log("isgamver = true3");
        }
        else{
            gameObject.SetActive(false);
        }
    }
}

