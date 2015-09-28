using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Standard.Definitions.Taxonomy;

namespace SPMeta2.VS.CSharp1.Definitions.Taxonomy
{
    public static class IntrTaxonomyTermGroups
    {
        // Use IsSiteCollectionGroup to indicate default site scoped taxonomy group 

        public static TaxonomyTermGroupDefinition OrdersCRM = new TaxonomyTermGroupDefinition
        {
            Name = "Orders CRM"
        };
    }
}
