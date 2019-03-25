/****************************************************
	文件：GameRoot.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/25 12:31   	
	功能：游戏启动根节点
*****************************************************/

using UnityEngine;

public class GameRoot : WindowRoot {
    public LoginWnd loginWnd;
    public DesWnd desWnd;
    public LobbyWnd lobbyWnd;
    public HotelWnd hotelWnd;

    public static GameRoot Instance;

    private void Start() {
        Debug.Log("Game Start...");
        Instance = this;
        DontDestroyOnLoad(this);

        InitRoot();
        InitSys();
    }

    private void InitRoot() {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++) {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void InitSys() {
        //服务
        TimerSvc timer = GetComponent<TimerSvc>();
        timer.InitSvc();
        ResSvc res = GetComponent<ResSvc>();
        res.InitSvc();
        AudioSvc audio = GetComponent<AudioSvc>();
        audio.InitSvc();

        //业务


        //打开登录界面
        loginWnd.SetWndState();
    }

    public void OpenDesWnd() {
        desWnd.SetWndState();
    }
}