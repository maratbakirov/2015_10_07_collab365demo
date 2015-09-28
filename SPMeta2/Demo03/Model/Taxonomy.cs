using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Standard.Definitions.Taxonomy;

namespace Model
{
    public class Taxonomy
    {

        public static TaxonomyTermStoreDefinition TermStore = new TaxonomyTermStoreDefinition
        {
            UseDefaultSiteCollectionTermStore = true,
        };

        public static TaxonomyTermGroupDefinition RootGroup = new TaxonomyTermGroupDefinition
        {
            Name = "RootGroup3",
            Id = new Guid("{1BA27B3B-300F-48B8-AA4E-73FC1A140117}")
        };
        public static TaxonomyTermSetDefinition Location = new TaxonomyTermSetDefinition
        {
            Name = "Location",
            Id = new Guid("{15EAF349-395B-4D00-9064-5FB46A52FC97}"),
            LCID = 1033
        };

        public static TaxonomyTermDefinition RootTerm = new TaxonomyTermDefinition
        {
            Name = "Root",
            Id = new Guid("{26068867-9F84-4CC1-91DC-2300026EA580}"),
            LCID = 1033
        };
        public static TaxonomyTermDefinition SubTerm1 = new TaxonomyTermDefinition
        {
            Name = "SubTerm1",
            Id = new Guid("{344898F4-D1AF-4ADB-A6CA-586E6DCBF9C2}"),
            LCID = 1033
        };
        public static TaxonomyTermDefinition SubTerm2 = new TaxonomyTermDefinition
        {
            Name = "SubTerm2",
            Id = new Guid("{4F3A616F-5F66-4DA7-8B28-A53581748CA9}"),
            LCID = 1033
        };

    }
}
