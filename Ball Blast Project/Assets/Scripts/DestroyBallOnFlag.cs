using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBallOnFlag : MonoBehaviour
{
    public GameController gameController;
    //public Text gameOverText;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //gameOverPanel.SetActive(true);
            //gameOverText.text = "SUCCESS";
            Destroy(col.gameObject);
            gameController.FinishLevel();
        }
    }
}
