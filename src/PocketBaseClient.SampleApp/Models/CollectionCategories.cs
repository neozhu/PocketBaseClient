
// This file was generated automatically on 8/12/2022 21:42:16(UTC) from the PocketBase schema for Application orm-csharp-test (https://orm-csharp-test.pockethost.io)
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.Orm;
using PocketBaseClient.Orm.Filters;
using PocketBaseClient.Services;

namespace PocketBaseClient.SampleApp.Models
{
    public partial class CollectionCategories : CollectionBase<Category>
    {
        public override string Id => "fgj34p0gy01o41e";
        public override string Name => "categories";
        public override bool System => false;

        public CollectionCategories(DataServiceBase context) : base(context) { }


        public CollectionQuery<CollectionCategories, Category> Filter(string filterString)
             => new CollectionQuery<CollectionCategories, Category>(this, FilterQuery.Create(filterString));

        public CollectionQuery<CollectionCategories, Category> Filter(Func<Category.Filters, FilterQuery> filter)
            => new CollectionQuery<CollectionCategories, Category>(this, filter(new Category.Filters()));

    }
}
