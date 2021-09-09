using GraphQL.Types;
using BHHCApi.Database;
namespace BHHCApi.Graphql.Types
{
    public class ReasonType : ObjectGraphType<BHHCReason>
    {
        public ReasonType()
        {
            Name = "Reason";
            Field(_ => _.Description).Description("Reason Description");
        }
    }
}