using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsLimit : MonoBehaviour
{
    //mobil cihazlarda fps limiti olmadiginda isinmaya ve asiri sarj tuketimine neden oldugu icin fps limiti koydum.
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
