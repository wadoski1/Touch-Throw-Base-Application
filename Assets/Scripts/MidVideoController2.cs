using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using UnityEngine.Video;

public class MidVideoController2 : MonoBehaviour
{
    [SerializeField] MediaPlayer m_videoPlayer;
    [SerializeField] MediaPlayer m_screenSaverPlayer;    
    [SerializeField] GameObject m_videoPanel;

    [SerializeField] string path;

    private float originalVideoVolume;

    private void Start()
    {
        path = $"{Application.streamingAssetsPath}/Videos/";

        m_videoPlayer.Events.AddListener(OnVideoEvent);
    }

    public void SelectVideo(int p_video)
    {
        m_videoPanel.SetActive(true);

        m_videoPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path + $"{p_video}.mp4");

        m_videoPlayer.Control.Seek(0);
        originalVideoVolume = m_videoPlayer.Control.GetVolume();

        m_screenSaverPlayer.Control.SetVolume(0.0f);

    }

    private void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
    {
        switch (et)
        {
            case MediaPlayerEvent.EventType.ReadyToPlay:
                mp.Control.Play();
                break;
            case MediaPlayerEvent.EventType.FirstFrameReady:
                break;
            case MediaPlayerEvent.EventType.FinishedPlaying:
                mp.Control.Stop();
                m_videoPanel.SetActive(false);
                m_screenSaverPlayer.Control.SetVolume(1.0f);

                break;
        }
    }
}


