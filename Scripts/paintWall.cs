using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paintWall : MonoBehaviour
{
    private Renderer objectRenderer;

    public float paintDelay = 1.5f;

    private bool isPainting;
    private Color newColor;

    public bool IsPainting { get => isPainting; private set => isPainting = value; }
    public Color NewColor { get => newColor; private set => newColor = value; }

    public event Action onDone;

    public TextMeshProUGUI progressText;
    public GameObject changeColorBut;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.SetFloat("Vector1_a1ffda319901419aacc1202d3c50112f", 0);//paint amount
        //Unity rutin kaydetme seklinden bu projede vazgectigi icin bu sekilde kaydetmis ozellikleri.
        SetColor(Color.blue);
    }

    public void StartPainting()
    {
        isPainting = true;
        progressText.enabled = true;
        changeColorBut.SetActive(true);
        StartCoroutine(PaintCoroutine());
        Debug.Log("duvar ici");
    }

    public void changeColorToRed()
    {
        objectRenderer.material.SetColor("Color_981bc73758ee47f494a19e555919ccfe", Color.red);
    }

    public void SetColor(Color colorToPaint)
    {
        NewColor = colorToPaint;
    }

    private IEnumerator PaintCoroutine()
    {
        float currentTime = 0;
        objectRenderer.material.SetColor("Color_981bc73758ee47f494a19e555919ccfe", NewColor);//PaintColor
        while (currentTime<paintDelay)
        {
            currentTime += Time.deltaTime;
            float amount = Mathf.Clamp01(currentTime / paintDelay);
            progressText.text = "Progress:" + (amount * 100).ToString("n2");
            objectRenderer.material.SetFloat("Vector1_a1ffda319901419aacc1202d3c50112f", amount);//paintamount
            yield return null;
        }
        objectRenderer.material.SetColor("Color_b58ec4125f5b439c9ff78b10871dcdad", NewColor);//color
        objectRenderer.material.SetFloat("Vector1_a1ffda319901419aacc1202d3c50112f", 1);//paintamount
        isPainting = false;
        onDone?.Invoke();
    }
}
