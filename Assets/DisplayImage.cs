using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class DisplayImage : MonoBehaviour {
    // void Start() {
    //     StartCoroutine(GetTexture());
    //     Debug.Log("This is running!");
    // }
 
    // IEnumerator GetTexture() {
    //     UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://images.metmuseum.org/CRDImages/as/original/DP251139.jpg");
    //     yield return www.SendWebRequest();

    //     if (www.result != UnityWebRequest.Result.Success) {
    //         Debug.Log(www.error);
    //     }
    //     else {
    //         Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
    //     }
    // }

    // void Start(){    
    //     StartCoroutine(DownloadImage("https://images.metmuseum.org/CRDImages/as/original/DP251139.jpg"));
    // }

    // IEnumerator DownloadImage(string MediaUrl)
    // {   
    //     UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
    //     yield return request.SendWebRequest();
    //     if(request.isNetworkError || request.isHttpError) 
    //         Debug.Log(request.error);
    //     else
    //         YourRawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
    // } 

    public string TextureURL = "https://images.metmuseum.org/CRDImages/ep/original/DP-14936-023.jpg";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadImage(TextureURL));
        Debug.Log("Script is running!");
    }

         
    // }
 
    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            Debug.Log(MediaUrl);
            this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}