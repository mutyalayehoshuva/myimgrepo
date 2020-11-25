using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.RemoteConfig;

public class cube : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public bool isBlue = false;
    public Material blueMaterial;
    public Material redMaterial;
    public Renderer rend;

    public Image img;

    public bool iscolorchanged = false;
    public GameObject Myimage;

    void Awake()
    {
       // ConfigManager.FetchCompleted += SetColor;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }
    void SetColor(ConfigResponse response)
    {
        isBlue = ConfigManager.appConfig.GetBool("cubeisBlue");
        if (isBlue)
        {
            rend.material = blueMaterial;
        }
        else
        {
            
            rend.material = redMaterial;
        }
    }

  public  void NewColor()
    {
       
        Myimage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        
    }

    // Update is called once per frame
    void Update()
    {
     //  Debug.Log("Hello");
      if(Input.GetMouseButtonDown(1))
        {
            ConfigManager.FetchCompleted += SetColor;
            print("Presssed");
            ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());

        }
      if(Input.GetMouseButtonDown(3))
        {
           
            ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
        }
      /* if(Input.GetKeyDown(KeyCode.Space))
         {
            print("you pressed A");
        }*/
    }

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= SetColor;
       
    }
    /// <summary>
    /// ////////////////////////////Cereated class for JSON;
    /// </summary>
/*    [SerializeField]
    public class Myclass
    {
        public int f;

    }*/
}
