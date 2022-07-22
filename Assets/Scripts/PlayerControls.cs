using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [SerializeField] float xRange = 13;
    [SerializeField] float yUpRange = 13;
    [SerializeField] float yDownRange = -2;

    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float pitchTuner = -5.5f;

    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    float posX = 0, posY = 0 , posZ = 0;
    
    /*[SerializeField] InputAction movement;
     private void OnEnable()
     {
         movement.Enable();
     }

     private void OnDisable()
     {
         movement.Disable();
     }*/

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = (transform.localPosition.y + pitchTuner) * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        //posX = transform.localPosition.x;
        posX += xThrow * Time.deltaTime * speed;
        posX = Mathf.Clamp(posX, -xRange, xRange);

        //posY = transform.localPosition.y;
        posY += yThrow * Time.deltaTime * speed;
        posY = Mathf.Clamp(posY, yDownRange, yUpRange);
        transform.localPosition = new Vector3(posX, posY, posZ);

        /********** Input Manager (New) ***********
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;
        ******************************************/

        /* Mathf.Clamp와 같은 동작
        if (posX > 13) posX = 13;
        if (posX < -13) posX = -13;
        if (posY > 13) posY = 13;
        if (posY < -2) posY = -2;
        */
    }
}
