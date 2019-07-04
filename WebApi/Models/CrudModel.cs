using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Runtime.Serialization;

namespace WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class CrudModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logOnUserName"></param>
        /// <param name="logOnUserCode"></param>
       
        public CrudModel(string logOnUserName, string logOnUserCode)
        {
            UserNameWithCode = logOnUserName + "[" + logOnUserCode + "]";
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        [IgnoreDataMember]
        public string DomainCode { get; set; }

        public string ProcessName { get; set; }
        [IgnoreDataMember]
        public string UserNameWithCode { get; set; }

        [IgnoreDataMember]
        public DateTime UpdatedDate { get; set; }

        public string AuditTrailData { get; set; }

        /// <summary>
        /// Insert / Update
        /// </summary>
        public string ActionType { get; set; }
    }
}