//using System;
//using System.Web.Mvc;
//using Andromeda.Composites.AgentResolution;
//using Andromeda.Composites.Extensions;
//using Andromeda.Composites.Mvc.Extensions;
//using Andromeda.Framework.Agent.Metadata;

//namespace Andromeda.Composites.Mvc.Binders
//{
//    public class AgentPartMetadataCollectionBinder : IAndromedaModelBinder
//    {
//        private readonly IAgentResolver[] _resolvers;

//        public AgentPartMetadataCollectionBinder(IAgentResolver[] resolvers)
//        {
//            _resolvers = resolvers;
//        }

//        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
//        {
//            var systemName = controllerContext.GetAgentSystemName();

//            var partType = controllerContext.GetRouteValue<string>("partType");

//            if (string.IsNullOrEmpty(partType))
//            {
//                throw new AgentPartTypeNotSpecifiedException();
//            }

//            var metadata = _resolvers.GetAgentMetadata(systemName);

//            return metadata.Where(a=>a);
//        }

//        public bool IsMatch(Type modelType)
//        {
//            return typeof (IAgentPartMetadataFormatterCollection).IsAssignableFrom(modelType);
//        }
//    }
//}