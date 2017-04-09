using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;

namespace NotesApi.Auth
{
    public class JWTToken : IJWTToken
    {
        private const string SECRET = "asufpoweufon4wut09nuega98nugndgnud8gnu"; // TODO hide it before github

        private readonly IJwtEncoder _encoder;
        private readonly IJwtDecoder _decoder;

        public JWTToken(IJwtEncoder encoder, IJwtDecoder decoder
            )
        {
            _encoder = encoder;
            _decoder = decoder;
        }

        public string Build(Payload payload)
        {
            return _encoder.Encode(payload, SECRET);      
        }

        public Payload Parse(string token)
        {
            return _decoder.DecodeToObject<Payload>(token, SECRET, verify: true);         
        }
    }
}
