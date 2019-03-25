/****************************************************
	文件：AudioSvc.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/25 13:40   	
	功能：声音服务
*****************************************************/

using UnityEngine;

public class AudioSvc : MonoBehaviour {
    public static AudioSvc Instance;

    #region ///=== Data  Area       ===///
    public AudioSource bgAudio;
    //public AudioSource effectAudio;
    public AudioSource uiAudio;
    //public AudioSource operateAudio;

    private bool bgOn = true;
    private bool uiOn = true;
    #endregion

    #region ///=== Main Functions ===///
    public void InitSvc() {
        Instance = this;
    }
    #endregion

    #region ///=== Tool  Functions ===///
    public void StopBGMusic() {
        if (bgAudio != null) {
            bgAudio.Stop();
        }
    }

    public void PlayBGMusic(string name, bool isLoop = true) {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        if (bgAudio.clip == null || bgAudio.clip.name != audio.name) {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            if (bgOn) {
                bgAudio.Play();
            }
        }
    }

    public void PlayUIAudio(string name) {
        if (uiOn) {
            AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
            uiAudio.clip = audio;
            uiAudio.Play();
        }
    }
    #endregion
}
