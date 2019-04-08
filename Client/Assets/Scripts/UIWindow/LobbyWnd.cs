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
    public Transform transLeftDoor;
    public Transform transRightDoor;
    private GameObject Player;
    private Animator ani;

    private Vector3 tempPos;
    protected override void InitWnd() {
        base.InitWnd();
        LoadChar();
        RefreshUI();
    }

    private void LoadChar() {
        Player = resSvc.LoadPrefab(Constants.CharacterPrefab);
        Player.name = "LobbyPlayer";
        tempPos = new Vector3(0, 2.5f, 1);
        Player.transform.localPosition = tempPos;
        Player.transform.localScale = Vector3.one;
        ani = Player.GetComponent<Animator>();
        root.Player = Player;
        root.ani = ani;
    }

    private void RefreshUI() {
        SetActive(transRegInfo, false);
    }

    public void ClickLeftDoorBtn() {
        PlayUIAudio(Constants.UIClickBtn);

        Player.transform.localScale = Vector3.one;
        ani.SetInteger("Action", 1);
        NavSys.Instance.NavToPos(Player.transform, transLeftDoor.position, () => {
            ani.SetInteger("Action", 0);
            //Destroy(Player);
            tempPos = Player.transform.position;
            root.OpenHotelWnd();
        });
        //SetWndState(false);
    }

    public void ClickRightDoorBtn() {
        PlayUIAudio(Constants.UIClickBtn);
        Player.transform.localScale = new Vector3(-1, 1, 1);
        ani.SetInteger("Action", 1);
        NavSys.Instance.NavToPos(Player.transform, transRightDoor.position, () => {
            ani.SetInteger("Action", 0);
            root.AddTips("正在开发中...");
        });
        //TODO
        //SetWndState(false);
    }

    public void ClickRegInfoBtn() {
        PlayUIAudio();
        ani.SetInteger("Action", 0);
        NavSys.Instance.NavStop();
        Player.SetActive(false);
        SetActive(transRegInfo);
    }

    public void ClickCloseBtn() {
        PlayUIAudio();
        Player.SetActive(true);
        SetActive(transRegInfo, false);
    }

    public void SetToTempPos() {
        Player.transform.position = tempPos;
    }
}