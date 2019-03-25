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

        RefreshUI();
    }

    private void RefreshUI() {

    }


    public void ClickRoom201Btn() {
        PlayUIAudio();
    }

    public void ClickRoom202Btn() {
        PlayUIAudio();

    }


    public void ClickRoom203Btn() {
        PlayUIAudio();

    }

    public void ClickRoom204Btn() {
        PlayUIAudio();

    }
}