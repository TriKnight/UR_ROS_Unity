using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;

/// <summary>
///
/// </summary>
public class TCP_publisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "TCP_pos";

    // The game object
    public GameObject TCP;
    // Publish the TCP's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PosRotMsg>(topicName);
    }
    public static Quaternion ConvertUnitytoROS(Vector3 rotation) {
        Vector3 flippedRotation = new Vector3(-rotation.x, -rotation.y, -rotation.z); // flip Y and Z axis for right->left handed conversion
        // convert XYZ to ZYX
        Quaternion qx = Quaternion.AngleAxis(flippedRotation.x, Vector3.right);
        Quaternion qy = Quaternion.AngleAxis(flippedRotation.y, Vector3.forward);
        Quaternion qz = Quaternion.AngleAxis(flippedRotation.z, Vector3.up);
        Quaternion qq = qz * qy * qx; // this is the order
        return qq;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            PosRotMsg TCP_Pos = new PosRotMsg(
                //Left hand coordinate
                // TCP.transform.position.x,
                // TCP.transform.position.y,
                // TCP.transform.position.z,
                
                // TCP.transform.rotation.x,
                // TCP.transform.rotation.y,
                // TCP.transform.rotation.z,
                // TCP.transform.rotation.w

                // Conver from left to right hand coordinate 
                TCP.transform.position.z,
                -TCP.transform.position.x,
                TCP.transform.position.y,

                TCP.transform.rotation.w,
                TCP.transform.rotation.x,
                -TCP.transform.rotation.z,
                TCP.transform.rotation.y
                
            );

            // Finally send the message to server_endpoint.py running in ROS
            ros.Publish(topicName, TCP_Pos);

            timeElapsed = 0;
        }
    }
}