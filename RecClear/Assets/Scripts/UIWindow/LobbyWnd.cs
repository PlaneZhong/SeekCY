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

    public GameObject Character;

    protected override void InitWnd() {
        base.InitWnd();
        LoadChar();
        RefreshUI();
    }

    private void RefreshUI() {
        SetActive(transRegInfo, false);
    }

    private void LoadChar() {
        Character = resSvc.LoadPrefab(Constants.CharacterPrefab);
        Character.transform.localPosition = new Vector3(0, 5, 0);
        Character.transform.localScale = Vector3.one;
    }

    #region Click Evts
    public void ClickLeftDoorBtn() {
        PlayUIAudio(Constants.UIClickBtn);

        root.OpenHotelWnd();
        //SetWndState(false);
    }

    public void ClickRightDoorBtn() {
        PlayUIAudio(Constants.UIClickBtn);
        root.AddTips("正在开发中...");
        //TODO
        //SetWndState(false);
    }

    public void ClickRegInfoBtn() {
        PlayUIAudio();
        SetActive(transRegInfo);
    }

    public void ClickCloseBtn() {
        PlayUIAudio();
        SetActive(transRegInfo, false);
    }
    #endregion
}