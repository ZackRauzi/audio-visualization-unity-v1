using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using System;
using System.Runtime.CompilerServices;


public class AudioCubesController : MonoBehaviour
{
    //Audio Visualizer Modifiers
    [SerializeField, Range(0,2), Tooltip("Size of each individual cube")]
    public float cubeSize = 1f;

    [SerializeField, Range(0,2000)]
    public float cubeMaxAmplitude = 500f;

    [SerializeField, Range(1,6), Tooltip("Range: 1-6 (64/128/256/512/1028/2048/)")]
    public int spectrumFactor = 1;

    //Audio Visualizer Components
    [SerializeField] public GameObject cubeSource;
    Transform[] targetArray = null;
    private Transform[] currentCubes = null;
    public static int arrayLength;

    Transform[] cubeSpectrumData64 = new Transform[64];
    Transform[] cubeSpectrumData128 = new Transform[128];
    Transform[] cubeSpectrumData256 = new Transform[256];
    Transform[] cubeSpectrumData512 = new Transform[512];
    Transform[] cubeSpectrumData1024 = new Transform[1024];
    Transform[] cubeSpectrumData2048 = new Transform[2048];

    void Update()
    {
        //vizualize music by transforming cubes
        switch(spectrumFactor)
        {
            case 1:
                if (arrayLength != 64){arrayLength = 64;InstantiateCubes(64);}
                for (int i=0; i < 64; i++){cubeSpectrumData64[i].transform.localScale = new Vector3 (cubeSize, AudioSpectrumData.spectrumData64[i] * cubeMaxAmplitude, cubeSize);}
                break;
            case 2:
                if (arrayLength != 128){arrayLength = 128;InstantiateCubes(128);}
                for (int i=0; i < 128; i++){cubeSpectrumData128[i].transform.localScale = new Vector3 (cubeSize, AudioSpectrumData.spectrumData128[i] * cubeMaxAmplitude, cubeSize);}
                break;
            case 3:
                if (arrayLength != 256){arrayLength = 256;InstantiateCubes(256);}
                for (int i=0; i < 256; i++){cubeSpectrumData256[i].transform.localScale = new Vector3 (cubeSize, AudioSpectrumData.spectrumData256[i] * cubeMaxAmplitude, cubeSize);}
                break;
            case 4:
                if (arrayLength != 512){arrayLength = 512;InstantiateCubes(512);}
                for (int i=0; i < 512; i++){cubeSpectrumData512[i].transform.localScale = new Vector3 (cubeSize, AudioSpectrumData.spectrumData512[i] * cubeMaxAmplitude, cubeSize);}
                break;
            case 5:
                if (arrayLength != 1024){arrayLength = 1024;InstantiateCubes(1024);}
                for (int i=0; i < 1024; i++){cubeSpectrumData1024[i].transform.localScale = new Vector3 (cubeSize, AudioSpectrumData.spectrumData1024[i] * cubeMaxAmplitude, cubeSize);}
                break;
            case 6:
                if (arrayLength != 2048){arrayLength = 2048;InstantiateCubes(2048);}
                for (int i=0; i < 2048; i++){cubeSpectrumData2048[i].transform.localScale = new Vector3 (cubeSize, AudioSpectrumData.spectrumData2048[i] * cubeMaxAmplitude, cubeSize);}
                break;
        }
    }

    // helper functions
    void InstantiateCubes(int size){
        //delete previous cubes
        if (currentCubes != null){foreach (Transform t in currentCubes){if (t != null){Destroy(t.gameObject);}}}
        //update array to correct size
        switch (size)
        {
            case 64: targetArray = cubeSpectrumData64; break;
            case 128: targetArray = cubeSpectrumData128; break;
            case 256: targetArray = cubeSpectrumData256; break;
            case 512: targetArray = cubeSpectrumData512; break;
            case 1024: targetArray = cubeSpectrumData1024; break;
            case 2048: targetArray = cubeSpectrumData2048; break;
        }
        //instantiate new cubes
        for (int i = 0; i < size; i++)
        {
            GameObject instance = Instantiate(cubeSource);
            instance.transform.position = this.transform.position;
            instance.transform.parent = this.transform;
            instance.name = "SampleCube" + i;

            float angle = 360f / size;
            this.transform.eulerAngles = new Vector3(0, -angle * i, 0);
            instance.transform.position = Vector3.forward * 100;

            targetArray[i] = instance.transform;
        }
        //update reference
        currentCubes = targetArray;
    }
}
