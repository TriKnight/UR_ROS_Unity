using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosJointStates = RosMessageTypes.Sensor.JointStateMsg;
using System.Collections;

public class RosSubcriberJointStates : MonoBehaviour
{   
    [SerializeField] private string rosTopic = "joint_states";
    [SerializeField] private ROSConnection ROS;
    [SerializeField] private ArticulationBody[] robotJoints = new ArticulationBody[6];
    // Start is called before the first frame update
    void Start()
    {
        ROS = ROSConnection.GetOrCreateInstance();
        ROS.Subscribe<RosJointStates>(rosTopic, GetJointPositions);
    }

    // Update is called once per frame
    private void GetJointPositions(RosJointStates sensorMsg)
    {
        StartCoroutine(SetJointValues(sensorMsg));
    }
    IEnumerator SetJointValues(RosJointStates message)
    {
        for (int i = 0; i < message.name.Length; i++)
        {
            var joint1XDrive = robotJoints[i].xDrive;
            joint1XDrive.target = (float)(message.position[i]) * Mathf.Rad2Deg;
            robotJoints[i].xDrive = joint1XDrive;
            Debug.Log("Joint Position " + "[" + i + "]" +joint1XDrive.target + "(deg)");
        }
 
        yield return new WaitForSeconds(0.5f);
    }
 
    public void UnSub()
    {
        ROS.Unsubscribe(rosTopic);
    }
}

