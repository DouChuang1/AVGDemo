using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour {

    public RawImage charaAImg;
    public RawImage charaBImg;
    public Image contentBg;
    public Text content;
    public Canvas canvas;
    public GameObject btnA;
    public GameObject btnB;

    public void ShowBtns(bool value)
    {
        btnA.SetActive(value);
        btnB.SetActive(value);
    }

    public void SetBtnName(string nameA, string nameB)
    {
        btnA.name = nameA;
        btnB.name = nameB;
    }

    public void SetBtnText(string textA,string textB)
    {
        Text texA = btnA.GetComponentInChildren<Text>();
        Text texB = btnB.GetComponentInChildren<Text>();
        texA.text = textA;
        texB.text = textB;
    }
    public void ShowCanvas(bool canvasDisplay)
    {
        canvas.gameObject.SetActive(canvasDisplay);
    }

    public void ShowCharaA(bool value)
    {
        charaAImg.gameObject.SetActive(value);
    }

    public void ShowCharaB(bool value)
    {
        charaBImg.gameObject.SetActive(value);
    }

    public void ShowContentBg(bool value)
    {
        contentBg.gameObject.SetActive(value);
    }

    public void ShowContent(bool value)
    {
        content.gameObject.SetActive(value);
    }

    public void SetContent(string value)
    {
        content.text = value;
    }

    public void ChangeCharaATex(Texture tex)
    {
        charaAImg.texture = tex;
    }

    public void ChangeCharaBTex(Texture tex)
    {
        charaBImg.texture = tex;
    }
}
