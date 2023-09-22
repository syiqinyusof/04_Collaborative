using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class VideoController : MonoBehaviour
{
    public Button button1;
    public Button button2;

    public VideoClip[] button1Videos;
    public VideoClip[] button2Videos;

    public VideoPlayer videoPlayer;
    public TMP_Text instructionText;

    void Start()
    {
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnButton1Click()
    {
        int randomIndex = Random.Range(0, button1Videos.Length);
        PlayVideo(button1Videos[randomIndex]);
    }

    void OnButton2Click()
    {
        int randomIndex = Random.Range(0, button2Videos.Length);
        PlayVideo(button2Videos[randomIndex]);
    }

    void PlayVideo(VideoClip videoClip)
    {
        instructionText.gameObject.SetActive(false); // Hide instruction when starting a video
        videoPlayer.Stop();
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // instructionText.gameObject.SetActive(true); // Show instruction when the video ends
        // You can add logic here to change the instruction text if needed
    }
}
