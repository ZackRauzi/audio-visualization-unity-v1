using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LoadMP3FromResources : MonoBehaviour
{
    private AudioClip[] musicArr;
    private int clipCount = 1;

    void Start()
    {
        musicArr = Resources.LoadAll<AudioClip>("Audio");
        Debug.Log("Successfully Loaded " + musicArr.Length + " audio clips.");

        foreach (var clip in musicArr)
        {
            Debug.Log("Song " + clipCount + ": " + clip.name);
            clipCount++;
        }
    }
}
