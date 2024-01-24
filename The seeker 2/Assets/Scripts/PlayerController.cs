using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Jobs;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 6f;
    public Transform rt;
    public float smoothtime =  0.1f;
    float current;

    public Transform checkTransform;
    public float radius = .2f;
    public LayerMask groundMask;
    bool isGrounded;
    float Gravity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(checkTransform.position,radius,groundMask);
        
        if (isGrounded == false)
        {
            Gravity += -9.8f;
            characterController.Move(new Vector3 (0,Gravity*Time.deltaTime*Time.deltaTime,0));
        }else
        {
            Gravity = 0;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float bouflfel = Mathf.Atan2(direction.x ,direction.z)*Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, bouflfel, ref current, smoothtime);
            rt.rotation = Quaternion.Euler(0, angle, 0);
            characterController.Move(direction*speed*Time.deltaTime);
        }
    }
}
