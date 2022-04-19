using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_Main : MonoBehaviour
{
    public static GameController_Main instance;
    public Camera mainCamera;
    public RectTransform background, handle;
    public RectTransform canvasRect;
    public Canvas canvas;
    public VariableJoystick variableJoystick;
    public bool isActiveJoystick;
    public Player_MainGame player;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(instance);
        isActiveJoystick = false;
        background.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            variableJoystick.Horizontal = 0;
            variableJoystick.Vertical = 0;
            Vector2 point;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera, out point);
            background.anchoredPosition = point;
            handle.anchoredPosition = Vector2.zero;
            Debug.Log($"{variableJoystick.Vertical},{variableJoystick.Horizontal}");
            isActiveJoystick = true;
            background.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            background.gameObject.SetActive(false);
            isActiveJoystick = false;
            player.rb.velocity = Vector3.zero;
        }
    }
}
