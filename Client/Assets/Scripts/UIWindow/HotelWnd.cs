/****************************************************
	文件：HotelWnd.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/25 13:49   	
	功能：Hotel界面
*****************************************************/

using UnityEngine;

public class HotelWnd : WindowRoot {
    protected override void InitWnd() {
        base.InitWnd();

        PlayBGMusic(Constants.HotelBG);
        RefreshUI();
    }

    private void RefreshUI() {
    }


    public void ClickRoom201Btn() {
        PlayUIAudio();
        root.AddTips("正在开发中...");
    }

    public void ClickRoom202Btn() {
        PlayUIAudio();
        root.AddTips("正在开发中...");
    }


    public void ClickRoom203Btn() {
        PlayUIAudio();
        root.AddTips("正在开发中...");
    }

    public void ClickRoom204Btn() {
        PlayUIAudio();
        root.AddTips("正在开发中...");
    }

    public void ClickQuitBtn() {
        PlayUIAudio();
        PlayBGMusic(Constants.MainBG);
        SetWndState(false);
    }
}