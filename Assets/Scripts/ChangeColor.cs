using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {

    public GameObject colorWheel;
    public GameObject selector;
    GameObject canvas;

    Sprite colorPicker;
    Color[] colorPixels;

    public Color newColor;

    int widthWheel;
    int heightWheel;
    public float scaleUI;

    Vector3 posColorWheel;

    void Awake () {

        canvas = GameObject.Find("Canvas");

        scaleUI = Screen.width / canvas.GetComponent<CanvasScaler>().referenceResolution.x;
        colorPicker = colorWheel.GetComponent<Image>().sprite;
        widthWheel = colorPicker.texture.width;
        heightWheel = colorPicker.texture.height;
        colorPixels = colorPicker.texture.GetPixels();

        newColor = new Color(0, 234, 232, 1);
        posColorWheel = colorWheel.GetComponent<RectTransform>().transform.position;
    }


    void Update () {

        scaleUI = Screen.width / canvas.GetComponent<CanvasScaler>().referenceResolution.x;
        if (Input.GetMouseButton(0))
            ChangeClickColorWheel();

    }

    void ChangeClickColorWheel()
    {
       
        Vector3 screenPos = Input.mousePosition;
        screenPos = new Vector2(screenPos.x, screenPos.y);

        RaycastHit2D[] ray = Physics2D.RaycastAll(screenPos, Vector2.zero, 0.01f);

        for (int i = 0; i < ray.Length; i++)
        {

            if (ray[i].collider.tag == "colorWheel")
            {
                selector.transform.position = screenPos;
                screenPos -= colorWheel.GetComponent<Transform>().transform.position;
                int x = (int)(2*screenPos.x/scaleUI);
                int y = (int)(2*screenPos.y/scaleUI);

                if (x > 0 && x < widthWheel && y > 0 && y < heightWheel)
                {
                    newColor = colorPixels[y * widthWheel + x];
                }
                break;
            }
        }
    }
}
