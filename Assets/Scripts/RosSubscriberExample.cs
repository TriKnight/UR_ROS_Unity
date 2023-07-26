using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosColor = RosMessageTypes.UnityRoboticsDemo.UnityColorMsg;

public class RosSubscriberExample : MonoBehaviour
{
    public GameObject cube;
    public string topicName = "color";
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<RosColor>(topicName, ColorChange);
    }

    void ColorChange(RosColor colorMessage)
    {
        Debug.unityLogger.Log("Get the cube");

        cube.GetComponent<Renderer>().material.color = new Color32((byte)colorMessage.r, (byte)colorMessage.g, (byte)colorMessage.b, (byte)colorMessage.a);
    }
}