using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class DisplayImage : MonoBehaviour {

    public string TextureURL = "https://images.metmuseum.org/CRDImages/ep/original/DP-14936-023.jpg";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadImage(TextureURL));
        Debug.Log("Script is running!");
    }
 
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