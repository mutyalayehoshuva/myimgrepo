using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.RemoteConfig;

public class enableTree : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public bool istreethere = true;
    /*    public Material blueMaterial;
        public Material redMaterial;
        public Renderer rend;*/
    public GameObject treeimg;
   // public Image img;


    void Awake()
    {
         ConfigManager.FetchCompleted += SetTree;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }
    void SetTree(ConfigResponse response)
    {
        istreethere = ConfigManager.appConfig.GetBool("isTreethere");
        if (istreethere)
        {
            //rend.material = blueMaterial;
            treeimg.SetActive(true);
        }
        else
        {
            treeimg.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log("Hello");
       // if (Input.GetMouseButtonDown(1))
       // {
           // ConfigManager.FetchCompleted += SetTree;
          //  print("Presssed");
         //   ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());

        }
        

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= SetTree;

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