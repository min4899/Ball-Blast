using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetKeyDoor : MonoBehaviour
{
    public GameObject key;
    public GameObject blocks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.GameIsPaused)
        {
            blocks.SetActive(true);
            key.SetActive(true);
        }
    }

}
