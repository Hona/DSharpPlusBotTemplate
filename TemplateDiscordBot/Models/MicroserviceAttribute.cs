using System;

namespace TemplateDiscordBot.Models
{
    public class MicroserviceAttribute : Attribute
    {
        public MicroserviceAttribute(MicroserviceType microserviceType = MicroserviceType.Manual) =>
            Type = microserviceType;

        public MicroserviceType Type { get; }
    }
}