﻿// Project site: https://github.com/iluvadev/PocketBaseClient-csharp
//
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// Copyright (c) 2022, iluvadev, and released under MIT License.
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.Orm.Filters;
using System.Collections;

namespace PocketBaseClient.Orm
{
    public class CollectionQuery<C, S, T> : IEnumerable<T>
        where C : CollectionBase<T>
        where T : ItemBase, new()
        where S : ItemBaseSorts, new()
    {
        internal FilterCommand? Filter { get; set; }
        internal SortCommand? Sort { get; set; }
        internal C Collection { get; set; }

        public CollectionQuery(C collection, FilterCommand? filter)
        {
            Collection = collection;
            Filter = filter;
        }

        public IEnumerable<T> SortBy(Func<S, SortCommand> commandSelector)
        {
            Sort = commandSelector.Invoke(new());
            return this;
        }

        private IEnumerable<T> GetItems()
        {
            foreach (var item in Collection.GetItemsFromPb(Filter?.Command, Sort?.Command))
                yield return item;
        }

        public IEnumerator<T> GetEnumerator()
            => GetItems().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
