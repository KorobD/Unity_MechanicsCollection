using UnityEngine;

public static class UIManager {
    
    public static void ShowMenu(GameObject menu) {

        menu.SetActive(true);

    }

    public static void HideMenu(GameObject menu) { 
        
        menu.SetActive(false); 
    
    }

    public static void ShowCursor() {

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    public static void HideCursor() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public static Vector3 GetMouseWorldPosition() {

        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;

    }

}
