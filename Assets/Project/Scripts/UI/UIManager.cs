using System;
using UnityEngine;
using UnityEngine.UI;

public static class UIManager {
    
    //Menu
    public static void ShowMenu(GameObject menu) {

        menu.SetActive(true);

    }

    public static void HideMenu(GameObject menu) { 
        
        menu.SetActive(false); 
    
    }

    //Cursor
    public static void ShowCursor() {

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    public static void HideCursor() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public static Vector3 GetCursorWorldPosition() {

        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;

    }

    //Button
    public static void ButtonLoadScene(Button button, ScenesList scene) {
    
        button.onClick.AddListener(() => { Loader.Load(scene); });
    
    }

}