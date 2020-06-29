namespace Isitar.DoenerOrder.CleanArchitecture.Application.Common.Exceptions
{
    using System;
    using CleanArchitecture.Common.Resources;

    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base(Resources.NotFoundException.Replace("{name}", name).Replace("{key}", key.ToString())) { }
    }
}