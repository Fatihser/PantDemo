using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActivePaint : MonoBehaviour
{
    public paintWall pw;

    public void duvariBoya()
    {
        pw.StartPainting();
        Debug.Log("camera ici");
    }
}
