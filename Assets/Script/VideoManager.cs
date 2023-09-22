using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer[] videoPlayers;
    public VideoClip[] videoClipsPlayer1; // Videos for player 1
    public VideoClip[] videoClipsPlayer2; // Videos for player 2
    public float minDelay = 5.0f;
    public float maxDelay = 10.0f;

    private void Start()
    {
        StartCoroutine(PlayRandomVideos());
    }

    private IEnumerator PlayRandomVideos()
    {
        while (true)
        {
            int randomIndexPlayer1 = Random.Range(0, videoClipsPlayer1.Length);
            int randomIndexPlayer2 = Random.Range(0, videoClipsPlayer2.Length);

            // Stop the video players and assign the new clips
            videoPlayers[0].Stop();
            videoPlayers[0].clip = videoClipsPlayer1[randomIndexPlayer1];

            videoPlayers[1].Stop();
            videoPlayers[1].clip = videoClipsPlayer2[randomIndexPlayer2];

            // Play the randomly selected videos for each player
            videoPlayers[0].Play();
            videoPlayers[1].Play();

            // Wait for the videos to finish playing
            float maxLength = Mathf.Max((float)videoClipsPlayer1[randomIndexPlayer1].length,
                                        (float)videoClipsPlayer2[randomIndexPlayer2].length);
            yield return new WaitForSeconds(maxLength);

            // Wait for a random delay before playing the next set of videos
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }
}
