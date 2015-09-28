using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;

namespace SPMeta2.VS.CSharp1.Definitions.Security
{
    public static class IntrSecurityGroups
    {
        public static SecurityGroupDefinition OrderApprovers = new SecurityGroupDefinition
        {
            Name = "Order Approvers",
            Description = "People who can approve orders."
        };

        public static SecurityGroupDefinition OrderReviewers = new SecurityGroupDefinition
        {
            Name = "Order Reviewers",
            Description = "People who can review orders."
        };
    }
}
