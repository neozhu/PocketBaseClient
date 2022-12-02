﻿using PocketBaseClient.Orm.Json;
using System.Text.Json.Serialization;

namespace PocketBaseClient.Orm
{
    public abstract class ItemBase
    {
        [JsonPropertyName("collectionId")]
        [JsonConverter(typeof(CollectionIdConverter))]
        public CollectionBase? Collection { get; internal set; }

        [JsonPropertyName("id")]
        public string? Id { get; init; }

        [JsonPropertyName("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Created { get; set; }

        [JsonPropertyName("updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Updated { get; set; }

        private void Load()
        {

        }
        protected T Get<T>(Func<T> func)
        {
            Load();
            return func();
        }
        protected void Set<T>(T? value, ref T? valueVar)
        {
            if (value == null && valueVar == null) return;
            if (valueVar == null || !valueVar.Equals(value))
                valueVar = value;
        }

        private ItemMetadata? _Metadata = null;
        public ItemMetadata Metadata() => _Metadata ??= new ItemMetadata(this);

        public bool IsValid()
            => Metadata().IsLoaded && !Metadata().IsTrash;
    }
}
