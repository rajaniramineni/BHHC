// GraphqlController.cs

using System.Threading.Tasks;
using BHHCApi.Graphql;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GraphQL.Types;

namespace BHHCApi.Controllers
{
    [Route("graphql")]
   
    public class GraphqlController : Controller
    {

        
        private  ISchema _schema;
        private  IDocumentExecuter _executer;
        public void GraphQLController(ISchema schema,
        IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new BHHCSchema();
            Inputs inputs = null;
            if (query.Variables != null)
            {
                var variables = query.Variables as Newtonsoft.Json.Linq.JObject;
                var values = variables.ToObject<Dictionary<string, object>>();
                inputs = new Inputs(values);
            }


            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema.GraphQLSchema;
                _.Query = query.Query;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}