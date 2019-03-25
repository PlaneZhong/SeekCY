/****************************************************
    文件：LobbyWnd.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class LobbyWnd : WindowRoot {
    public Transform transRegInfo;

    protected override void InitWnd() {
        base.InitWnd();

        RefreshUI();
    }

    private void RefreshUI() {
        SetActive(transRegInfo, false);
    }

    public void ClickLeftDoorBtn() {
        root.OpenHotelWnd();
        SetWndState(false);
    }

    public void ClickRightDoorBtn() {
        //TODO
        SetWndState(false);
    }

    public void ClickRegInfoBtn() {
        SetActive(transRegInfo);
    }

    public void ClickCloseBtn() {
        SetActive(transRegInfo, false);
    }
}