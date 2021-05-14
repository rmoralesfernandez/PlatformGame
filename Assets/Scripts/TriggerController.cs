using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {
    
    private  GameObject plank;
    private int _speed = 30;
    private float time;
    private Vector2 doorFinslPosition;

     void Start()
    {
        plank = GameObject.FindGameObjectWithTag("Plank");
    }

     void Update()
    {
        Debug.Log(DoorController.actived);
        string levelName = Application.loadedLevelName;

        if(levelName == "Scene1" || levelName == "Scene3")
        {
            time = 10;
            if (DoorController.actived == true)
            {
                time -= Time.deltaTime;
                plank.SetActive(false);
                if (time <= 0)
                {
                    DoorController.actived = false;
                    plank.SetActive(true);
                    time = 10;
                }
            }
        }
        
        if(levelName == "Scene2")
        {
            time = 30;
            if(DoorController.actived == true)
            {
                time -= Time.deltaTime;
                plank.SetActive(false);
                if(time <= 0)
                {
                    DoorController.actived = false;
                    plank.SetActive(true);
                    time = 30;
                }
            }
        }
    }

}
