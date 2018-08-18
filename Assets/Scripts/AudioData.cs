using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioData : MonoBehaviour {

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    public int sizeSample = 1024;
    [SerializeField]
    float refVal = 0.1f;
    [SerializeField]
    float threshold = 0.02f;


    public float rms;
    public float dbVal;
    public float freqVal;

    float[] samples;
    public float[] spectrum;
    private float fSample;

    void Start()
    {
        samples = new float[sizeSample];
        spectrum = new float[sizeSample];
        fSample = AudioSettings.outputSampleRate;
    }

    void Update()
    {
        GetSoundValues();
    }

    void GetSoundValues()
    {

        audioSource.GetComponent<AudioSource>().GetOutputData(samples, 0);
        audioSource.GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float sum = 0;
        for (int i = 0; i < sizeSample; i++)
        {
            sum += samples[i] * samples[i]; 
        }

        rms = Mathf.Sqrt(sum / sizeSample);

        dbVal = 20 * Mathf.Log10(rms / refVal);

        if (dbVal < -160) dbVal = -160; 

        float valMax = 0;
        int indexMax = 0;

        for (int j = 0; j < sizeSample; j++)
        { 
            if (!(spectrum[j] > valMax) || !(spectrum[j] > threshold))
                continue;

            valMax = spectrum[j];
            indexMax = j;
        }

        float freqN = indexMax;

        if (indexMax > 0 && indexMax < sizeSample - 1)
        { 
            var dL = spectrum[indexMax - 1] / spectrum[indexMax];
            var dR = spectrum[indexMax + 1] / spectrum[indexMax];
            freqN += 0.5f * (dR * dR - dL * dL);
        }

        freqVal = freqN * (fSample / 2) / sizeSample;
        if (freqVal > 2000) freqVal = 2000;

    }
}


