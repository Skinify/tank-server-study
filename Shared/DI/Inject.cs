﻿using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static CenterWorker.CenterEndpoint;
using Extensions;

namespace Shared.DI
{
    public static partial class Inject
    {
        public static void InjectCenterClient(this IServiceCollection serviceDescriptors, string centerEndpoint)
        {
            serviceDescriptors.AddSingleton(option => new CenterEndpointClient(GrpcChannel.ForAddress(centerEndpoint)));
        }

        public static T InjectSettings<T>(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            Type tType = typeof(T);

            var activatedInstance = Activator.CreateInstance(tType);

            if (activatedInstance is null)
                throw new Exception($"Error trying to instantiate config of type {tType.Name}");

            var config = (T)activatedInstance;

            var props = tType.GetProperties();

            props.ToList().ForEach(prop =>
            {
                var propType = prop.PropertyType;
                if (!prop.CanWrite)
                    return;

                var setMethod = prop.GetSetMethod(false);
                if (propType.IsClass && propType != typeof(string))
                {
                    if (propType.IsArray)
                    {
                        var propValue = configuration.GetSection(prop.Name).Get<string[]>();
                        prop.SetValue(config, propValue);
                    }
                    else
                    {
                        var __t = Activator.CreateInstance(propType);
                        configuration.GetSection(prop.Name).Bind(__t);

                        prop.SetValue(config, __t);
                    }
                }
                else
                {
                    var propValue = configuration.GetValue<string>(prop.Name);
                    if (propValue is null)
                        return;

                    prop.SetValue(config, Convert.ChangeType(propValue, propType));
                }
            });

            serviceDescriptors.AddSingleton(tType, config);
            return config;
        }
    }
}
