/****************************************************
	文件：DesWnd.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/25 16:17   	
	功能：描述过渡界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class DesWnd : WindowRoot {
    public float speedShow = 120;
    public Text txtDes;
    public Transform btnTrans;

    private string des = "2018年4月21日\n\n我是XXX，是羊村的一个普通居民。唯一的不普通的一点就是，你是羊村村花杨超越的朋友/哥哥。\n\n上个月，时刻与羊村老小保持通讯的村花失联了，你被派往超越最后出现的小镇——魔都小镇，寻找她。";
    protected override void InitWnd() {
        base.InitWnd();
        RefreshUI();
    }

    private void RefreshUI() {
        int len = 0;
        int counter = 0;
        while (len < des.Length) {
            len += 1;
            timerSvc.AddTask((int tid) => {
                counter += 1;
                string str = GetDesSplitStr(0, counter);
                SetText(txtDes, str);
            }, speedShow * len);
        }

        SetActive(btnTrans, false);
        timerSvc.AddTask((int tid) => {
            SetActive(btnTrans);
        }, speedShow * len + 1000);
    }

    private string GetDesSplitStr(int startIndex, int count) {
        if (count > des.Length) {
            count = des.Length;
        }
        string str = des.Substring(startIndex, count);
        return str;
    }

    public void ClickStartBtn() {
        root.OpenLobbyWnd();
        SetWndState(false);
    }
}