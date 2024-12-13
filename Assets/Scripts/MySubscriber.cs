using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using MyTwistMsg = RosMessageTypes.Geometry.TwistMsg; 

public class MySubscriber : MonoBehaviour
{
    public Rigidbody rb;

    private float vx = 0.0f; // Linear velocity in x-direction
    private float vz = 0.0f; // Linear velocity in z-direction

    private float ry = 0.0f; // Yaw angle (in radians)
    private float ry_velo = 0.0f; // Yaw angular velocity (in radians/sec)

    // Start is called before the first frame update
    void Start()
    {
        ROSConnection.instance.Subscribe<MyTwistMsg>("/pid_cmd_vel", TwistCallback);
        rb = GetComponent<Rigidbody>();
    }

    void TwistCallback(MyTwistMsg msg)
    {
        vx = (float)msg.linear.x; // Linear velocity in x-direction
        vz = (float)msg.linear.y; // Linear velocity in z-direction
        ry = (float)msg.linear.z ; // Yaw angle in radians
        ry_velo = (float)msg.angular.z ; // Yaw angular velocity in radians/sec
    }

    void FixedUpdate()
    {
        // X, Z方向の速度を設定
        Vector3 movement = new Vector3(vx, 0f, vz);
        rb.velocity = movement;

        // Y軸の角速度を設定
        Vector3 angularVelocity = new Vector3(0f, ry_velo, 0f);
        rb.angularVelocity = angularVelocity;
        Debug.Log("vx: " + vx + " vz: " + vz + " ry: " + ry + " ry_velo: " + ry_velo);
    }
    

}
