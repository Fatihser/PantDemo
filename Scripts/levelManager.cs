using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public positionManager posManager;
    private Animator animCont;
    private characterControl charCont;
    public GameObject retryCanvas;
    private Rigidbody rb;
    public Animator cameraAnim;
    public GameObject startPanel;
    public static bool firstLoad = true;
    public void gameStartBut()
    {
        Destroy(startPanel);
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        if (firstLoad)
        {
            Time.timeScale = 0.0f;
            firstLoad = false;
        }
        else
        {
            Time.timeScale = 1.0f;
            Destroy(startPanel);
        }
        animCont = GetComponent<Animator>();
        charCont = GetComponent<characterControl>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="obs")
        {
            charCont.enabled = false;
            animCont.SetTrigger("die");
            //player carptiginda tekrar dogcak ise enemyControl scriptindeki gibi baslangic degeri alinip
            //olum animinin sonuna event koyularak o event ile tekrar diriltilebilir
        }
        else if (other.gameObject.tag=="finish")
        {
            charCont.enabled = false;
            cameraAnim.enabled = true;
            posManager.enabled = false;
        }
    }

    public void openRetryCanvas()
    {
        //zaman durdurmasi kaldirilabilir.
        Time.timeScale = 0.0f;
        retryCanvas.SetActive(true);
    }

    public void retryMethod()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
