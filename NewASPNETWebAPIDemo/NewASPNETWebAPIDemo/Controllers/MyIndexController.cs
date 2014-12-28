using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using NewASPNETWebAPIDemo.Models;
using System.Net;
using System.Json;

namespace NewASPNETWebAPIDemo.Controllers
{
    public class MyIndexController : ApiController
    {
        // GET /api/values
        public IEnumerable<MyIndex> ListMyIndexes()
        {
            return new List<MyIndex> {
                new MyIndex {ID = 1, Name = "Rasel Ahmmed Bappi", Mobile = "+88-02-01911045573", Email = "raselahmmed@gmail.com"},
                new MyIndex {ID = 2, Name="William Shakespeare", Mobile="013456", Email="shakespeare@mail.com"},
                new MyIndex {ID = 3, Name="Mohammad Ali", Mobile="0123456", Email="ali@mail.com"},
                new MyIndex {ID = 4, Name="Madonna", Mobile="013456", Email="madonna@mail.com"},
                new MyIndex {ID = 5, Name="Princess Diana", Mobile="0123456", Email="diana@mail.com"}
            }.AsQueryable();
        }

        // GET /api/values/by id
        public MyIndex GetMyIndex(int id)
        {
            // Return MyIndex by id
            if (id == 1)
            {
                return new MyIndex { ID = 1, Name = "Rasel Ahmmed Bappi", Mobile = "+88-02-01911045573", Email = "raselahmmed@gmail.com" };
            }

            // Otherwise, MyIndex was not found, for HTTP status code
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST /api/values
        public HttpResponseMessage PostMyIndex(MyIndex myIndexToCreate)
        {
            // Add MyIndexToCreate ti the database and update Primary key
            myIndexToCreate.ID = 20;

            // Validate MyIndex
            if (!ModelState.IsValid)
            {
                var errors = new JsonArray();

                foreach (var prop in ModelState.Values)
                {
                    if (prop.Errors.Any())
                    {
                        errors.Add(prop.Errors.First().ErrorMessage);
                    }
                }
                return new HttpResponseMessage<JsonValue>(errors, HttpStatusCode.BadRequest);
            }

            // Bild a response thet contains the lacation of the new MyIndex
            var response = new HttpResponseMessage<MyIndex>(myIndexToCreate, HttpStatusCode.Created);
            var relativePath = "/api/MyIndex/" + myIndexToCreate;

            response.Headers.Location = new Uri(Request.RequestUri, relativePath);

            return response;
        }

        // PUT /api/values/by id
        public void PutMyIndex(MyIndex myIndexToUpdate)
        {
            if (myIndexToUpdate.ID == 1)
            {
                // Update the MyIndex in the database
                return;
            }

            // If you can't find the MyIndex to update
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // DELETE /api/values/by id
        public HttpResponseMessage DeleteMyIndex(int id)
        {
            // Delete the MyIndex from the database
            if (id == 1)
            {
                // After delete return
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // Return status code
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}