using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosJointStates = RosMessageTypes.Moveit.RobotStateMsg;

public class RosJointStateSubscriber : MonoBehaviour
{
    
    public GameObject robot;
    public string topicName = "joint_states";
    
    // Start is called before the first frame update
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<RosJointStates>(topicName, JointStateChange);
    }

    // Update is called once per frame
    void JointStateChange(RosJointStates jointStateMessage)
    {
         Debug.LogError("get JointState");
    }
}
