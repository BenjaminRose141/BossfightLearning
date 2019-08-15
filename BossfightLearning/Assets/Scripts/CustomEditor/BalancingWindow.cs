using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BalancingWindow : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D playerSectionTexture;
    Texture2D bossSectionTexture;

    Color headerSectionColor = new Color(92f/255f,133f/255f,93f/255f, 1f);

    Rect headerSection;
    Rect playerSection;
    Rect bossSection;

    [MenuItem("Window/ Balancing")]
    static void OpenWindow()
    {
        BalancingWindow window = (BalancingWindow)GetWindow(typeof(BalancingWindow));
        window.minSize = new Vector2(600,300);
        window.Show();
    }

    void OnEnable()
    {
        InitTextures();
    }

    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1,1);
        headerSectionTexture.SetPixel(0,0,headerSectionColor);
        headerSectionTexture.Apply();

        playerSectionTexture = Resources.Load<Texture2D>("icons/PlayerColor");
        bossSectionTexture = Resources.Load<Texture2D>("icons/BossColor");
    }

    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;

        playerSection.x = 0;
        playerSection.y = 50;
        playerSection.width = Screen.width/2f;
        playerSection.height = Screen.height-50;

        bossSection.x = Screen.width/2f;
        bossSection.y = 50;
        bossSection.width = Screen.width/2f;
        bossSection.height = Screen.height-50;
        
        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(playerSection, playerSectionTexture);
        GUI.DrawTexture(bossSection, bossSectionTexture);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.EnndArea();
    }
}
