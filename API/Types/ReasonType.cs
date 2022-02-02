using GraphQL.Types;
using Api.Database;
namespace Api.Graphql.Types
{
    public class ReasonType : ObjectGraphType<Reason>
    {
        public ReasonType()
        {
            Name = "Reason";
            Field(_ => _.Description).Description("Reason Description");
        }
    }
}