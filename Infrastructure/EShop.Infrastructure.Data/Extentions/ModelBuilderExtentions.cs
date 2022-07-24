using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Data.Extentions
{
    public static class ModelBuilderExtentions
    {
        public static ModelBuilder ApplyAllConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var applyGenericMethod =
                typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);
            
            foreach (var type in assembly.GetTypes()
                         .Where(t => t.IsClass && !t.IsAbstract && !t.ContainsGenericParameters))
            {
                foreach (var item in type.GetInterfaces())
                {
                    if (item.IsConstructedGenericType &&
                        item.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        var applyConcreteMethod =
                            applyGenericMethod.MakeGenericMethod(item.GenericTypeArguments[0]);
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }
            return modelBuilder;
        } 
    }
}