using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class Detection : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect myFace;
    public float faceY, faceX;

   
    
   

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        _webCamTexture = new WebCamTexture(devices[0].name);
        _webCamTexture.Play();
        cascade = new CascadeClassifier("/Users/PC/Documents/GitHub/Aleph_LMM4/Aleph/Assets/haarcascade_frontalface_default.xml");
    }

    // Update is called once per frame
    void Update()
    {
       // GetComponent<Renderer>().material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

        findNewFace(frame);
        display(frame);
      
    }

    public void findNewFace(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);

        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            myFace = faces[0];
            faceY = faces[0].Y;
            faceX = faces[0].X;
        }
    }

    void display(Mat frame)
    {
        if (myFace != null)
        {
            frame.Rectangle(myFace, new Scalar(250, 0, 0), 2);
        }
        Texture newtexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newtexture;
    }

    
}
