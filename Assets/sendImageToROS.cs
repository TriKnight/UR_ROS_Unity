using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Sensor;
using RosMessageTypes.Std;

public class sendImageToROS : MonoBehaviour
{
    public RenderTexture renderTexture;

    ROSConnection ros;
    public string topicName = "camera1";

    // The game object
    // public GameObject cube;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<ImageMsg>(topicName);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {

            Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);

            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0, false);

            Color32[] pixels = texture.GetPixels32();
            byte[] bytes = new byte[pixels.Length];

            for (int i = pixels.Length - 1; i != 0 ; i--)
            {
                bytes[i] = (byte)pixels[i].r;
            }


            // Finally send the message to server_endpoint.py running in ROS
            ImageMsg testMsg = new ImageMsg(new HeaderMsg(), (uint)renderTexture.height, (uint)renderTexture.width, "mono8", 0x00, (uint)renderTexture.width, bytes);
            ros.Publish(topicName, testMsg);

            timeElapsed = 0;
        }
    }
    
}
