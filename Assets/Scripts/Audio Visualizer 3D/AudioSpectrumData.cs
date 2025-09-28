using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioSpectrumData : MonoBehaviour
{
    AudioSource audioSource;
    public int getSpectrumFactor;
    public static float[] spectrumData64 = new float[64];
    public static float[] spectrumData128 = new float[128];
    public static float[] spectrumData256 = new float[256];
    public static float[] spectrumData512 = new float[512];
    public static float[] spectrumData1024 = new float[1024];
    public static float[] spectrumData2048 = new float[2048];
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        switch (AudioCubesController.arrayLength)
        {
            case 64: getSpectrumFactor = 1; break;
            case 128: getSpectrumFactor = 2; break;
            case 256: getSpectrumFactor = 3; break;
            case 512: getSpectrumFactor = 4; break;
            case 1024: getSpectrumFactor = 5; break;
            case 2048: getSpectrumFactor = 6; break;
        }
        GetSpecrumAudioSource(getSpectrumFactor);
    }

    void GetSpecrumAudioSource(int index)
    {
        switch(index)
        {
            case 1: audioSource.GetSpectrumData(spectrumData64,0,FFTWindow.BlackmanHarris); break;
            case 2: audioSource.GetSpectrumData(spectrumData128,0,FFTWindow.BlackmanHarris); break;
            case 3: audioSource.GetSpectrumData(spectrumData256,0,FFTWindow.BlackmanHarris); break;
            case 4: audioSource.GetSpectrumData(spectrumData512,0,FFTWindow.BlackmanHarris); break;
            case 5: audioSource.GetSpectrumData(spectrumData1024,0,FFTWindow.BlackmanHarris); break;
            case 6: audioSource.GetSpectrumData(spectrumData2048,0,FFTWindow.BlackmanHarris); break;
        }
    }
}
