/****************************************************
	文件：LoginWnd.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/25 12:31   	
	功能：登录界面
*****************************************************/

using UnityEngine;

public class LoginWnd : WindowRoot {

    protected override void InitWnd() {
        base.InitWnd();

        PlayBGMusic(Constants.MainBG);
    }

    public void ClickBtnNew() {
        PlayUIAudio();

        root.OpenDesWnd();
        SetWndState(false);
    }

    public void ClickChaptersBtn() {
        PlayUIAudio();
        root.AddTips("正在开发中...");
    }

    public void ClickBtnOptions() {
        PlayUIAudio();
        root.AddTips("正在开发中...");
    }

    public void ClickBtnQuit() {
        PlayUIAudio();
        root.AddTips("正在开发中...");
    }
}