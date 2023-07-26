//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class QueryPlannerInterfacesResponse : Message
    {
        public const string k_RosMessageName = "moveit_msgs/QueryPlannerInterfaces";
        public override string RosMessageName => k_RosMessageName;

        //  The planning instances that could be used in the benchmark
        public PlannerInterfaceDescriptionMsg[] planner_interfaces;

        public QueryPlannerInterfacesResponse()
        {
            this.planner_interfaces = new PlannerInterfaceDescriptionMsg[0];
        }

        public QueryPlannerInterfacesResponse(PlannerInterfaceDescriptionMsg[] planner_interfaces)
        {
            this.planner_interfaces = planner_interfaces;
        }

        public static QueryPlannerInterfacesResponse Deserialize(MessageDeserializer deserializer) => new QueryPlannerInterfacesResponse(deserializer);

        private QueryPlannerInterfacesResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.planner_interfaces, PlannerInterfaceDescriptionMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.WriteLength(this.planner_interfaces);
            serializer.Write(this.planner_interfaces);
        }

        public override string ToString()
        {
            return "QueryPlannerInterfacesResponse: " +
            "\nplanner_interfaces: " + System.String.Join(", ", planner_interfaces.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}
