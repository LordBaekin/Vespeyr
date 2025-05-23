// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using UnityEngine;
    using Coherence.Entities;
    using Toolkit;
    using Coherence.SimulationFrame;
    
    public class CoherenceGlobalQueryImpl
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnRuntimeMethodLoad()
        {
            Impl.CreateGlobalQuery = CreateGlobalQuery;
            Impl.AddGlobalQuery = AddGlobalQuery;
            Impl.RemoveGlobalQuery = RemoveGlobalQuery;
        }

        private static Entity CreateGlobalQuery(IClient client) 
        {
            var components = new ICoherenceComponentData[] 
            {
                new GlobalQuery { }
            };

            return client.CreateEntity(components, false);
        }

        private static void AddGlobalQuery(IClient client, Entity query)
        {
            var components = new ICoherenceComponentData[] 
            {
                new GlobalQuery { }
            };

            client.UpdateComponents(query, components);
        }

        private static void RemoveGlobalQuery(IClient client, Entity query)
        {
            client.RemoveComponents(query, new []{Definition.InternalGlobalQuery});
        }
    }
}
