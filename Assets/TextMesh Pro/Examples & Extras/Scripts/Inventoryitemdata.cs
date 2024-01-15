using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;

    void TakeScreenshort(string fullpath)
    {
        if(Camera == null)
        {
            Camera = GetComponets<Camera>();
        }

        RenderTexture rt = new RenderTexture(256, 256, 24);
        Camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(256, 256, TextureFormate.RGBA32, false);
        Camera.targetTexture = null;
        RenderTexture.active = null;

        if(Application.isEditor) 
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullpath, bytes);  
        AssetDatabase.Refresh();
    }
}
