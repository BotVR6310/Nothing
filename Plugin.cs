using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using Utilla;
using GorillaExtensions;

namespace Nothing
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        //public GameObject dingus;
        public GameObject table;
        public GameObject cube;
        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }   

        private void OnGameInitialized(object sender, EventArgs e)
        {
            AssetBundle assetBundle = LoadAssetBundle("Nothing.Resources.nothing");
            table = UnityEngine.Object.Instantiate(assetBundle.LoadAsset<GameObject>("table"));
            cube = UnityEngine.Object.Instantiate(assetBundle.LoadAsset<GameObject>("cube"));
            //dingus = UnityEngine.Object.Instantiate(assetBundle.LoadAsset<GameObject>("dingus"));
            this.table.transform.position = new Vector3(-65.6194f, 11.5296f, -84.3884f);
            this.table.transform.eulerAngles += new Vector3(0f, 82.4559f, 0f);
            this.cube.transform.position = new Vector3(-65.6194f, 11.6496f, - 84.3884f);
            this.cube.transform.eulerAngles += new Vector3(0f, 82.4559f, 0f);
            //this.dingus.transform.position = new Vector3(-63.934f, 13.25f, -82.926f);
            cube.layer = 18;
            cube.AddComponent<oddbutton>();
            cube.AddComponent<AudioSource>();
            //cube.GetComponent<AudioSource>().Play();
        }
        public void Pressed()
        {
            GetComponent<AudioSource>().Play();
            //cube.GetComponent<AudioSource>().Play();
            UnityEngine.Debug.Log("Button Pressed");
        }
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
