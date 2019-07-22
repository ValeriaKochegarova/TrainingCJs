using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Samples
{
    public class CalculateAmount : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            Entity child = (Entity)context.InputParameters["Target"];
            EntityReference parentRef = child.GetAttributeValue<EntityReference>("new_parentid");

            string fetchXml = @"<fetch top='50' >
                  <entity name='new_kochegarova2019_child' >
                    <attribute name='new_amount' />
                    <filter type='and' >
                      <condition attribute='new_parentid' operator='eq' value='{0}' />
                    </filter>
                  </entity>
                </fetch>";

            fetchXml = string.Format(fetchXml, parentRef.Id);
            EntityCollection res = service.RetrieveMultiple(new FetchExpression(fetchXml));


            tracingService.Trace("child count:" + res.Entities.Count);
            decimal total = 0;
            foreach (var item in res.Entities)
            {
                Money amount = item.GetAttributeValue<Money>("new_amount");
                total += amount.Value;
            }
            tracingService.Trace("total amount:" + total);
            Entity parent = new Entity("new_kochegarova2019", parentRef.Id);
            parent["new_amount"] = new Money(total);

            service.Update(parent);

        }
    }
}
