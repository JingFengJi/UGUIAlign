using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UGUIAlignWindow : EditorWindow
{
    private Dictionary<AlignType,Texture> alignTexture = new Dictionary<AlignType, Texture>(); 
    void OnEnable()
    {
        Texture leftTexture = Resources.Load<Texture>("Textures/Left");
        Texture horizontalCenterTexture = Resources.Load<Texture>("Textures/HorizontalCenter");
        Texture rightTexture = Resources.Load<Texture>("Textures/Right");
        Texture topTexture = Resources.Load<Texture>("Textures/Top");
        Texture verticalCenterTexture = Resources.Load<Texture>("Textures/VerticalCenter");
        Texture bottomTexture = Resources.Load<Texture>("Textures/Bottom");
        Texture horizontalTexture = Resources.Load<Texture>("Textures/Horizontal");
        Texture verticalTexture = Resources.Load<Texture>("Textures/Vertical");
        alignTexture.Add(AlignType.Left, leftTexture);
        alignTexture.Add(AlignType.HorizontalCenter, horizontalCenterTexture);
        alignTexture.Add(AlignType.Right, rightTexture);
        alignTexture.Add(AlignType.Top, topTexture);
        alignTexture.Add(AlignType.VerticalCenter, verticalCenterTexture);
        alignTexture.Add(AlignType.Bottom, bottomTexture);
        alignTexture.Add(AlignType.Horizontal, horizontalTexture);
        alignTexture.Add(AlignType.Vertical, verticalTexture);
    }
    
    [MenuItem("UGUIAlign/Align")]
    public static UGUIAlignWindow GetWindow()
    {
        var window = GetWindow<UGUIAlignWindow>();
        window.titleContent = new GUIContent("UGUI Align");
        window.Focus();
        window.Repaint();
        return window;
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        for (int i = (int)AlignType.Top; i <= (int)AlignType.Vertical; i++)
        {
            if (GUILayout.Button(alignTexture[(AlignType)i], "LargeButton"))
            {
                UGUIAlign.Align((AlignType)i);
            }
            if (i%3 == 0)
            {
                GUILayout.EndVertical();
                GUILayout.BeginVertical();
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
