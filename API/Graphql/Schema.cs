using GraphQL.Types;
using GraphQL;
using Api.Database;

namespace Api.Graphql
{
    public class mySchema
    {
        private ISchema _schema { get; set; }
        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        public mySchema()
        {
            this._schema = Schema.For(@"   
            
            type Reason {
            id: ID
            description: String,
           
          }
            type Strength {
              id: ID
             strengthDescription: String,
           
          }
        type GoodFitFact {
                id: ID
                factdescription: String,
           
             }
          type Query {              
              reasons(type: String): [Reason]
              strengths:[Strength]
              goodFitFacts:[GoodFitFact]
              hello: String             
          }
      ", _ =>
            {
                _.Types.Include<Query>();
               // _.Types.Include<Mutation>();
            });
        }

    }
}