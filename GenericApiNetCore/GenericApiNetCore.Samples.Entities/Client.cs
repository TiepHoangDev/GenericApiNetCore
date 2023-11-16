﻿namespace GenericApiNetCore.Samples.Entities
{
    [ApiInfoRequest("api/client")]
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = DateTime.Now.ToString();
    }
}