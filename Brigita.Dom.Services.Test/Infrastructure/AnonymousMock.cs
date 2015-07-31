using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ploeh.AutoFixture;

namespace Brigita.Services.Test.Infrastructure
{

    public static class AnonymousMock
    {
        public static Mock<T> CreateAnonymousMock<T>(
            this Fixture fixture) where T : class {
            return new Factory<T>(fixture).CreateAnonymousMock();
        }

        private class Factory<T> where T : class
        {
            private readonly Fixture fixture;
            private Mock<T> mock;
            private MethodInfo setupGet;
            private PropertyInfo property;
            private object returnsGetter;
            private MethodInfo returns;

            internal Factory(Fixture fixture) {
                this.fixture = fixture;
            }

            internal Mock<T> CreateAnonymousMock() {
                mock = new Mock<T>();
                setupGet = mock.GetType().GetMethod("SetupGet");
                typeof(T).GetProperties()
                    .Where(p => p.CanRead)
                    .ToList()
                    .ForEach(p => { property = p; SetupGet(); });
                return mock;
            }

            private void SetupGet() {
                var genericSetupGet = setupGet
                    .MakeGenericMethod(property.PropertyType);
                var expression = GetPropertyLambdaExpression();
                returnsGetter = genericSetupGet
                    .Invoke(mock, new object[] { expression });
                UseReturnsGetter();
            }

            private void UseReturnsGetter() {
                returns = returnsGetter.GetType().GetMethods()
                    .Single(m => m.Name == "Returns" && m.GetParameters()
                        .Any(p => p.ParameterType == property.PropertyType));
                Returns();
            }

            private void Returns() {
                var propertyValue = GetValueFromFixture();
                returns.Invoke(returnsGetter, new object[] { propertyValue });
            }

            private LambdaExpression GetPropertyLambdaExpression() {
                var typeParameter = Expression.Parameter(typeof(T));
                var propertyExpression = Expression
                    .Property(typeParameter, property);
                return Expression.Lambda(propertyExpression, typeParameter);
            }

            private object GetValueFromFixture() {
                
                var createAnonymous = typeof(SpecimenFactory).GetMethods()
                    .Single(m => m.Name == "CreateAnonymous"
                        && m.GetParameters().All(p => p.ParameterType
                            == typeof(ISpecimenBuilderComposer)));
                var genericCreateAnonymous = createAnonymous
                    .MakeGenericMethod(property.PropertyType);
                return genericCreateAnonymous
                    .Invoke(null, new object[] { composer });
            }
        }
    }




}
