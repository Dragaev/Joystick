using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speedMove=30;
    public float jumpForce = 20;
    private Vector3 moveVector;

    private Joystick joystick;
    protected JoyButton joyButton;
    protected bool jump;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.FindGameObjectWithTag("JoystickTag").GetComponent<Joystick>();
        joyButton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveVector.x = joystick.Horizontal() * speedMove;
        moveVector.y = joystick.Vertical() * speedMove;
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(moveVector.x + Input.GetAxis("Horizontal") * 100f, rigidbody.velocity.y, moveVector.y + Input.GetAxis("Vertical") * 100f);

        if (!jump && joyButton.Pressed)
        {
            jump = true;
            rigidbody.velocity += Vector3.up * jumpForce;
        }
        if (jump && !joyButton.Pressed)
        {
            jump = false;
        }
    }
    
}
