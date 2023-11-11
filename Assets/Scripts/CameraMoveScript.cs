using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class CameraMoveScript : MonoBehaviour
{
    [SerializeField] InputActionReference rightClick;
    [SerializeField] InputActionReference look;
    [SerializeField] InputActionReference movementInput;
    [SerializeField] GameObject Body;
    public float speed = 6;
    public float sensitivity = 5.0f;
    bool shift;
    Vector2 move;
    Vector2 mouselook;
    float xrotation;
    float yrotation;

    private void Update(){       
        move = movementInput.action.ReadValue<Vector2>();
        Vector3 movement = (move.y * transform.forward) *speed + (move.x * transform.right)*speed;
        GetComponentInParent<CharacterController>().Move(movement * speed * Time.deltaTime);        

        //If the player is holding right click allow for mouse rotaion input
        if (rightClick.action.ReadValue<float>() != 0) {
            Cursor.lockState = CursorLockMode.Locked;
            mouselook = look.action.ReadValue<Vector2>();
            //calculates x/y mouse movement and sensitivity
            float mouseX = mouselook.x * Time.deltaTime * sensitivity;
            float mouseY = mouselook.y * Time.deltaTime * sensitivity;
            //Rotation based off mouse input
            xrotation -= mouseY;
            yrotation += mouseX;
            xrotation = Mathf.Clamp(xrotation, -90, 90); // Clamp the X-axis rotation to avoid over-rotation
            //rotate the camera according to mouse input
            transform.eulerAngles = new Vector3(xrotation, yrotation, 0);
        }
        else{
            Cursor.lockState = CursorLockMode.None;
        }
                     
    }

}

