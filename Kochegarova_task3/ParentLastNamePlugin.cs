using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Samples
{
    public class CreatePluginForLastName : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            Entity child = (Entity)context.InputParameters["Target"];
            EntityReference parentRef = child.GetAttributeValue<EntityReference>("new_parentid");
            if (parentRef != null)
            {
                var parentRecord = service.Retrieve("new_kochegarova2019", parentRef.Id, new Xrm.Sdk.Query.ColumnSet("new_lastname"));
                string lastNameFromParentEntity = parentRecord.GetAttributeValue<string>("new_lastname");
                child["new_lastname"] = lastNameFromParentEntity;
                tracingService.Trace("lastNameFromParentEntity:" + lastNameFromParentEntity);
            }
            service.Update(child);

        }
    }
}