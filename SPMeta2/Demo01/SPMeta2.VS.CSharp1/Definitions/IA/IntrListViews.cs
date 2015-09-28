using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.VS.CSharp1.Definitions.IA
{
    public static class IntrListViews
    {
        // Use BuiltInInternalFieldNames and BuiltInInternalPublishingFieldNames to refer OOTB SharePoint fields
        // Always use internal name in the 'Fields' props, that's how list views work
        // Use 'Query' prop to define correct caml query

        public static ListViewDefinition LastTenDocuments = new ListViewDefinition
        {
            Title = "Last 10 Documents",
            RowLimit = 10,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            IsDefault = true,
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.DocIcon,
                BuiltInInternalFieldNames.LinkFilename,
                IntrFields.DocumentHighlights.InternalName,
                IntrFields.DocumentDescription.InternalName,
                BuiltInInternalFieldNames.Editor,
                BuiltInInternalFieldNames._UIVersionString,
                BuiltInInternalFieldNames.ContentType
            }
        };

        public static ListViewDefinition LastTenDocumentsMainPage = new ListViewDefinition
        {
            Title = "Last 10 Documents Main Page",
            RowLimit = 10,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.DocIcon,
                BuiltInInternalFieldNames.LinkFilename,
                BuiltInInternalFieldNames.Editor,
            }
        };

        public static ListViewDefinition Last25Orders = new ListViewDefinition
        {
            Title = "Last 25 Orders",
            RowLimit = 25,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            IsDefault = true,
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.DocIcon,
                BuiltInInternalFieldNames.LinkFilename,
                IntrFields.OrderDate.InternalName,
                IntrFields.OrderAddressState.InternalName,
                IntrFields.OrderPrice.InternalName,
                IntrFields.OrderSalePercentage.InternalName,
                IntrFields.OrderTrackingUrl.InternalName,
                BuiltInInternalFieldNames.Editor,
                BuiltInInternalFieldNames._UIVersionString,
            }
        };

        public static ListViewDefinition Last10OrdersMainPage = new ListViewDefinition
        {
            Title = "Last 10 Orders Main Pages",
            RowLimit = 10,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            IsDefault = false,
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.DocIcon,
                BuiltInInternalFieldNames.LinkFilename,
                IntrFields.OrderAddressState.InternalName,
                IntrFields.OrderPrice.InternalName,
            }
        };

        public static ListViewDefinition AllProducts = new ListViewDefinition
        {
            Title = "All Products",
            RowLimit = 100,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            IsDefault = true,
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.DocIcon,
                BuiltInInternalFieldNames.LinkFilename,
                IntrFields.ProductDescription.InternalName,
                IntrFields.ProductType.InternalName,
                IntrFields.IsProductActive.InternalName,
                BuiltInInternalFieldNames.Editor,
                BuiltInInternalFieldNames._UIVersionString,
            }
        };

        public static ListViewDefinition LastTenServices = new ListViewDefinition
        {
            Title = "Last 10 Services",
            RowLimit = 10,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.LinkFilename,
                IntrFields.ProductDescription.InternalName,
                IntrFields.ProductType.InternalName,
            }
        };

        public static ListViewDefinition LastTenTasks = new ListViewDefinition
        {
            Title = "Last 10 Tasks",
            RowLimit = 10,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.LinkFilename,
                BuiltInInternalFieldNames.TaskDueDate,
                BuiltInInternalFieldNames.AssignedTo,
            }
        };

        public static ListViewDefinition LastTenTasksMainPage = new ListViewDefinition
        {
            Title = "Last 10 Tasks Main Page",
            RowLimit = 10,
            Query = "<OrderBy><FieldRef Name='ID' Ascending='False'/></OrderBy>",
            Fields = new Collection<string>
            {
                BuiltInInternalFieldNames.LinkFilename,
                BuiltInInternalFieldNames.TaskDueDate,
                BuiltInInternalFieldNames.AssignedTo,
            }
        };
    }
}
