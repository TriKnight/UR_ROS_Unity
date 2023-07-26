//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class PlaceFeedback : Message
    {
        public const string k_RosMessageName = "moveit_msgs/Place";
        public override string RosMessageName => k_RosMessageName;

        //  The internal state that the place action currently is in
        public string state;

        public PlaceFeedback()
        {
            this.state = "";
        }

        public PlaceFeedback(string state)
        {
            this.state = state;
        }

        public static PlaceFeedback Deserialize(MessageDeserializer deserializer) => new PlaceFeedback(deserializer);

        private PlaceFeedback(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.state);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.state);
        }

        public override string ToString()
        {
            return "PlaceFeedback: " +
            "\nstate: " + state.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Feedback);
        }
    }
}
