using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvPoint : MonoBehaviour
{
    public string lvlName;

    void OnCollisionEnter2D(Collision2D groundCollision)
    {
        if(groundCollision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvlName);   
        }
    }
}
