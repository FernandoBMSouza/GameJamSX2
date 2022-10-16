using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    public Camera MainCamera;
    [SerializeField] private Vector2 screenBounds;
    void Start()
    {
        MainCamera = Camera.main;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, screenBounds.x * -1, screenBounds.x),
                                         Mathf.Clamp(transform.position.y, screenBounds.y * -1, screenBounds.y),
                                         transform.position.z);
    }
}
