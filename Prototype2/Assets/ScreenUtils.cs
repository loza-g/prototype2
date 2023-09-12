using UnityEngine;

public static class ScreenUtils
{
    public static Vector2 ScreenMin
    {
        get
        {
            Vector2 min = Camera.main.ScreenToWorldPoint(Vector3.zero);
            min.x += 0.5f; // Adjust this value to fit your object's size
            min.y += 0.5f; // Adjust this value to fit your object's size
            return min;
        }
    }

    public static Vector2 ScreenMax
    {
        get
        {
            Vector2 max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            max.x -= 0.5f; // Adjust this value to fit your object's size
            max.y -= 1.5f; // Adjust this value to fit your object's size
            return max;
        }
    }
}