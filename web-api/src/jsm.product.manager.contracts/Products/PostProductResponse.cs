﻿using Newtonsoft.Json;

namespace jsm.product.manager.application.Handlers.Products
{
    public class PostProductResponse
    {
        protected PostProductResponse() { }
        public PostProductResponse(Guid id)
        {
            Id = id;
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public virtual Guid Id { get; private set; }
    }
}
