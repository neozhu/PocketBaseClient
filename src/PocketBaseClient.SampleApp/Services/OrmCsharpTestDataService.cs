
// This file was generated automatically on 2/12/2022 22:42:28(UTC) from the PocketBase schema for Application orm-csharp-test (https://orm-csharp-test.pockethost.io)
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.Services;
using PocketBaseClient.SampleApp.Models;

namespace PocketBaseClient.SampleApp.Services
{
    public partial class OrmCsharpTestDataService : DataServiceBase
    {
        #region Collections
        public CollectionUsers UsersCollection { get; }
        public CollectionTestForTypes TestForTypesCollection { get; }
        public CollectionTestForRelated TestForRelatedCollection { get; }

        protected override void RegisterCollections()
        {
            RegisterCollection(typeof(User), UsersCollection);
            RegisterCollection(typeof(TestForTypes), TestForTypesCollection);
            RegisterCollection(typeof(TestForRelated), TestForRelatedCollection);
        }
        #endregion Collections

        #region Constructor
        public OrmCsharpTestDataService(PocketBaseClientApplication app) : base(app)
        {
            // Collections
            UsersCollection = new CollectionUsers(this);
            TestForTypesCollection = new CollectionTestForTypes(this);
            TestForRelatedCollection = new CollectionTestForRelated(this);
        }
        #endregion Constructor
    }
}
