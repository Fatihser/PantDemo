using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    //Character controller kullanilabilir fakat basit bir hyper-casual oyun icin gerekli olmadigini dusundum.

    public static float moveSpeed = 7;
    public static float rotateSpeed = 9f;
    public float distance;
    public Transform finishWall;
    //character controller oturmazsa onla ilgili seyler islincek digerine gecilcek.
    //public CharacterController cc;

    //private void Start()
   // {
        //cc = GetComponent<CharacterController>();
    //}
    void FixedUpdate()
    {
        gameObject.transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        distance = Vector3.Distance(finishWall.position, transform.position);   
        //cc.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime));
        playerControl();
    }

    void playerControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(rotateSpeed * Time.deltaTime, 0,0);
            //cc.Move(new Vector3(rotateSpeed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-rotateSpeed * Time.deltaTime, 0,0);
            //cc.Move(new Vector3(-rotateSpeed * Time.deltaTime, 0, 0));
        }
    }
}
