using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi
{
    [RoutePrefix("api/auditTrail")]
    public class CrudController : BaseController
    {
        string constr = ConfigurationManager.AppSettings["mondoDbConnectionString"];
        public CrudController()
        {

        }

        [Route("Save")]
        [ResponseType(typeof(string))]
        [HttpPost]
        public IHttpActionResult SaveAuditTrail()
        {
            var model = new CrudModel(CurrentUser.UserName, CurrentUser.UserCode)
            {
                DomainCode = CurrentUser.DomainCode,
                ProcessName = "test",
                UpdatedDate = DateTime.UtcNow,
                ActionType="Insert",
                AuditTrailData = "fdsaf fsdsaf dsfds"
            };

            var Client = new MongoClient(constr);
            var db = Client.GetDatabase(CurrentUser.DomainCode);
            var collection = db.GetCollection<CrudModel>(model.ProcessName);
            collection.InsertOne(model);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAll")]
        [ResponseType(typeof(ICollection<CrudModel>))]
        [HttpGet]
        public IHttpActionResult ProcessAuditTrails(string processName)
        {
            var Client = new MongoClient(constr);
            var db = Client.GetDatabase(CurrentUser.DomainCode);
            var collection = db.GetCollection<CrudModel>(processName).Find(new BsonDocument()).ToList();
            return Ok(collection);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="processName"></param>
       /// <param name="id"></param>
       /// <returns></returns>
        [Route("Process")]
        [ResponseType(typeof(ICollection<CrudModel>))]
        [HttpGet]
        public IHttpActionResult ProcessAuditTrail(string processName,string id)
        {

            var Client = new MongoClient(constr);
            var DB = Client.GetDatabase("Employee");
            var collection = DB.GetCollection<CrudModel>(processName);
            var plant = collection.Find(Builders<CrudModel>.Filter.Where(s => s.Id == id)).FirstOrDefault();
            return Ok(plant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Delete")]
        [HttpDelete]
        public object Delete(string processName, string id)
        {
                var Client = new MongoClient(constr);
                var DB = Client.GetDatabase(CurrentUser.DomainCode);
                var collection = DB.GetCollection<CrudModel>(processName);
                var DeleteRecored = collection.DeleteOneAsync(
                               Builders<CrudModel>.Filter.Eq("Id", id));
                return Ok();
        }
    }
}
