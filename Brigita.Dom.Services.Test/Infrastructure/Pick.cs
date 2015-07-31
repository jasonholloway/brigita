using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Test.Infrastructure
{

    public interface IPicker
    {
        T From<T>(IEnumerable<T> values);
        //T From<T>(params T[] values);
    }

    class RandomPicker : IPicker
    {
        static Random _rand = new Random();

        public T From<T>(IEnumerable<T> values) {
            var rVals = values.ToArray();
            int i = _rand.Next(rVals.Length);
            return rVals[i];
        }

        public T From<T>(params T[] values) {
            return From(values.AsEnumerable());
        }
    }

    class ConsecutivePicker : IPicker
    {
        public T From<T>(IEnumerable<T> values) {
            throw new NotImplementedException();
        }

        public T From<T>(params T[] values) {
            throw new NotImplementedException();
        }
    }


    public static class Pick
    {
        public static IPicker Randomly {
            get { return new RandomPicker(); }
        }

        public static IPicker Consecutively {
            get { return new ConsecutivePicker(); }
        }
    }

}
