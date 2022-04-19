using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MainGame : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;


    public static double AngleBetween(Vector2 vector1, Vector2 vector2)
    {
        double sin = vector1.x * vector2.y - vector2.x * vector1.y;
        double cos = vector1.x * vector2.x + vector1.y * vector2.y;

        return Math.Atan2(sin, cos) * (180 / Math.PI);
    }


    public void Update()
    {
        if (GameController_Main.instance.isActiveJoystick)
        {
            if (variableJoystick.Vertical != 0 || variableJoystick.Horizontal != 0)
            {
                //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                Vector3 direction = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
                //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
                rb.velocity = direction * speed;
                Vector2 dirRotate = new Vector2(direction.z, direction.x);
                transform.DORotate(new Vector3(0, (float)AngleBetween(new Vector2(1, 0), dirRotate), 0), 0.1f);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }       
    }
}
