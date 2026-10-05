using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 5;
    GameObject Ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 xMovement = Vector3.zero;

        if (Keyboard.current != null){
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.dKey.isPressed){
                xMovement.x += 1;
            }

            if(Keyboard.current.rightArrowKey.isPressed || Keyboard.current.aKey.isPressed){
                xMovement.x -= 1;
                
            }
            xMovement = xMovement.normalized * Time.deltaTime * speed;
            transform.position += new Vector3(xMovement.x, 0, 0);
        }
        
    }
}
