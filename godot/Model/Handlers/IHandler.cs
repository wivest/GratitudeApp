using System.Collections.Generic;

namespace GratitudeApp.Model.Handlers;

interface IHandler<T>
{
    public List<T> NewItems { get; set; }
}
