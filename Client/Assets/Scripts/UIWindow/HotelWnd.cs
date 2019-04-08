/****************************************************
	文件：HotelWnd.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/25 13:49   	
	功能：Hotel界面
*****************************************************/

using UnityEngine;

public class HotelWnd : WindowRoot {
    public Transform trans201;
    public Transform trans202;
    public Transform trans203;
    public Transform trans204;

    private Vector3 pos201;
    private Vector3 pos202;
    private Vector3 pos203;
    private Vector3 pos204;


    private GameObject Player;
    private Animator ani;

    protected override void InitWnd() {
        base.InitWnd();
        PlayBGMusic(Constants.HotelBG);
        //LoadChar();
        RefreshUI();
    }

    private void LoadChar() {
        Player = resSvc.LoadPrefab(Constants.CharacterPrefab);
        Player.name = "HotelPlayer";
        Player.transform.localPosition = new Vector3(0, 2.5f, 5);
        Player.transform.localScale = Vector3.one;
        ani = Player.GetComponent<Animator>();
        root.Player = Player;
        root.ani = ani;
    }

    private void RefreshUI() {
        pos201 = new Vector3(trans201.position.x, 4, 5);
        pos202 = new Vector3(trans202.position.x, 4, 5);
        pos203 = new Vector3(trans203.position.x, 4, 5);
        pos204 = new Vector3(trans204.position.x, 4, 5);

        Player = root.Player;
        ani = root.ani;
        Player.transform.position = new Vector3(-25, 4, 5);
        Player.transform.localScale = new Vector3(-1, 1, 1);
    }


    public void ClickRoom201Btn() {
        PlayUIAudio();
        if (IsRevert(pos201.x)) {
            Player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            Player.transform.localScale = Vector3.one;
        }

        ani.SetInteger("Action", 1);
        NavSys.Instance.NavToPos(Player.transform, pos201, () => {
            ani.SetInteger("Action", 0);
            root.AddTips("正在开发中...");
        });
    }

    public void ClickRoom202Btn() {
        PlayUIAudio();

        if (IsRevert(pos202.x)) {
            Player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            Player.transform.localScale = Vector3.one;
        }
        ani.SetInteger("Action", 1);
        NavSys.Instance.NavToPos(Player.transform, pos202, () => {
            ani.SetInteger("Action", 0);
            root.AddTips("正在开发中...");
        });
    }


    public void ClickRoom203Btn() {
        PlayUIAudio();

        if (IsRevert(pos203.x)) {
            Player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            Player.transform.localScale = Vector3.one;
        }
        ani.SetInteger("Action", 1);
        NavSys.Instance.NavToPos(Player.transform, pos203, () => {
            ani.SetInteger("Action", 0);
            root.AddTips("正在开发中...");
        });
    }

    public void ClickRoom204Btn() {
        PlayUIAudio();

        if (IsRevert(pos204.x)) {
            Player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            Player.transform.localScale = Vector3.one;
        }
        ani.SetInteger("Action", 1);
        NavSys.Instance.NavToPos(Player.transform, pos204, () => {
            ani.SetInteger("Action", 0);
            root.AddTips("正在开发中...");
        });
    }

    public void ClickQuitBtn() {
        PlayUIAudio();

        ani.SetInteger("Action", 0);
        NavSys.Instance.NavStop();
        PlayBGMusic(Constants.MainBG);
        root.SetLobbyTempPos();
        SetWndState(false);
    }

    private bool IsRevert(float targetX) {
        if (targetX > Player.transform.position.x) {
            return true;
        }
        else {
            return false;
        }
    }
}