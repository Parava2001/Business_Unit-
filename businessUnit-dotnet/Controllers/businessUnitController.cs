using businessUnit.component.EfCore;
using businessUnit.Model;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


// This initially provide a dummy method for the GET POST PUT and DELETEaoi
namespace businessUnit.Controllers
{
    [Route("api/[controller]/")]  
    [ApiController]               // Attribute Routing


    public class businessUnitController : ControllerBase  // it is always inherited from the controller base class
    {

        private readonly DbHelper db; // this provide assess to the database

        public DbHelper Db { get; }

        public businessUnitController(EF_DataContext eF_DataContext)   // this pharase , injecting the entity framework context to the class
        {
            db = new DbHelper(eF_DataContext);
        }

        public businessUnitController(DbHelper db1)
        {
            Db = db1;
        }


        // GET: api/<businessUnitController>
        [HttpGet]
        [Route("GetBusinessUnits")]  // inside the route , it is a hardcodevalue
        [Route("GetDetailsofBusinessUnit")]  // multiple URL for same resourses
        public IActionResult Get() //The ActionResult types represent various HTTP status codes.
                                   //Some common return types falling into this category are BadRequestResult (400),
                                   //NotFoundResult (404), and OkObjectResult (200).
        {
            ResponseType type = ResponseType.Success;
           try
            {
                IEnumerable<businessUnitModel> data = db.GetBusinessUnits();  // IEnumerable interface is one of the best features of C# language which loops over the collection.
                if (!data.Any()) { 
                    type = ResponseType.NotFound;
                }
              return Ok(data); // Ok Status Code is imp in using Get 
            }
            catch (Exception exception)
            { 
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(exception)); // BadRequest used for http status code
            }
        }

        // GET api/<businessUnitController>/5
        [HttpGet]
        [Route("GetBusinessUnitsById/{id}")] // GetBusinessUnitsById is a hardcodevalue and id is a dynamic value and is represented inside {} and min shws that the id must has a limit of 100
                                              // we can use multiple dynamic value in routing ie for example : GetBusinessUnitsById/{id}/Author/{AuthorId}
        public IActionResult Get([FromRoute]int id)
        { 
               ResponseType type = ResponseType.Success;
                   try
                    {
                            businessUnitModel data = db.GetBusinessUnitsById(id);
                            Console.WriteLine(data);
                            if (data == null) 
                        {
                            type = ResponseType.NotFound;
                        }
                            return Ok(data);
        }
                    catch (Exception exception)
                    {
                            type = ResponseType.Failure;
                            return BadRequest(ResponseHandler.GetExceptionResponse(exception));
        }
                   }

        // POST api/<businessUnitController>
        [HttpPost]
        [Route("SaveOrder")]
        public IActionResult Post([FromBody] businessUnitModel details) // FromBody binding system is provided so that the data which is given in the body only will be binded
        {
            try
            {
                ResponseType type = ResponseType.Success;
                db.SaveOrder(details);
                return Ok(ResponseHandler.GetAppResponse(type, details));
            }
            catch (Exception exception)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(exception));
            }
        }



        //PATCH
        [HttpPatch]
        [Route("EditLocations/{id}")]


        public IActionResult Patch([FromRoute] int id,[FromBody] businessUnitModel details)
        {
            try
            {
                //ResponseType type = ResponseType.Success;
                db.EditLocation(id,details);
                return Ok(details);
            }
            catch (Exception exception)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(exception));
            }
        }






        // DELETE api/<businessUnitController>/5
        [HttpDelete]
        [Route("DeleteUnits/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                db.DeleteUnits(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Succesfully"));
            }
            catch (Exception exception)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(exception));
            }
        }
    }
}
