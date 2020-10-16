using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVGMachine : MonoBehaviour {

    public enum STATE
    {
        OFF,
        TYPING,
        PAUSED,
        CHOICE
    }

    public STATE state;
    private bool firstEnter = true;
    public story01 data;
    public AVGAssetConfig ac;
    public UIPanel uiPanel;

    [SerializeField]
    private int curLine = 0;

    private string targetString;
    private float timeValue;
    [Range(1,100)]
    public int typingSpeed=10;
	// Use this for initialization
	void Start () {
        firstEnter = true;
        state = STATE.OFF;

    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case STATE.OFF:
                if (firstEnter)
                {
                    Init();
                    ShowUI();
                    firstEnter = false;
                }
                break;
            case STATE.TYPING:
                if (firstEnter)
                {
                    LoadContent(data.dataList[curLine].Dialogtext, data.dataList[curLine].Charaadisplay, data.dataList[curLine].Charabdisplay);
                    firstEnter = false;
                    timeValue = 0;
                }
                UpdateContentString();
                CheckTypingFinished();
                break;
            case STATE.PAUSED:
                if (firstEnter)
                {
                    firstEnter = false;
                }
                break;
            case STATE.CHOICE:
                if (firstEnter)
                {
                    uiPanel.ShowBtns(true);
                    uiPanel.SetBtnText(data.dataList[curLine].Btnatext, data.dataList[curLine].Btnbtext);
                    uiPanel.SetBtnName(data.dataList[curLine].Btnamsg, data.dataList[curLine].Btnbmsg);
                    firstEnter = false;
                }
                break;
            default:
                break;
        }
    }

    public void StartAVG()
    {
        if(state== STATE.OFF)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GoToState(STATE.TYPING);
        }
    }

    public void UserClicked()
    {
        switch (state)
        {
            case STATE.TYPING:
                break;
            case STATE.PAUSED:
                NextLine();
                if (curLine >= data.dataList.Count)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    GoToState(STATE.OFF);
                }
                else
                {
                    GoToState(STATE.TYPING);
                }
                break;
            default:
                break;
        }
    }

    private void GoToState(STATE nextStae)
    {
        state = nextStae;
        firstEnter = true;
    }

    private void  CheckTypingFinished()
    {
        if(state==STATE.TYPING)
        {
            if((int)Mathf.Floor(timeValue * typingSpeed)>=targetString.Length)
            {
                if(data.dataList[curLine].Ischoice)
                {
                    GoToState(STATE.CHOICE);
                }
                else
                {
                    GoToState(STATE.PAUSED);
                }  
            }
            
        }
    }

    private void Init()
    {
        HideUI();
        LoadCharaTexture(ac.charaATex, ac.charaBTex);
        curLine = 0;
    }

    private void ShowUI()
    {
        uiPanel.ShowCanvas(true);
    }

    private void NextLine()
    {
        curLine = curLine + 1;
    }

    private void LoadText(string str)
    {
        uiPanel.SetContent(str);
    }

    private void LoadContent(string str,bool charaADisplay,bool charaBDisplay)
    {
        uiPanel.ShowContentBg(true);
        uiPanel.ShowContent(true);
        //uiPanel.SetContent(str);
        uiPanel.ShowCharaA(charaADisplay);
        uiPanel.ShowCharaB(charaBDisplay);
        targetString = str;
    }

    void UpdateContentString()
    {
        timeValue += Time.deltaTime;
        string tempString = targetString.Substring(0, Mathf.Min((int)(Mathf.Floor(timeValue* typingSpeed)),targetString.Length));
        uiPanel.SetContent(tempString);
    }

    private void LoadCharaTexture(Texture charaATex, Texture charaBTex)
    {
        uiPanel.ChangeCharaATex(charaATex);
        uiPanel.ChangeCharaBTex(charaBTex);
    }

    private void HideUI()
    {
        uiPanel.ShowCanvas(false);
        uiPanel.ShowBtns(false);
    }

    public void ProcessBtnMSG(GameObject go)
    {
        switch(go.name)
        {
            case "GoHome":
                print("GoHome");
                story01 tempStory = Resources.Load<story01>("story02");
                data =tempStory;
                Init();
                ShowUI();
                firstEnter = false;
                GoToState(STATE.TYPING);
                break;
            case "GoShopping":
                print("GoShopping");
                HideUI();
                GameObject door = GameObject.FindGameObjectWithTag("door");
                door.GetComponent<Door>().OpenDoor();
                break;
            default:
                break;
        }
    }
}
