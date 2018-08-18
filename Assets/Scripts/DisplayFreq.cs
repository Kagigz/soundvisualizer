using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFreq : MonoBehaviour {

    int nSpectrum;

    public float widthLine { get; set; }
    public float spaceBetweenLines { get; set; }
    public float heightFix { get; set; }

    [SerializeField]
    Material lineMaterial;
    [SerializeField]
    GameObject prefabLine;

    GameObject[] linesRight;
    GameObject[] linesLeft;

    Vector3 positionLineRight;
    Vector3 positionLineLeft;

    Vector3 scaleLine;



    void Start()
    {
        widthLine = 0.2f;
        spaceBetweenLines = 0f;
        heightFix = 40f;
        nSpectrum = GetComponent<AudioData>().sizeSample;
        lineMaterial.color = GetComponent<ChangeColor>().newColor;
        linesRight = new GameObject[nSpectrum];
        linesLeft = new GameObject[nSpectrum];
        for (int i = 0; i < nSpectrum; i++)
        {
            positionLineRight = new Vector3((widthLine + spaceBetweenLines) * i, 0, 0);
            positionLineLeft = new Vector3(-(widthLine + spaceBetweenLines) * i, 0, 0);
            GameObject lR = (GameObject)Instantiate(prefabLine, positionLineRight, Quaternion.identity);
            GameObject lL = (GameObject)Instantiate(prefabLine, positionLineLeft, Quaternion.identity);
            if (i == 0)
            {

                lL.GetComponent<Transform>().position = new Vector3(-1000, 0, 0);
            }
            linesRight[i] = lR;
            linesLeft[i] = lL;
        }

    }

    void Update()
    {
        lineMaterial.color = GetComponent<ChangeColor>().newColor;
        if (GetComponent<SoundControls>().isPlaying)
        {
            for (int i = 0; i < nSpectrum; i++)
            {
                scaleLine = new Vector3(widthLine, GetComponent<AudioData>().spectrum[i] * heightFix * GetComponent<AudioData>().dbVal, 0.1f);
                linesRight[i].GetComponent<Transform>().position = new Vector3((widthLine + spaceBetweenLines) * i, 0, 0);
                linesRight[i].GetComponent<Transform>().localScale = scaleLine;
                if (i != 0)
                {
                    linesLeft[i].GetComponent<Transform>().position = new Vector3(-(widthLine + spaceBetweenLines) * i, 0, 0);
                    linesLeft[i].GetComponent<Transform>().localScale = scaleLine;
                }
            }
        }
    }

}
