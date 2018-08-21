﻿using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LaGuineuService.Services
{
    public class TokenService : ITokenService
    {
        private laguineuContext db = new laguineuContext();
        private string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public Token CreateToken(Usuario usuario, string operacion)
        {
            var today = DateTime.Now;
            var payload = new Dictionary<string, object>();
            /*  if (operacion == "Monitor")
              {
                  payload = new Dictionary<string, object>
                  {
                      { "IdEscuela", usuario.IdEscuela },
                      { "IdMonitor", usuario.IdMonitor },
                      { "exp", today.AddHours(12) }
                  };
              }
              if (operacion == "Gestor")
              {*/

            //}
            payload = new Dictionary<string, object>
                {
                    { "IdUsuario", usuario.Id },
                    { "IdEscuela", usuario.IdEscuela },
                    { "exp", today.AddHours(12) }
                };

            /* IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
             IJsonSerializer serializer = new JsonNetSerializer();
             IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
             IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
             var tokenString = encoder.Encode(payload, secret);*/
            Token token = new Token();
            //token.Nombre = tokenString;
            token.IdEscuela = 1;//usuario.IdEscuela;
            token.IdUsuario = usuario.Id;
            //token.IdMonitor = usuario.IdMonitor;
            token.FechaCrea = today;
            token.Id = usuario.Id;
            db.Token.Add(token);
            // db.SaveChanges();
            return token;
        }

        // Verifica
        public Object DecodingToken(string token)
        {
            /*try
            {
                IJsonSerializer serializer = new JsonNetSerializer(); 
                 IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var json = decoder.Decode(token, secret, verify: false);
                Token tokenObj = new Token();
                JObject obj = JObject.Parse(json);
               
                    var aux = ((string)obj.SelectToken("exp")).Split(' ');
                    var fecha = aux[0].Split('/');
                    var horas = aux[1].Split(':');
                    var exp = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[0]), int.Parse(fecha[1]), int.Parse(horas[0]), int.Parse(horas[1]), int.Parse(horas[2]));
                    tokenObj.IdEscuela = (int)obj.SelectToken("IdEscuela");
                    if (obj.SelectToken("IdMonitor") != null)
                    {
                        tokenObj.IdMonitor = (int)obj.SelectToken("IdMonitor");
                    }
                    else
                    {
                        tokenObj.IdUsuario = (int)obj.SelectToken("IdUsuario");
                    }
                
                return tokenObj;
                return null;
            }
            catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return  "Token has invalid signature";
            }*/
            return null;
        }



        /*
        Custom JSON serializer

        By default JSON serialization is done by JsonNetSerializer implemented using Json.Net. To configure a different one first implement the IJsonSerializer interface:

        public class CustomJsonSerializer : IJsonSerializer
        {
            public string Serialize(object obj)
            {
                // Implement using favorite JSON Serializer
            }

            public T Deserialize<T>(string json)
            {
                // Implement using favorite JSON Serializer
            }
        }
        And then pass this serializer as a dependency to JwtEncoder constructor:

        IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
        IJsonSerializer serializer = new CustomJsonSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

        */



    }
    }


