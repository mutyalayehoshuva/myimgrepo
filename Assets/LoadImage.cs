using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadImage : MonoBehaviour
{
    public RawImage img;
    //private string url = "https://www.imgacademy.com/themes/custom/imgacademy/images/helpbox-contact.jpg";
    private string url ="https://www.timeoutdubai.com/public/styles/full_img/public/images/2020/07/13/IMG-Dubai-UAE.jpg?itok=ibIYRxwX"
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadImageToUnity());
    }

    public IEnumerator LoadImageToUnity()
    {
        WWW we = new WWW(url);
        yield return we;
        Texture2D te = we.texture;
        img.texture = te;
    }
}
