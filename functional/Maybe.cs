using System;
using System.Collections;
using System.Collections.Generic;

namespace extensions
{
    public class Maybe
    {
        public static Maybe<T> Create<T>(T element)
        {
            return Maybe<T>.Create(element);
        }

        public static Maybe<T> CreateEmpty<T>()
        {
            return Maybe<T>.CreateEmpty();
        }
    }

    public class Maybe<T> : IEnumerable<T>
    {
        private readonly T[] _data;

        private Maybe(T[] data)
        {
            _data = data;
        }

        public static Maybe<T> Create(T element)
        {
            return new Maybe<T>(new[] { element });
        }

        public static Maybe<T> CreateEmpty()
        {
            return new Maybe<T>(new T[0]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class MaybeExtensions
    {
        public static Maybe<T> IfSpecified<T>(this Maybe<T> source, Action<T> action)
        {
            foreach(var e in source)
            {
                action(e);
            }

            return source;
        }
    }
}
