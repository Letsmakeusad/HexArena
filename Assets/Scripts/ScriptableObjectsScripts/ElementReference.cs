using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assets.Scripts.TestScript.Variables
{
    [Serializable]
    public class ElementReference
    {
        public bool UseConstant = true;
        public ElementType ConstantValue;
        public ElementTypeVariable Variable;

        public ElementReference()
        { }

        public ElementReference(ElementType value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public ElementType Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
        }

        public static implicit operator ElementType(ElementReference reference)
        {
            return reference.Value;
        }
    }
}