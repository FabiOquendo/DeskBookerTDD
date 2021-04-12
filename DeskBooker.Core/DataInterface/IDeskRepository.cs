using DeskBooker.Core.Domain;
using System;
using System.Collections.Generic;

namespace DeskBooker.Core.DataInterface
{
    public interface IDeskRepository
    {
        IEnumerable<Desk> GetAvailableDesks(DateTime date);
        IEnumerable<Desk> GetAll();
    }
}
