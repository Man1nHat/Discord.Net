﻿using System.Text.Json;

namespace Discord.Serialization.Json.Converters
{
    internal class OptionalPropertyConverter<T> : IJsonPropertyConverter<Optional<T>>
    {
        private readonly IJsonPropertyConverter<T> _innerConverter;

        public OptionalPropertyConverter(IJsonPropertyConverter<T> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public Optional<T> Read(PropertyMap map, ref JsonReader reader, bool isTopLevel)
            => new Optional<T>(_innerConverter.Read(map, ref reader, isTopLevel));

        public void Write(PropertyMap map, ref JsonWriter writer, Optional<T> value, bool isTopLevel)
        {
            if (value.IsSpecified)
                _innerConverter.Write(map, ref writer, value.Value, isTopLevel);
        }
    }
}
