using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;
using Int32Msg = RosMessageTypes.Std.Int32Msg;
using Float32Msg = RosMessageTypes.Std.Float32Msg;
using TwistMsg = RosMessageTypes.Geometry.TwistMsg;
using PoseMsg = RosMessageTypes.Geometry.PoseMsg;

public class MyPublisher : MonoBehaviour
{
    ROSConnection ros;

    public GameObject targetObject;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //ここで初期位置の座標を(0,0)としてもいいかもしれない
        // ROSコネクションの取得
        ros = ROSConnection.GetOrCreateInstance();

        rb = targetObject.GetComponent<Rigidbody>();

        // パブリッシャの登録
        ros.RegisterPublisher<TwistMsg>("cmd_vel");
        ros.RegisterPublisher<PoseMsg>("pose");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Unity→ROSの座標系変換 https://kato-robotics.hatenablog.com/entry/2018/10/24/195041
        float xPos = targetObject.transform.position.x;// m
        float yPos = targetObject.transform.position.z;// m
        float zPos = 0;
        float zRotation = targetObject.transform.rotation.eulerAngles.y;// /度数法

        float xVelocity = rb.velocity.x;// m/s
        float yVelocity = rb.velocity.z;// m/s
        float zVelocity = 0;
        float zAngularVelocity = rb.angularVelocity.y;

        //poseのパブリッシュ
        PoseMsg poseMsg = new PoseMsg();

        poseMsg.position.x = xPos; 
        poseMsg.position.y = yPos;
        poseMsg.position.z = zPos;

        poseMsg.orientation.x = 0.0f;
        poseMsg.orientation.y = 0.0f;  
        poseMsg.orientation.z = zRotation;
        poseMsg.orientation.w = 0.0f;
        
        ros.Publish("pose", poseMsg); 

        //cmd_velのパブリッシュ
        TwistMsg twistMsg = new TwistMsg();

        twistMsg.linear.x = xVelocity;  // Set linear velocity along x-axis
        twistMsg.linear.y = yVelocity;
        twistMsg.linear.z = zVelocity;

        twistMsg.angular.x = 0.0f;
        twistMsg.angular.y = 0.0f;  // Set angular velocity around y-axis
        twistMsg.angular.z = zAngularVelocity;
        
        ros.Publish("cmd_vel", twistMsg); 
}
}
