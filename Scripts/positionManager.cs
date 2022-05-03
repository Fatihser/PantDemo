using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class positionManager : MonoBehaviour
{
    public float[] positions;
    public GameObject player;
    public GameObject[] AI;
    public TextMeshProUGUI orderText;


    private void Update()
    {
        calc();
    }
    public void calc()
    {
        positions[0] = AI[0].GetComponent<enemyControl>().distance;
        positions[1] = AI[1].GetComponent<enemyControl>().distance;
        positions[2] = AI[2].GetComponent<enemyControl>().distance;
        positions[3] = AI[3].GetComponent<enemyControl>().distance;
        positions[4] = AI[4].GetComponent<enemyControl>().distance;
        positions[5] = AI[5].GetComponent<enemyControl>().distance;
        positions[6] = AI[6].GetComponent<enemyControl>().distance;
        positions[7] = AI[7].GetComponent<enemyControl>().distance;
        positions[8] = AI[8].GetComponent<enemyControl>().distance;
        positions[9] = AI[9].GetComponent<enemyControl>().distance;
        positions[10] = AI[10].GetComponent<characterControl>().distance;
        Array.Sort(positions);
        int order = Array.IndexOf(positions, AI[10].GetComponent<characterControl>().distance);
        orderText.text = "ORDER:" + (order + 1);
    }

}
