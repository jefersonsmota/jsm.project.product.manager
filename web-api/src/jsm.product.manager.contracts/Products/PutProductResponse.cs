﻿using Newtonsoft.Json;

namespace jsm.product.manager.contracts.Products
{
    public class PutProductResponse
    {
        protected PutProductResponse() { }
        public PutProductResponse(Guid id)
        {
            Id = id;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public virtual Guid Id { get; private set; }
    }
}
