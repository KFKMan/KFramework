using KFramework.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace KFramework
{
    public static class ServiceCollectionObjectAccessorExtensions
    {
        public static ExtendedObjectAccessor<K,T>? AddOrGetExtendedObjectAccessor<K,T>(this IServiceCollection services,Func<K,T> getter)
        {
            if (services.Any(s => s.ServiceType == typeof(ExtendedObjectAccessor<K,T>)))
            {
                return services.GetSingletonInstance<ExtendedObjectAccessor<K, T>>();
            }

            services.AddExtendedObjectAccessor<K,T>(getter);
            return null; //maybe can return?
        }

        public static ExtendedObjectAccessor<K, T> AddOrGetExtendedObjectAccessor<K, T>(this IServiceCollection services, Func<K, T> getter,K basevalue)
        {
            if (services.Any(s => s.ServiceType == typeof(ExtendedObjectAccessor<K, T>)))
            {
                return services.GetSingletonInstance<ExtendedObjectAccessor<K, T>>();
            }

            return services.AddExtendedObjectAccessor<K, T>(getter,basevalue);
        }

        public static ExtendedObjectAccessor<K, T> AddExtendedObjectAccessor<K, T>(this IServiceCollection services, Func<K, T> getter, K basevalue)
        {
            var objectgetter = services.AddExtendedObjectAccessorGetter<K, T>(getter);
            var accessor = new ExtendedObjectAccessor<K, T>(objectgetter, basevalue);
            services.AddSingleton<ExtendedObjectAccessor<K, T>>(accessor);
            services.AddSingleton<IObjectAccessor<T>, ExtendedObjectAccessor<K, T>>((provider) =>
            {
                return accessor;
            });
            return accessor;
        }

        public static ExtendedObjectAccessorGetter<K,T> AddExtendedObjectAccessorGetter<K,T>(this IServiceCollection services, Func<K, T> getter)
        {
            var objectgetter = new ExtendedObjectAccessorGetter<K, T>(getter);

            services.AddSingleton<ExtendedObjectAccessorGetter<K, T>>(objectgetter);
            services.AddSingleton<IExtendedObjectAccessorGetter<K, T>>(objectgetter);

            return objectgetter;
        }

        public static void AddExtendedObjectAccessor<K,T>(this IServiceCollection services, Func<K, T> getter)
        {
            services.AddExtendedObjectAccessorGetter<K, T>(getter);

            services.AddSingleton<ExtendedObjectAccessor<K, T>>();
            services.AddSingleton<IObjectAccessor<T>,ExtendedObjectAccessor <K,T>>();
        }

        public static ObjectAccessor<T> AddOrGetObjectAccessor<T>(this IServiceCollection services)
        {
            if (services.Any(s => s.ServiceType == typeof(ObjectAccessor<T>)))
            {
                return services.GetSingletonInstance<ObjectAccessor<T>>();
            }

            return services.AddObjectAccessor<T>();
        }

        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services)
        {
            return services.AddObjectAccessor(new ObjectAccessor<T>());
        }

        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, T obj)
        {
            return services.AddObjectAccessor(new ObjectAccessor<T>(obj));
        }

        public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, ObjectAccessor<T> accessor)
        {
            if (services.Any(s => s.ServiceType == typeof(ObjectAccessor<T>)))
            {
                throw new Exception("An object accessor is registered before for type: " + typeof(T).AssemblyQualifiedName);
            }

            //Add to the beginning for fast retrieve
            services.Insert(0, ServiceDescriptor.Singleton(typeof(ObjectAccessor<T>), accessor));
            services.Insert(0, ServiceDescriptor.Singleton(typeof(IObjectAccessor<T>), accessor));

            return accessor;
        }

        public static T? GetObjectOrNull<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetSingletonInstanceOrNull<IObjectAccessor<T>>().IfNotNull((A)=>A.Get(),null);
        }

        public static T GetObject<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetObjectOrNull<T>() ?? throw new Exception($"Could not find an object of {typeof(T).AssemblyQualifiedName} in services. Be sure that you have used AddObjectAccessor before!");
        }
    }
}