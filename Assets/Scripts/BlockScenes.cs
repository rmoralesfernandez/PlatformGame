using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScenes : MonoBehaviour
{
    public GameObject StarsScene2;
    public GameObject StarsScene3;

    void Start()
    {
        if(TotalItems.totalStars >= 1)
        {
            StarsScene2.SetActive(false);
        } else
        {
            StarsScene2.SetActive(true);
        }
        
        if(TotalItems.totalStars >= 2)
        {
            StarsScene3.SetActive(false);
        } else
        {
            StarsScene3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TotalItems.totalStars >= 1)
        {
            StarsScene2.SetActive(false);
        }

        if(TotalItems.totalStars >= 2)
        {
            StarsScene3.SetActive(false);
        }
    }
}
