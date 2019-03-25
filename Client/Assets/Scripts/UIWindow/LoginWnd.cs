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
    }

    public void ClickBtnNew() {
        root.OpenDesWnd();
        SetWndState(false);
    }

    public void ClickChaptersBtn() {
    }

    public void ClickBtnOptions() {
    }

    public void ClickBtnQuit() {
    }
}