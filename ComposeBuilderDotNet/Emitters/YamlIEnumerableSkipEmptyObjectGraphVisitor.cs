﻿using System.Collections;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.ObjectGraphVisitors;

namespace ComposeBuilderDotNet.Emitters
{
    public sealed class YamlIEnumerableSkipEmptyObjectGraphVisitor : ChainedObjectGraphVisitor
    {
        public YamlIEnumerableSkipEmptyObjectGraphVisitor(IObjectGraphVisitor<IEmitter> nextVisitor)
            : base(nextVisitor)
        {
        }

        public override bool EnterMapping(IPropertyDescriptor key, IObjectDescriptor value, IEmitter context)
        {
            var retVal = false;

            if (value.Value == null)
            {
                return retVal;
            }

            if (typeof(IEnumerable).IsAssignableFrom(value.Value.GetType()))
            {
                // We have a collection
                var enumerableObject = (IEnumerable) value.Value;
                if (enumerableObject.GetEnumerator().MoveNext()) // Returns true if the collection is not empty.
                {
                    // Don't skip this item - serialize it as normal.
                    retVal = base.EnterMapping(key, value, context);
                }

                // Else we have an empty collection and the initialized return value of false is correct.
            }
            else
            {
                // Not a collection, normal serialization.
                retVal = base.EnterMapping(key, value, context);
            }

            return retVal;
        }
    }
}