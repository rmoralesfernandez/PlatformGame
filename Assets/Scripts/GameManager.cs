using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void GotoScenes()
    {
        SceneManager.LoadScene(1);
    }

    public void Scene1()
    {
        SceneManager.LoadScene(2);
    }

    public void Scene2()
    {
        if(TotalItems.totalStars >= 1)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void Scene3()
    {
        if(TotalItems.totalStars >= 2)
        {
            SceneManager.LoadScene(4);
        }
    }
}
